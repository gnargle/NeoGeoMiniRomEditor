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
            this.dgEmus = new System.Windows.Forms.DataGridView();
            this.dgRoms = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.pbLCD = new System.Windows.Forms.PictureBox();
            this.pbTV = new System.Windows.Forms.PictureBox();
            this.bLoadLCD = new System.Windows.Forms.Button();
            this.flDetails = new System.Windows.Forms.FlowLayoutPanel();
            this.lName = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lDir = new System.Windows.Forms.Label();
            this.tbDir = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.bNew = new System.Windows.Forms.Button();
            this.bSave = new System.Windows.Forms.Button();
            this.fileDialogImageLoad = new System.Windows.Forms.OpenFileDialog();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgEmus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgRoms)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTV)).BeginInit();
            this.flDetails.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // ngmhFolderbrowserDlg
            // 
            this.ngmhFolderbrowserDlg.Description = "Locate your NGMH folder";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.dgEmus);
            this.flowLayoutPanel1.Controls.Add(this.dgRoms);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel2);
            this.flowLayoutPanel1.Controls.Add(this.flDetails);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel3);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(761, 574);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // dgEmus
            // 
            this.dgEmus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgEmus.Location = new System.Drawing.Point(3, 3);
            this.dgEmus.MultiSelect = false;
            this.dgEmus.Name = "dgEmus";
            this.dgEmus.ReadOnly = true;
            this.dgEmus.Size = new System.Drawing.Size(350, 155);
            this.dgEmus.TabIndex = 0;
            this.dgEmus.SelectionChanged += new System.EventHandler(this.dgEmus_SelectionChanged);
            // 
            // dgRoms
            // 
            this.dgRoms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRoms.Location = new System.Drawing.Point(3, 164);
            this.dgRoms.MultiSelect = false;
            this.dgRoms.Name = "dgRoms";
            this.dgRoms.ReadOnly = true;
            this.dgRoms.Size = new System.Drawing.Size(350, 398);
            this.dgRoms.TabIndex = 5;
            this.dgRoms.SelectionChanged += new System.EventHandler(this.dgRoms_SelectionChanged);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.pbLCD);
            this.flowLayoutPanel2.Controls.Add(this.pbTV);
            this.flowLayoutPanel2.Controls.Add(this.bLoadLCD);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(359, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(395, 275);
            this.flowLayoutPanel2.TabIndex = 7;
            // 
            // pbLCD
            // 
            this.pbLCD.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pbLCD.Location = new System.Drawing.Point(3, 3);
            this.pbLCD.Name = "pbLCD";
            this.pbLCD.Size = new System.Drawing.Size(94, 78);
            this.pbLCD.TabIndex = 1;
            this.pbLCD.TabStop = false;
            // 
            // pbTV
            // 
            this.pbTV.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pbTV.Location = new System.Drawing.Point(103, 3);
            this.pbTV.Name = "pbTV";
            this.pbTV.Size = new System.Drawing.Size(282, 242);
            this.pbTV.TabIndex = 6;
            this.pbTV.TabStop = false;
            // 
            // bLoadLCD
            // 
            this.bLoadLCD.Location = new System.Drawing.Point(3, 251);
            this.bLoadLCD.Name = "bLoadLCD";
            this.bLoadLCD.Size = new System.Drawing.Size(114, 23);
            this.bLoadLCD.TabIndex = 7;
            this.bLoadLCD.Text = "Load New Image";
            this.bLoadLCD.UseVisualStyleBackColor = true;
            this.bLoadLCD.Click += new System.EventHandler(this.bLoadLCD_Click);
            // 
            // flDetails
            // 
            this.flDetails.Controls.Add(this.lName);
            this.flDetails.Controls.Add(this.tbName);
            this.flDetails.Controls.Add(this.lDir);
            this.flDetails.Controls.Add(this.tbDir);
            this.flDetails.Location = new System.Drawing.Point(359, 284);
            this.flDetails.Name = "flDetails";
            this.flDetails.Size = new System.Drawing.Size(395, 67);
            this.flDetails.TabIndex = 4;
            // 
            // lName
            // 
            this.lName.AutoSize = true;
            this.lName.Location = new System.Drawing.Point(3, 0);
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(35, 13);
            this.lName.TabIndex = 3;
            this.lName.Text = "Name";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(44, 3);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(341, 20);
            this.tbName.TabIndex = 2;
            // 
            // lDir
            // 
            this.lDir.AutoSize = true;
            this.lDir.Location = new System.Drawing.Point(3, 26);
            this.lDir.Name = "lDir";
            this.lDir.Size = new System.Drawing.Size(114, 13);
            this.lDir.TabIndex = 5;
            this.lDir.Text = "Directory (Short Name)";
            // 
            // tbDir
            // 
            this.tbDir.Location = new System.Drawing.Point(123, 29);
            this.tbDir.Name = "tbDir";
            this.tbDir.Size = new System.Drawing.Size(262, 20);
            this.tbDir.TabIndex = 4;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.bNew);
            this.flowLayoutPanel3.Controls.Add(this.bSave);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(359, 357);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(395, 100);
            this.flowLayoutPanel3.TabIndex = 8;
            // 
            // bNew
            // 
            this.bNew.Location = new System.Drawing.Point(3, 3);
            this.bNew.Name = "bNew";
            this.bNew.Size = new System.Drawing.Size(75, 23);
            this.bNew.TabIndex = 0;
            this.bNew.Text = "New ROM";
            this.bNew.UseVisualStyleBackColor = true;
            this.bNew.Visible = false;
            // 
            // bSave
            // 
            this.bSave.Location = new System.Drawing.Point(84, 3);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(75, 23);
            this.bSave.TabIndex = 1;
            this.bSave.Text = "Save ROM";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // fileDialogImageLoad
            // 
            this.fileDialogImageLoad.Filter = "Image files|*.jpg;*.png";
            this.fileDialogImageLoad.Title = "Select an Image...";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 574);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgEmus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgRoms)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTV)).EndInit();
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
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.PictureBox pbTV;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Button bNew;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Button bLoadLCD;
        private System.Windows.Forms.OpenFileDialog fileDialogImageLoad;
    }
}

