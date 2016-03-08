using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Helper_GlobalKeybinder.ProjectSRC.GUI {
    public partial class ConfigureKey : Form {
        public char SelectedChar;
        public bool Alt;
        public bool Control;
        public bool Shift;
        public bool Save;

        public ConfigureKey() {
            InitializeComponent();
        }

        private void b_cancel_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void cb_key_KeyPress(object sender, KeyPressEventArgs e) {
            if(!cb_key.Checked) return;

            cb_key.Text = e.KeyChar.ToString();
            SelectedChar = e.KeyChar;
        }

        private void cb_key_Leave(object sender, EventArgs e) {
            if(cb_key.Checked) cb_key.Checked = false;
        }

        private void b_save_Click(object sender, EventArgs e) {
            Alt = cbox_alt.Checked;
            Control = cbox_control.Checked;
            Shift = cbox_shift.Checked;
            Save = true;
            this.Close();
        }
    }
}
