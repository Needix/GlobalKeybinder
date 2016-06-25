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
    public partial class CreateKeybind : Form {
        public Keybind NewKeybind { get; set; }
        public bool Save { get; set; }

        public CreateKeybind() : this(null, true) { }
        public CreateKeybind(Keybind keybind, bool createNew) {
            InitializeComponent();

            NewKeybind = new Keybind();

            if(createNew) LoadData(NewKeybind, createNew);
            else LoadData(keybind, createNew);
        }

        private void LoadData(Keybind keybind, bool createNew) {
            if (keybind == null) return;
            tb_edit_kbName.Text = keybind.Name;
            tb_edit_kbKey.Text = keybind.InputSequence.ToString();
            tb_edit_kbSequence.Text = keybind.OutputSequence.ToString();

            if (!createNew) {
                NewKeybind = keybind;
            } else {
                NewKeybind.Name = keybind.Name; //Always "" i guess
                NewKeybind.InputSequence = new GlobalHotkey(keybind.InputSequence);
                NewKeybind.OutputSequence = keybind.OutputSequence.CreateCopy();
            }
        }

        private void b_edit_configKey_Click(object sender, EventArgs e) {
            ConfigureKey configKey = new ConfigureKey();
            GlobalHotkey hotkey = configKey.OpenDialogAndCreateGlobalHotkey();
            if (hotkey != null) {
                tb_edit_kbKey.Text = hotkey.ToString();
                NewKeybind.InputSequence = hotkey;
            }
        }

        private void b_edit_sequence_Click(object sender, EventArgs e) {
            EditSequence editSequence = new EditSequence(NewKeybind.OutputSequence);
            editSequence.ShowDialog();
            if (!editSequence.Save) return;

            NewKeybind.OutputSequence.Sequence = editSequence.SendKeys;
            if (editSequence.SendKeys != null) {
                tb_edit_kbSequence.Text = NewKeybind.OutputSequence.ToString();
            }
        }

        private void b_save_Click(object sender, EventArgs e) {
            Save = true;
            this.Close();
        }

        private void tb_edit_kbName_TextChanged(object sender, EventArgs e) {
            NewKeybind.Name = ((TextBox) sender).Text;
        }
    }
}
