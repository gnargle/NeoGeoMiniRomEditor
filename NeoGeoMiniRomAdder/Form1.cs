using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeoGeoMiniRomAdder {
    public partial class Form1 : System.Windows.Forms.Form {
        private string _ngmhFolder = String.Empty;
        private string _romInfoPath = String.Empty;
        private List<String> FoundEmus = new List<String>();
        private List<Emu> FoundEmusObj = new List<Emu>();
        private Dictionary<EmulatorType, List<RomInfo>> EmuLists = new Dictionary<EmulatorType, List<RomInfo>>();
        private List<RomInfo> romInfos = new List<RomInfo>();
        private List<RomInfo> currentList;
        private EmulatorType currentEmu;
        private RomInfo currentRom;
        private ExtendedRomInfo currentExtendedInfo;
        private Bitmap loadedbmp, lcdbmp, tvbmp, coverbmp;
        private bool _ASPMode = false;

        private const int LCD_WIDTH = 94;
        private const int LCD_HEIGHT = 78;
        private const int TV_WIDTH = 282;
        private const int TV_HEIGHT = 242;
        private const int COVER_WIDTH = 254;
        private const int COVER_HEIGHT = 299;

        public Form1() {
            InitializeComponent();            
        }

        private void Form1_Shown(object sender, EventArgs e) {
            //try {
            if (ngmhFolderbrowserDlg.ShowDialog() == DialogResult.OK) {
                //init 
                Cursor.Current = Cursors.WaitCursor;
                try {
                    _ngmhFolder = ngmhFolderbrowserDlg.SelectedPath;
                    if (_ngmhFolder.Contains("ASPh"))
                        _ASPMode = true;
                    if (_ASPMode) 
                        _romInfoPath = Path.Combine(_ngmhFolder, "hack", "rominfo.txt");                        
                     else 
                        _romInfoPath = Path.Combine(_ngmhFolder, "rominfo.txt");
                    pASPImage.Visible = _ASPMode;
                    flpNGMImage.Visible = !_ASPMode;
                    if (!File.Exists(_romInfoPath))
                        throw new Exception("Could not find rominfo.txt!");
                    LoadAll();
                } finally {
                    Cursor.Current = Cursors.Default;
                }
            } else {
                throw new Exception("You must select a pre-existing NGMH folder!");
            }
            // } catch (Exception ex) {
            //     MessageBox.Show(ex.Message);
            //     Close();
            // }
        }

        private void LoadAll() {
            var romInfoData = File.ReadAllLines(_romInfoPath);
            var currRom = new RomInfo();
            foreach (var dataLine in romInfoData) {
                //format (line by line) is ID, EMU, PATH, BLANK
                if (dataLine.StartsWith("ID")) {
                    if (currRom != null && !String.IsNullOrWhiteSpace(currRom.ID)) {
                        romInfos.Add(currRom);
                        EmuLists[currRom.EMU].Add(currRom);
                        currRom = null;
                    }
                    currRom = new RomInfo();
                    currRom.ID = dataLine.Substring(3);
                } else if (dataLine.StartsWith("EMU")) {
                    currRom.EMU = (EmulatorType)Enum.Parse(typeof(EmulatorType), dataLine.Substring(4));
                    if (!FoundEmus.Contains(dataLine.Substring(4))) {                        
                        FoundEmus.Add(dataLine.Substring(4));
                        if (currRom.EMU != EmulatorType.fba && currRom.EMU != EmulatorType.ra && currRom.EMU != EmulatorType.ng && currRom.EMU != EmulatorType.pce) //don't add fba to the grid list since adding/editing roms for that is unsupported.
                            FoundEmusObj.Add(new Emu() { Type = currRom.EMU });
                        EmuLists.Add(currRom.EMU, new List<RomInfo>());
                    }
                } else if (dataLine.StartsWith("PATH")) {
                    currRom.PATH = dataLine.Substring(5);
                } else {
                    if (currRom != null && !String.IsNullOrWhiteSpace(currRom.ID)) {
                        romInfos.Add(currRom);
                        EmuLists[currRom.EMU].Add(currRom);
                        currRom = null;
                    }
                }
            }
            if (currRom != null) {
                romInfos.Add(currRom);
                EmuLists[currRom.EMU].Add(currRom);
                currRom = null;
            } //clean up if we have one left e.g. if there isn't a new line at the end of the file
            dgEmus.DataSource = FoundEmusObj;
        }

        private void ReloadAll() {
            dgRoms.SelectionChanged -= dgRoms_SelectionChanged;
            dgEmus.SelectionChanged -= dgEmus_SelectionChanged;
            dgRoms.ClearSelection();
            dgRoms.DataSource = null;
            dgEmus.ClearSelection();
            dgEmus.DataSource = null;
            dgRoms.SelectionChanged += dgRoms_SelectionChanged;
            dgEmus.SelectionChanged += dgEmus_SelectionChanged;
            FoundEmus.Clear();
            FoundEmusObj.Clear();
            EmuLists.Clear();
            romInfos.Clear();
            currentList.Clear();
            currentRom = null;
            currentExtendedInfo = null;
            LoadAll();
        }

        private void dgEmus_SelectionChanged(object sender, EventArgs e) {
            if (dgEmus.CurrentRow != null) {
                currentEmu = ((Emu)dgEmus.CurrentRow.DataBoundItem).Type;
                currentList = EmuLists[currentEmu];
                dgRoms.DataSource = currentList;
            }
        }

        private ExtendedRomInfo GetExtendedRomInfo(RomInfo currentRom) {
            var local = Path.Combine(_ngmhFolder, "local");
            var gameFound = false;
            currentExtendedInfo = new ExtendedRomInfo();
            if (_ASPMode) {
                //need to read langarray as currently the langs can't be custom defined...
                var langArray = File.ReadAllLines(Path.Combine(local, "lang_array.ini"));
                var fold = String.Empty;
                foreach (var langLine in langArray) {
                    if (langLine.StartsWith("[")) {
                        var lineSplit = langLine.Split('=');
                        var emu = lineSplit[1].Substring(1, lineSplit[1].Length - 2);
                        if (emu.Equals(currentRom.ASPString, StringComparison.InvariantCultureIgnoreCase)) {
                            fold = Path.Combine(local, lineSplit[0].Substring(1, lineSplit[0].Length - 2));
                            break;
                        }                        
                    }
                }
                if (fold != String.Empty) {
                    var gameIni = File.ReadAllLines(Path.Combine(fold, "games.ini"));
                    foreach (var line in gameIni) {
                        if (line.StartsWith("[GAME]")) {

                        } else if (line.StartsWith("[ID]")) {
                            var a = line.Substring(5);
                            currentExtendedInfo.ID = int.Parse(a.Substring(1, a.Length - 2));
                        } else if (line.StartsWith("[TYPE]")) {
                            //always 5 for non fba
                        } else if (line.StartsWith("[NAME]")) {
                            //currentExtendedInfo.Name = line.Substring(7);
                        } else if (line.StartsWith("[DIR]")) {
                            var a = line.Substring(6);
                            currentExtendedInfo.Dir = a.Substring(1, a.Length-2);
                            if (currentExtendedInfo.Dir.Equals(currentRom.ID)) {
                                gameFound = true;
                                currentExtendedInfo.GameINI = Path.Combine(fold, "games.ini");
                            }
                        } else {
                            if (gameFound) break;
                        }
                    }
                }
            } else {
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
            }
            if (gameFound) {
                if (_ASPMode) {
                    currentExtendedInfo.CoverImage = Path.Combine(_ngmhFolder, "games", currentExtendedInfo.Dir, "cover.png");
                } else {
                    currentExtendedInfo.LCDImage = Path.Combine(_ngmhFolder, "image\\games", currentExtendedInfo.Dir, "LCD.png");
                    currentExtendedInfo.TVImage = Path.Combine(_ngmhFolder, "image\\games", currentExtendedInfo.Dir, "TV.png");
                }
                return currentExtendedInfo;
            } else return null;
        }

        private void dgRoms_SelectionChanged(object sender, EventArgs e) {
            if (dgRoms.CurrentRow != null) {
                currentRom = (RomInfo)dgRoms.CurrentRow.DataBoundItem;
                var local = Path.Combine(_ngmhFolder, "local");
                currentExtendedInfo = GetExtendedRomInfo(currentRom);
                if (currentExtendedInfo != null) {
                    //populate controls
                    tbName.Text = currentExtendedInfo.Name;
                    tbDir.Text = currentExtendedInfo.Dir;

                    if (_ASPMode) {
                        using (var bmpTemp = new Bitmap(currentExtendedInfo.CoverImage)) {
                            pbCover.Image = new Bitmap(bmpTemp);
                        }
                    } else {
                        using (var bmpTemp = new Bitmap(currentExtendedInfo.LCDImage)) {
                            pbLCD.Image = new Bitmap(bmpTemp);
                        }
                        using (var bmpTemp = new Bitmap(currentExtendedInfo.TVImage)) {
                            pbTV.Image = new Bitmap(bmpTemp);
                        }
                    }
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
                                if (_ASPMode) {
                                    var a = line.Substring(6);
                                    currentExtendedInfo.Dir = a.Substring(1, a.Length - 2);
                                    if (currentExtendedInfo.Dir.Equals(currentRom.ID)) {
                                        gameFound = true;
                                        DirIndex = idx;
                                    }
                                } else {
                                    if (currentExtendedInfo.Dir.Equals(line.Substring(6))) {
                                        gameFound = true;
                                        DirIndex = idx;
                                    }
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
                        if (_ASPMode) {
                            //nothing currently changes or even exists other than the ID for asp, so leave this for now. Just save the image.
                            if (currentExtendedInfo.NewImage) {
                                ((Bitmap)pbCover.Image).Save(currentExtendedInfo.CoverImage, ImageFormat.Png);
                                currentExtendedInfo.NewImage = false;
                            }
                        } else {
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
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        public static void WriteAllLinesLinux(string path, IEnumerable<string> lines, string separator) {
            using (var writer = new StreamWriter(path)) {
                foreach (var line in lines) {
                    writer.Write(line);
                    writer.Write(separator);
                }
            }
        }

        private void FixRoms() {
            var romInfoData = File.ReadAllLines(_romInfoPath);
            foreach (var row in dgEmus.Rows) {
                var dgvr = (DataGridViewRow)(row);
                var emuType = ((Emu)(dgvr.DataBoundItem)).Type;
                if (emuType == EmulatorType.fba || emuType == EmulatorType.ra || emuType == EmulatorType.ng)
                    continue; //skip arcade types.
                var list = EmuLists[((Emu)(dgvr.DataBoundItem)).Type];
                foreach (var info in list) {
                    var extInfo = GetExtendedRomInfo(info);
                    if (extInfo != null) {
                        var origID = info.ID;
                        var origPath = info.PATH;
                        var filename = Path.GetFileNameWithoutExtension(info.PATH);
                        Regex rgx = new Regex("[^a-zA-Z0-9]");
                        filename = rgx.Replace(filename, "") + Path.GetExtension(info.PATH);
                        var newPath = info.PATH.Replace(Path.GetFileName(info.PATH), filename.ToLower());
                        info.PATH = newPath;
                        info.ID = rgx.Replace(info.ID, "").ToLower();
                        extInfo.Dir = rgx.Replace(extInfo.Dir, "").ToLower();
                        //so, first, the easy bit. Rename the image folder.
                        String imgFolder = String.Empty;
                        if (_ASPMode)
                            imgFolder = Path.GetDirectoryName(extInfo.CoverImage);
                        else
                            imgFolder = Path.GetDirectoryName(extInfo.LCDImage);
                        var newImgFolder = imgFolder.Replace(origID, info.ID);
                        if (imgFolder != newImgFolder && Directory.Exists(imgFolder)) {
                            Directory.Move(imgFolder, newImgFolder + "_2");
                            Directory.Move(newImgFolder + "_2", newImgFolder);
                        }
                        if (_ASPMode) {
                            if (origPath != newPath && File.Exists(origPath.Replace("/mnt/hdisk/asph/hack/roms", _ngmhFolder)))
                                File.Move(origPath.Replace("/mnt/hdisk/asph/hack/roms", _ngmhFolder), newPath.Replace("/mnt/hdisk/asph/hack/roms", _ngmhFolder));
                        } else {
                            if (origPath != newPath && File.Exists(origPath.Replace("/vendor/res", _ngmhFolder)))
                                File.Move(origPath.Replace("/vendor/res", _ngmhFolder), newPath.Replace("/vendor/res", _ngmhFolder));
                        }
                        //ok, now change the rominfo.txt
                        bool IDFound = false, PathFound = false;
                        for (var i = 0; i <= romInfoData.Count() - 1; i++) {
                            var line = romInfoData[i];
                            if (line.StartsWith("ID") && line.Contains(origID)) {
                                line = line.Replace(origID, info.ID);
                                romInfoData[i] = line;
                                IDFound = true;
                            } else if (line.StartsWith("PATH") && line.Contains(origPath)) {
                                line = line.Replace(origPath, newPath);
                                romInfoData[i] = line;
                                PathFound = true;
                            }
                            if (IDFound && PathFound) break;
                        }
                        //now, the games.ini.
                        var gameFound = false;
                        var local = Path.Combine(_ngmhFolder, "local");
                        if (_ASPMode) {
                            var langArray = File.ReadAllLines(Path.Combine(local, "lang_array.ini"));
                            var fold = String.Empty;
                            foreach (var langLine in langArray) {
                                if (langLine.StartsWith("[")) {
                                    var lineSplit = langLine.Split('=');
                                    var emu = lineSplit[1].Substring(1, lineSplit[1].Length - 2);
                                    if (emu.Equals(currentRom.ASPString, StringComparison.InvariantCultureIgnoreCase)) {
                                        fold = Path.Combine(local, lineSplit[0].Substring(1, lineSplit[0].Length - 2));
                                        break;
                                    }
                                }
                            }
                            if (fold != String.Empty) {
                                var gameIni = File.ReadAllLines(Path.Combine(fold, "games.ini")).ToList();
                                for (var i = 0; i <= gameIni.Count() - 1; i++) {
                                    var line = gameIni[i];
                                    if (line.StartsWith("[DIR]") && line.Contains(origID)) {
                                        line = line.Replace(origID, info.ID);
                                        gameIni[i] = line;
                                        gameFound = true;
                                        break;
                                    } else {
                                        if (gameFound) break;
                                    }
                                }
                                if (gameFound) {
                                    WriteAllLinesLinux(Path.Combine(fold, "games.ini"), gameIni, "\n");
                                    //NGM requires linux line-endings.
                                    break;
                                }
                            }
                        } else {
                            foreach (var dir in Directory.GetDirectories(local)) {
                                if (dir.Contains(info.EmuString)) {
                                    var gameIni = File.ReadAllLines(Path.Combine(dir, "games.ini"));
                                    for (var i = 0; i <= gameIni.Count() - 1; i++) {
                                        var line = gameIni[i];
                                        if (line.StartsWith("[DIR]") && line.Contains(origID)) {
                                            line = line.Replace(origID, info.ID);
                                            gameIni[i] = line;
                                            gameFound = true;
                                            break;
                                        } else {
                                            if (gameFound) break;
                                        }
                                    }
                                    if (gameFound) {
                                        WriteAllLinesLinux(Path.Combine(dir, "games.ini"), gameIni, "\n");
                                        //NGM requires linux line-endings.
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            WriteAllLinesLinux(_romInfoPath, romInfoData, "\n");
        }

        private void bFixRoms_Click(object sender, EventArgs e) {
            FixRoms();
        }

        private void bNew_Click(object sender, EventArgs e) {
            var newRomDlg = new NewRomDlg();
            newRomDlg.Text = $"Adding new ROM for {currentEmu} system";
            if (newRomDlg.ShowDialog() == DialogResult.OK) {
                Cursor.Current = Cursors.WaitCursor;
                try {
                    var newInfo = new RomInfo() {
                        EMU = currentEmu,
                        ID = Path.GetFileNameWithoutExtension(newRomDlg.RomPath)
                    };
                    if (_ASPMode) {
                        newInfo.PATH = Path.Combine("/mnt/hdisk/asph/hack/roms/", newInfo.EmuString, Path.GetFileName(newRomDlg.RomPath)).Replace("\\", "/");
                    } else {
                        newInfo.PATH = Path.Combine("/vendor/res/roms/", newInfo.EmuString, Path.GetFileName(newRomDlg.RomPath)).Replace("\\", "/");
                    }
                    currentList.Add(newInfo);
                    ExtendedRomInfo newExt;
                    if (_ASPMode) {
                        newExt = new ExtendedRomInfo() {
                            ID = -1, //we'll need to replace this when traversing the INI.
                            Name = newRomDlg.RomName,
                            Dir = newInfo.ID,
                            IsNew = true,
                            CoverImage = Path.Combine(_ngmhFolder, "games", newInfo.ID, "cover.png")
                    };
                        //save images and move rom into place.
                        Directory.CreateDirectory(Path.GetDirectoryName(newExt.CoverImage));
                        Properties.Resources.Cover.Save(newExt.CoverImage);
                        Directory.CreateDirectory(Path.GetDirectoryName(newInfo.PATH.Replace("/mnt/hdisk/asph/hack/roms", _ngmhFolder)));
                        File.Copy(newRomDlg.RomPath, newInfo.PATH.Replace("/mnt/hdisk/asph/hack/roms", _ngmhFolder), true);
                        //add to RomInfo.txt
                        var romInfoData = File.ReadAllLines(_romInfoPath).ToList();
                        romInfoData.Add($"ID={newInfo.ID}");
                        romInfoData.Add($"EMU={newInfo.EMU}");
                        romInfoData.Add($"PATH={newInfo.PATH}");
                        WriteAllLinesLinux(_romInfoPath, romInfoData, "\n");
                        //finally add to games.Ini.
                        var local = Path.Combine(_ngmhFolder, "local");
                        var langArray = File.ReadAllLines(Path.Combine(local, "lang_array.ini"));
                        var fold = String.Empty;
                        foreach (var langLine in langArray) {
                            if (langLine.StartsWith("[")) {
                                var lineSplit = langLine.Split('=');
                                var emu = lineSplit[1].Substring(1, lineSplit[1].Length - 2);
                                if (emu.Equals(currentRom.ASPString, StringComparison.InvariantCultureIgnoreCase)) {
                                    fold = Path.Combine(local, lineSplit[0].Substring(1, lineSplit[0].Length - 2));
                                    break;
                                }
                            }
                        }
                        if (fold != String.Empty) {
                            var latestID = 0;
                            var gameIni = File.ReadAllLines(Path.Combine(fold, "games.ini")).ToList();
                            foreach (var line in gameIni) {
                                if (line.StartsWith("[ID]")) {
                                    var a = line.Substring(5);
                                    latestID = int.Parse(a.Substring(1, a.Length - 2));
                                }
                            }
                            newExt.ID = latestID + 1;
                            if (gameIni.Any()) {
                                gameIni.Add("[GAME]");
                                gameIni.Add($"[ID]=<{newExt.ID}>");
                                gameIni.Add($"[TYPE]=< >");
                                gameIni.Add($"[NAME]=< >");
                                gameIni.Add($"[DIR]=<{newExt.Dir}>");
                                gameIni.Add("[GAME\\]");
                                gameIni.Add("");
                            }
                            WriteAllLinesLinux(Path.Combine(fold, "games.ini"), gameIni, "\n");
                        }
                    } else {
                        newExt = new ExtendedRomInfo() {
                            ID = -1, //we'll need to replace this when traversing the INI.
                            Name = newRomDlg.RomName,
                            Dir = newInfo.ID,
                            IsNew = true,
                            Type = 5,
                            LCDImage = Path.Combine(_ngmhFolder, "image\\games", newInfo.ID, "LCD.png"),
                            TVImage = Path.Combine(_ngmhFolder, "image\\games", newInfo.ID, "TV.png"),
                        };
                        //save images and move rom into place.
                        Directory.CreateDirectory(Path.GetDirectoryName(newExt.LCDImage));
                        Properties.Resources.LCD.Save(newExt.LCDImage);
                        Properties.Resources.TV.Save(newExt.TVImage);
                        Directory.CreateDirectory(Path.GetDirectoryName(newInfo.PATH.Replace("/vendor/res", _ngmhFolder)));
                        File.Copy(newRomDlg.RomPath, newInfo.PATH.Replace("/vendor/res", _ngmhFolder), true);
                        //add to RomInfo.txt
                        var romInfoData = File.ReadAllLines(_romInfoPath).ToList();
                        romInfoData.Add($"ID={newInfo.ID}");
                        romInfoData.Add($"EMU={newInfo.EMU}");
                        romInfoData.Add($"PATH={newInfo.PATH}");
                        WriteAllLinesLinux(_romInfoPath, romInfoData, "\n");
                        //finally add to games.Ini.
                        var local = Path.Combine(_ngmhFolder, "local");
                        currentExtendedInfo = new ExtendedRomInfo();
                        List<string> gameIni = new List<string>();
                        string lastDir = String.Empty;
                        foreach (var dir in Directory.GetDirectories(local)) {
                            lastDir = dir;
                            if (dir.Contains(currentRom.EmuString)) {
                                var latestID = 0;
                                gameIni = File.ReadAllLines(Path.Combine(dir, "games.ini")).ToList();
                                foreach (var line in gameIni) {
                                    if (line.StartsWith("[ID]")) {
                                        latestID = int.Parse(line.Substring(5));
                                    }
                                }
                                if (latestID < 80) { //80 for NGM - ASP limit is 300 before things start getting funky.
                                    newExt.ID = latestID + 1;
                                    break;
                                }
                            }
                        }
                        /* if (newExt.ID == -1) {
                            //need to create a new folder...
                            //corss that bridge in a minute
                        }*/
                        if (gameIni.Any()) {
                            gameIni.Add("[GAME]");
                            gameIni.Add($"[ID]={newExt.ID}");
                            gameIni.Add($"[TYPE]={newExt.Type}");
                            gameIni.Add($"[NAME]={newExt.Name}");
                            gameIni.Add($"[DIR]={newExt.Dir}");
                            gameIni.Add("");
                        }
                        WriteAllLinesLinux(Path.Combine(lastDir, "games.ini"), gameIni, "\n");
                        
                    }
                    FixRoms();
                    ReloadAll();
                } finally {
                    Cursor.Current = Cursors.Default;
                }
            }
        }        

        private void LoadImage() {
            if (fileDialogImageLoad.ShowDialog() == DialogResult.OK) {
                byte[] data = File.ReadAllBytes(fileDialogImageLoad.FileName);
                Stream originalImageStream = new MemoryStream(data);
                loadedbmp = new Bitmap(originalImageStream);
                currentExtendedInfo.NewImage = true;
                if (_ASPMode) {
                    coverbmp = new Bitmap(loadedbmp, new Size(COVER_WIDTH, COVER_HEIGHT));
                    pbCover.Image.Dispose();
                    pbCover.ImageLocation = String.Empty;
                    pbCover.Image = coverbmp;
                } else {                    
                    lcdbmp = new Bitmap(loadedbmp, new Size(LCD_WIDTH, LCD_HEIGHT)); 
                    pbLCD.Image.Dispose();
                    pbLCD.ImageLocation = String.Empty;
                    pbLCD.Image = lcdbmp;
                    tvbmp = new Bitmap(loadedbmp, new Size(TV_WIDTH, TV_HEIGHT));
                    pbTV.Image.Dispose();
                    pbTV.ImageLocation = String.Empty;
                    pbTV.Image = tvbmp;
                }                
                originalImageStream.Dispose();
            }
        }

        private void bLoadLCD_Click(object sender, EventArgs e) {
            LoadImage();
        }
    }
}
