using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Helper_GlobalKeybinder.ProjectSRC.Model;

namespace Helper_GlobalKeybinder.ProjectSRC.GUI {
    public partial class ConfigureKey : Form {
        public char SelectedChar;
        public string SpecialKey;
        public bool SaveSpecial;
        public bool Alt;
        public bool Control;
        public bool Shift;
        public bool Save;
        public int Delay;

        public ConfigureKey() {
            InitializeComponent();
        }

        public GlobalHotkey CreateGlobalHotkeyFromConfigKey() {
            this.ShowDialog();
            if (!this.Save) return null;

            int mod = Constants.NOMOD;
            if (this.Alt) mod += Constants.ALT;
            if (this.Control) mod += Constants.CTRL;
            if (this.Shift) mod += Constants.SHIFT;

            string special = this.SpecialKey;
            char selectedChar = this.SelectedChar;
            int delay = this.Delay;
            Debug.WriteLine(this.SaveSpecial);
            if (!this.SaveSpecial) {
                 return new GlobalHotkey(mod, selectedChar);
            } else {
                bool mouse = false;
                GlobalHotkey.SpecialKeyTypes type = GlobalHotkey.SpecialKeyTypes.NotAssigned;
                if (special == "Left Mouse Button") {
                    type = GlobalHotkey.SpecialKeyTypes.LeftMouseButton;
                    mouse = true;
                }
                if (special == "Right Mouse Button") {
                    type = GlobalHotkey.SpecialKeyTypes.RightMouseButton;
                    mouse = true;
                }
                if (special == "Middle Mouse Button") {
                    type = GlobalHotkey.SpecialKeyTypes.MiddleMouseButton;
                    mouse = true;
                }
                if(special == "Arrow Left") type = GlobalHotkey.SpecialKeyTypes.ArrowLeft;
                if (special == "Arrow Right") type = GlobalHotkey.SpecialKeyTypes.ArrowRight;
                if (special == "Arrow Up") type = GlobalHotkey.SpecialKeyTypes.ArrowUp;
                if (special == "Arrow Down") type = GlobalHotkey.SpecialKeyTypes.ArrowDown;
                if (type != GlobalHotkey.SpecialKeyTypes.NotAssigned) return new GlobalHotkey(mod, type, delay, mouse);
            }
            return null;
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
            SaveAndClose();
        }

        private void comboBox_special_SelectedIndexChanged(object sender, EventArgs e) {
            ComboBox cbox = (ComboBox) sender;
            string selectedItem = (string)cbox.Items[cbox.SelectedIndex];
            SpecialKey = selectedItem;
        }

        private void b_save_special_Click(object sender, EventArgs e) {
            SaveSpecial = true;
            SaveAndClose();
        }

        private void SaveAndClose() {
            Alt = cbox_alt.Checked;
            Control = cbox_control.Checked;
            Shift = cbox_shift.Checked;
            Save = true;
            try {
                Delay = Convert.ToInt32(tb_delay.Text);
            } catch(FormatException) { }
            this.Close();
        }
    }
}
