using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeoGeoMiniRomAdder {
    public partial class NewRomDlg : Form {
        public string RomPath { get { return tbRom.Text; } }
        public string RomName { get { return tbDisplayName.Text; } }
        public NewRomDlg() {
            InitializeComponent();
        }

        private void bLoad_Click(object sender, EventArgs e) {
            if (ofdRom.ShowDialog() == DialogResult.OK) {
                tbRom.Text = ofdRom.FileName;
            }
        }

        private void bOK_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void bCancel_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
