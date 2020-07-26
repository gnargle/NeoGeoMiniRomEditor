﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeoGeoMiniRomAdder {
    public partial class Form1 : Form {
        private string _ngmhFolder = String.Empty;
        private string _romInfoPath = String.Empty;
        private List<String> FoundEmus = new List<String>();
        private List<Emu> FoundEmusObj = new List<Emu>();
        private Dictionary<EmulatorType, List<RomInfo>> EmuLists = new Dictionary<EmulatorType, List<RomInfo>>();
        private List<RomInfo> romInfos = new List<RomInfo>();
        private List<RomInfo> currentList;
        private RomInfo currentRom;
        private ExtendedRomInfo currentExtendedInfo;
        private Bitmap loadedbmp, lcdbmp, tvbmp;
        Stream originalImageStream;
        public Form1() {
            InitializeComponent();
            try {
                if (ngmhFolderbrowserDlg.ShowDialog() == DialogResult.OK) {
                    //init 
                    Cursor.Current = Cursors.WaitCursor;
                    try {
                        _ngmhFolder = ngmhFolderbrowserDlg.SelectedPath;
                        _romInfoPath = Path.Combine(_ngmhFolder, "rominfo.txt");
                        if (!File.Exists(_romInfoPath))
                            throw new Exception("Could not find rominfo.txt!");
                        var romInfoData = File.ReadAllLines(_romInfoPath);
                        var currRom = new RomInfo();
                        foreach (var dataLine in romInfoData) {
                            //format (line by line) is ID, EMU, PATH, BLANK
                            if (dataLine.StartsWith("ID")) {
                                currRom = new RomInfo();
                                currRom.ID = dataLine.Substring(3);
                            } else if (dataLine.StartsWith("EMU")) {
                                currRom.EMU = (EmulatorType) Enum.Parse(typeof(EmulatorType), dataLine.Substring(4));
                                if (!FoundEmus.Contains(dataLine.Substring(4))) {
                                    FoundEmus.Add(dataLine.Substring(4));
                                    FoundEmusObj.Add(new Emu() { Type = currRom.EMU });
                                    EmuLists.Add(currRom.EMU, new List<RomInfo>());
                                }
                            } else if (dataLine.StartsWith("PATH")) {
                                currRom.PATH = dataLine.Substring(5);
                            } else {
                                romInfos.Add(currRom);
                                EmuLists[currRom.EMU].Add(currRom);
                            }
                        }            
                        dgEmus.DataSource = FoundEmusObj;
                } finally {
                        Cursor.Current = Cursors.Default;
                    }
                } else {
                    throw new Exception("You must select a pre-existing NGMH folder!");                    
                }
            } catch (Exception e) {
                MessageBox.Show(e.Message);
                Close();
            }
        }

        private void dgEmus_SelectionChanged(object sender, EventArgs e) {
            currentList = EmuLists[((Emu)dgEmus.CurrentRow.DataBoundItem).Type];
            dgRoms.DataSource = currentList;
        }

        private void dgRoms_SelectionChanged(object sender, EventArgs e) {
            currentRom = (RomInfo)dgRoms.CurrentRow.DataBoundItem;
            var local = Path.Combine(_ngmhFolder, "local");
            var gameFound = false;
            currentExtendedInfo = new ExtendedRomInfo();
            foreach (var dir in Directory.GetDirectories(local)) {
                if (dir.Contains(currentRom.EmuString)) {
                    var gameIni = File.ReadAllLines(Path.Combine(dir, "games.ini"));
                    foreach (var line in gameIni) {
                        if (line.StartsWith("[GAME]")) {

                        } else if (line.StartsWith("[ID]")) {
                            currentExtendedInfo.ID = int.Parse(line.Substring(5));
                        } else if (line.StartsWith("[TYPE]")) {
                            //always 5 for non fba
                        } else if (line.StartsWith("[NAME]")) {
                            currentExtendedInfo.Name = line.Substring(7);
                        } else if (line.StartsWith("[DIR]")) {
                            currentExtendedInfo.Dir = line.Substring(6);
                            if (currentExtendedInfo.Dir.Equals(currentRom.ID)) {
                                gameFound = true;
                                currentExtendedInfo.GameINI = Path.Combine(dir, "games.ini");
                            }
                        } else {
                            if (gameFound) break;
                        }
                    }
                    if (gameFound) break;
                }
            }
            if (gameFound) {
                //populate controls
                tbName.Text = currentExtendedInfo.Name;
                tbDir.Text = currentExtendedInfo.Dir;
                currentExtendedInfo.LCDImage = Path.Combine(_ngmhFolder, "image\\games", currentExtendedInfo.Dir, "LCD.png");
                currentExtendedInfo.TVImage = Path.Combine(_ngmhFolder, "image\\games", currentExtendedInfo.Dir, "TV.png");
                using (var bmpTemp = new Bitmap(currentExtendedInfo.LCDImage)) {
                    pbLCD.Image = new Bitmap(bmpTemp);
                }
                using (var bmpTemp = new Bitmap(currentExtendedInfo.TVImage)) {
                    pbTV.Image = new Bitmap(bmpTemp);
                }
            }            
        }

        private void bSave_Click(object sender, EventArgs e) {
            try {
                int idIndex = 0, TypeIndex = 0, NameIndex = 0, DirIndex = 0;
                if (currentExtendedInfo != null) {
                    if (currentExtendedInfo.IsNew) {
                        //generate all the stuff here.
                    } else {
                        var gameIni = File.ReadAllLines(currentExtendedInfo.GameINI); //load the game ini back in.
                        var gameFound = false;
                        //try and find the game again. This will fail if the DIR has been changed. If that's the case we should error and tell the user.
                        int idx = 0;
                        foreach (var line in gameIni) {
                            if (line.StartsWith("[GAME]")) {
                            } else if (line.StartsWith("[ID]")) {
                                idIndex = idx;
                            } else if (line.StartsWith("[TYPE]")) {
                                TypeIndex = idx;
                            } else if (line.StartsWith("[NAME]")) {
                                NameIndex = idx;
                            } else if (line.StartsWith("[DIR]")) {
                                if (currentExtendedInfo.Dir.Equals(line.Substring(6))) {
                                    gameFound = true;
                                    DirIndex = idx;
                                }
                            } else {
                                if (gameFound) {
                                    break;
                                }
                            }
                            idx++;
                        }
                        if (!gameFound) {
                            throw new Exception("Game could not be found. You may have changed the Directory (Short Name) - this needs to be reverted.");
                        }
                        gameIni[idIndex] = $"[ID]={currentExtendedInfo.ID}";
                        gameIni[TypeIndex] = $"[TYPE]={currentExtendedInfo.Type}";
                        gameIni[NameIndex] = $"[NAME]={currentExtendedInfo.Name}";
                        gameIni[DirIndex] = $"[DIR]={currentExtendedInfo.Dir}";
                        if (currentExtendedInfo.NewImage) {
                            ((Bitmap)pbLCD.Image).Save(currentExtendedInfo.LCDImage, ImageFormat.Png);
                            ((Bitmap)pbTV.Image).Save(currentExtendedInfo.TVImage, ImageFormat.Png);
                            currentExtendedInfo.NewImage = false;
                        }
                    }
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadImage() {
            if (fileDialogImageLoad.ShowDialog() == DialogResult.OK) {
                File.Copy(fileDialogImageLoad.FileName, fileDialogImageLoad.FileName + "_1", true);
                byte[] data = File.ReadAllBytes(fileDialogImageLoad.FileName);
                Stream originalImageStream = new MemoryStream(data);
                loadedbmp = new Bitmap(originalImageStream);
                currentExtendedInfo.NewImage = true;
                currentExtendedInfo.NewImageFile = fileDialogImageLoad.FileName + "_1";
                lcdbmp = new Bitmap(loadedbmp, new Size(pbLCD.Width, pbLCD.Height));
                pbLCD.Image.Dispose();
                pbLCD.ImageLocation = String.Empty;
                pbLCD.Image = lcdbmp;
                currentExtendedInfo.NewImage = true;
                tvbmp = new Bitmap(loadedbmp, new Size(pbTV.Width, pbTV.Height));
                pbTV.Image.Dispose();
                pbTV.ImageLocation = String.Empty;
                pbTV.Image = tvbmp;
                originalImageStream.Dispose();
            }
        }

        private void bLoadLCD_Click(object sender, EventArgs e) {
            LoadImage();
        }
    }
}