using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Helper_GlobalKeybinder.ProjectSRC.Model;

namespace Helper_GlobalKeybinder.ProjectSRC.GUI {
    public partial class CreateNewConfig : Form {
        public ProgramProfile NewProfile { get; private set; }
        public bool Save { get; set; }

        public CreateNewConfig() : this(null, true) {}

        public CreateNewConfig(ProgramProfile selectedProfile, bool createNew) {
            InitializeComponent();

            NewProfile = new ProgramProfile();

            if(createNew) LoadData(NewProfile, createNew);
            else LoadData(selectedProfile, createNew);
        }

        private void LoadData(ProgramProfile profile, bool createNew) {
            if (profile == null) return;
            cbox_config_singleSend.Checked = profile.SingleSend;
            checkBox_select_enabled.Checked = profile.Enabled;
            tb_select_exe.Text = profile.Name;

            if (!createNew) {
                NewProfile = profile;
            } else {
                NewProfile.Name = profile.Name;
                NewProfile.Enabled = profile.Enabled;
                NewProfile.SingleSend = profile.SingleSend;
                NewProfile.Keybinds = profile.Keybinds;
            }
        }

        private void b_select_selectProcess_Click(object sender, EventArgs e) {
            SelectProcess selectProcessDialog = new SelectProcess();
            selectProcessDialog.ShowDialog();
            if (selectProcessDialog.SelectedProcess == null) return;

            string selectedProcessName = selectProcessDialog.SelectedProcess.Name;
            NewProfile.Name = selectedProcessName;
            tb_select_exe.Text = selectedProcessName;
        }

        private void b_createSave_Click(object sender, EventArgs e) {
            Save = true;
            this.Close();
        }

        private void tb_select_exe_TextChanged(object sender, EventArgs e) {
            NewProfile.Name = ((TextBox) sender).Text;
        }

        private void checkBox_select_enabled_CheckedChanged(object sender, EventArgs e) {
            NewProfile.Enabled = ((CheckBox) sender).Checked;
        }

        private void cbox_config_singleSend_CheckedChanged(object sender, EventArgs e) {
            NewProfile.SingleSend = ((CheckBox) sender).Checked;
        }
    }
}
