namespace NeoGeoMiniRomAdder {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.ngmhFolderbrowserDlg = new System.Windows.Forms.FolderBrowserDialog();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lEmus = new System.Windows.Forms.Label();
            this.dgEmus = new System.Windows.Forms.DataGridView();
            this.lRoms = new System.Windows.Forms.Label();
            this.dgRoms = new System.Windows.Forms.DataGridView();
            this.flpNGMImage = new System.Windows.Forms.FlowLayoutPanel();
            this.pbLCD = new System.Windows.Forms.PictureBox();
            this.pbTV = new System.Windows.Forms.PictureBox();
            this.bLoadLCD = new System.Windows.Forms.Button();
            this.pASPImage = new System.Windows.Forms.Panel();
            this.bLoadASP = new System.Windows.Forms.Button();
            this.pbCover = new System.Windows.Forms.PictureBox();
            this.flDetails = new System.Windows.Forms.FlowLayoutPanel();
            this.lName = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lDir = new System.Windows.Forms.Label();
            this.tbDir = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.bNew = new System.Windows.Forms.Button();
            this.bSave = new System.Windows.Forms.Button();
            this.bFixRoms = new System.Windows.Forms.Button();
            this.fileDialogImageLoad = new System.Windows.Forms.OpenFileDialog();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgEmus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgRoms)).BeginInit();
            this.flpNGMImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTV)).BeginInit();
            this.pASPImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCover)).BeginInit();
            this.flDetails.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // ngmhFolderbrowserDlg
            // 
            this.ngmhFolderbrowserDlg.Description = "Locate your NGMH folder";
            this.ngmhFolderbrowserDlg.UseDescriptionForTitle = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.lEmus);
            this.flowLayoutPanel1.Controls.Add(this.dgEmus);
            this.flowLayoutPanel1.Controls.Add(this.lRoms);
            this.flowLayoutPanel1.Controls.Add(this.dgRoms);
            this.flowLayoutPanel1.Controls.Add(this.flpNGMImage);
            this.flowLayoutPanel1.Controls.Add(this.pASPImage);
            this.flowLayoutPanel1.Controls.Add(this.flDetails);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel3);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(886, 662);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // lEmus
            // 
            this.lEmus.AutoSize = true;
            this.lEmus.Location = new System.Drawing.Point(4, 0);
            this.lEmus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lEmus.Name = "lEmus";
            this.lEmus.Size = new System.Drawing.Size(60, 15);
            this.lEmus.TabIndex = 9;
            this.lEmus.Text = "Emulators";
            // 
            // dgEmus
            // 
            this.dgEmus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgEmus.Location = new System.Drawing.Point(4, 18);
            this.dgEmus.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgEmus.MultiSelect = false;
            this.dgEmus.Name = "dgEmus";
            this.dgEmus.ReadOnly = true;
            this.dgEmus.Size = new System.Drawing.Size(408, 179);
            this.dgEmus.TabIndex = 0;
            this.dgEmus.SelectionChanged += new System.EventHandler(this.dgEmus_SelectionChanged);
            // 
            // lRoms
            // 
            this.lRoms.AutoSize = true;
            this.lRoms.Location = new System.Drawing.Point(4, 200);
            this.lRoms.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lRoms.Name = "lRoms";
            this.lRoms.Size = new System.Drawing.Size(37, 15);
            this.lRoms.TabIndex = 10;
            this.lRoms.Text = "Roms";
            // 
            // dgRoms
            // 
            this.dgRoms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRoms.Location = new System.Drawing.Point(4, 218);
            this.dgRoms.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgRoms.MultiSelect = false;
            this.dgRoms.Name = "dgRoms";
            this.dgRoms.ReadOnly = true;
            this.dgRoms.Size = new System.Drawing.Size(408, 438);
            this.dgRoms.TabIndex = 5;
            this.dgRoms.SelectionChanged += new System.EventHandler(this.dgRoms_SelectionChanged);
            // 
            // flpNGMImage
            // 
            this.flpNGMImage.Controls.Add(this.pbLCD);
            this.flpNGMImage.Controls.Add(this.pbTV);
            this.flpNGMImage.Controls.Add(this.bLoadLCD);
            this.flpNGMImage.Location = new System.Drawing.Point(420, 3);
            this.flpNGMImage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.flpNGMImage.Name = "flpNGMImage";
            this.flpNGMImage.Size = new System.Drawing.Size(461, 317);
            this.flpNGMImage.TabIndex = 7;
            // 
            // pbLCD
            // 
            this.pbLCD.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pbLCD.Location = new System.Drawing.Point(4, 3);
            this.pbLCD.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pbLCD.Name = "pbLCD";
            this.pbLCD.Size = new System.Drawing.Size(94, 78);
            this.pbLCD.TabIndex = 1;
            this.pbLCD.TabStop = false;
            // 
            // pbTV
            // 
            this.pbTV.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pbTV.Location = new System.Drawing.Point(106, 3);
            this.pbTV.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pbTV.Name = "pbTV";
            this.pbTV.Size = new System.Drawing.Size(282, 242);
            this.pbTV.TabIndex = 6;
            this.pbTV.TabStop = false;
            // 
            // bLoadLCD
            // 
            this.bLoadLCD.Location = new System.Drawing.Point(4, 251);
            this.bLoadLCD.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.bLoadLCD.Name = "bLoadLCD";
            this.bLoadLCD.Size = new System.Drawing.Size(133, 27);
            this.bLoadLCD.TabIndex = 7;
            this.bLoadLCD.Text = "Load New Image";
            this.bLoadLCD.UseVisualStyleBackColor = true;
            this.bLoadLCD.Click += new System.EventHandler(this.bLoadLCD_Click);
            // 
            // pASPImage
            // 
            this.pASPImage.Controls.Add(this.bLoadASP);
            this.pASPImage.Controls.Add(this.pbCover);
            this.pASPImage.Location = new System.Drawing.Point(419, 326);
            this.pASPImage.Name = "pASPImage";
            this.pASPImage.Size = new System.Drawing.Size(462, 308);
            this.pASPImage.TabIndex = 11;
            // 
            // bLoadASP
            // 
            this.bLoadASP.Location = new System.Drawing.Point(26, 276);
            this.bLoadASP.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.bLoadASP.Name = "bLoadASP";
            this.bLoadASP.Size = new System.Drawing.Size(133, 27);
            this.bLoadASP.TabIndex = 7;
            this.bLoadASP.Text = "Load New Image";
            this.bLoadASP.UseVisualStyleBackColor = true;
            this.bLoadASP.Click += new System.EventHandler(this.bLoadLCD_Click);
            // 
            // pbCover
            // 
            this.pbCover.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pbCover.Location = new System.Drawing.Point(188, 4);
            this.pbCover.Name = "pbCover";
            this.pbCover.Size = new System.Drawing.Size(254, 299);
            this.pbCover.TabIndex = 0;
            this.pbCover.TabStop = false;
            // 
            // flDetails
            // 
            this.flDetails.Controls.Add(this.lName);
            this.flDetails.Controls.Add(this.tbName);
            this.flDetails.Controls.Add(this.lDir);
            this.flDetails.Controls.Add(this.tbDir);
            this.flDetails.Location = new System.Drawing.Point(889, 3);
            this.flDetails.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.flDetails.Name = "flDetails";
            this.flDetails.Size = new System.Drawing.Size(461, 77);
            this.flDetails.TabIndex = 4;
            // 
            // lName
            // 
            this.lName.AutoSize = true;
            this.lName.Location = new System.Drawing.Point(4, 0);
            this.lName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(39, 15);
            this.lName.TabIndex = 3;
            this.lName.Text = "Name";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(51, 3);
            this.tbName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(397, 23);
            this.tbName.TabIndex = 2;
            // 
            // lDir
            // 
            this.lDir.AutoSize = true;
            this.lDir.Location = new System.Drawing.Point(4, 29);
            this.lDir.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lDir.Name = "lDir";
            this.lDir.Size = new System.Drawing.Size(129, 15);
            this.lDir.TabIndex = 5;
            this.lDir.Text = "Directory (Short Name)";
            // 
            // tbDir
            // 
            this.tbDir.Location = new System.Drawing.Point(141, 32);
            this.tbDir.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbDir.Name = "tbDir";
            this.tbDir.Size = new System.Drawing.Size(305, 23);
            this.tbDir.TabIndex = 4;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.bNew);
            this.flowLayoutPanel3.Controls.Add(this.bSave);
            this.flowLayoutPanel3.Controls.Add(this.bFixRoms);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(889, 86);
            this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(461, 115);
            this.flowLayoutPanel3.TabIndex = 8;
            // 
            // bNew
            // 
            this.bNew.Location = new System.Drawing.Point(4, 3);
            this.bNew.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.bNew.Name = "bNew";
            this.bNew.Size = new System.Drawing.Size(88, 27);
            this.bNew.TabIndex = 0;
            this.bNew.Text = "New ROM";
            this.bNew.UseVisualStyleBackColor = true;
            this.bNew.Click += new System.EventHandler(this.bNew_Click);
            // 
            // bSave
            // 
            this.bSave.Location = new System.Drawing.Point(100, 3);
            this.bSave.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(88, 27);
            this.bSave.TabIndex = 1;
            this.bSave.Text = "Save ROM";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // bFixRoms
            // 
            this.bFixRoms.Location = new System.Drawing.Point(196, 3);
            this.bFixRoms.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.bFixRoms.Name = "bFixRoms";
            this.bFixRoms.Size = new System.Drawing.Size(88, 27);
            this.bFixRoms.TabIndex = 2;
            this.bFixRoms.Text = "Fix ROMs";
            this.bFixRoms.UseVisualStyleBackColor = true;
            this.bFixRoms.Click += new System.EventHandler(this.bFixRoms_Click);
            // 
            // fileDialogImageLoad
            // 
            this.fileDialogImageLoad.Filter = "Image files|*.jpg;*.png";
            this.fileDialogImageLoad.Title = "Select an Image...";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 662);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NeoGeoMini Rom Tool";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgEmus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgRoms)).EndInit();
            this.flpNGMImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTV)).EndInit();
            this.pASPImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbCover)).EndInit();
            this.flDetails.ResumeLayout(false);
            this.flDetails.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog ngmhFolderbrowserDlg;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.DataGridView dgEmus;
        private System.Windows.Forms.PictureBox pbLCD;
        private System.Windows.Forms.FlowLayoutPanel flDetails;
        private System.Windows.Forms.Label lName;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.DataGridView dgRoms;
        private System.Windows.Forms.Label lDir;
        private System.Windows.Forms.TextBox tbDir;
        private System.Windows.Forms.FlowLayoutPanel flpNGMImage;
        private System.Windows.Forms.PictureBox pbTV;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Button bNew;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Button bLoadLCD;
        private System.Windows.Forms.OpenFileDialog fileDialogImageLoad;
        private System.Windows.Forms.Label lEmus;
        private System.Windows.Forms.Label lRoms;
        private System.Windows.Forms.Button bFixRoms;
        private System.Windows.Forms.Panel pASPImage;
        private System.Windows.Forms.PictureBox pbCover;
        private System.Windows.Forms.Button bLoadASP;
    }
}

