using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using Helper_GlobalKeybinder.ProjectSRC.GUI;
using Helper_GlobalKeybinder.ProjectSRC.Model;

namespace Helper_GlobalKeybinder.ProjectSRC.Controller {
    public partial class GUIController {
        /// <summary>
        /// Changes the model data of the KB text fields
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void KBTextChanged(object sender, EventArgs e) {
            TextBox tb = (TextBox)sender;
            string tbText = tb.Text;
            switch(tb.Name) {
                case "tb_edit_kbName":
                    Model.CurKBName = tbText;
                    break;
            }
        }
        /// <summary>
        /// Reacts to KB button clicks
        /// </summary>
        /// <param name="sender">A KB button</param>
        /// <param name="e"></param>
        public void KBButtonClick(object sender, EventArgs e) {
            Button b = (Button)sender;
            ProgramProfile curProgramProfile = Model.CurSelectedProgramProfile;
            if (curProgramProfile == null) return;
            switch(b.Name) {
                case "b_edit_addNew":
                    Keybind newBind = Model.CreateKeyBindFromData();
                    if (newBind == null) return;
                    curProgramProfile.Keybinds.Add(newBind);
                    //newBind.InputSequence.Register();
                    Model.CurSelectedKeybind = newBind;
                    break;
                case "b_edit_deleteSelected":
                    Keybind deleteBind = Model.CurSelectedKeybind;
                    deleteBind.Enabled = false;
                    //deleteBind.InputSequence.Unregister();
                    curProgramProfile.Keybinds.Remove(deleteBind);
                    Model.CurSelectedKeybind = null;
                    ResetKBData();
                    View.UpdateViewKeybindFieldsFromModelKeybindFields(Model);
                    break;
                case "b_edit_save":
                    Keybind curKB = Model.CurSelectedKeybind;
                    if(curKB == null) return;
                    curKB.Name = Model.CurKBName;
                    curKB.InputSequence = Model.CurKBInput;
                    curKB.OutputSequence = Model.CurKBOutput;
                    break;
            }
            View.UpdateKeybindListViewItems(Model);
        }

        public void SelectedKBChanged(object sender, EventArgs e) {
            ListView lv = (ListView)sender;
            ListView.SelectedIndexCollection col = lv.SelectedIndices;
            if(col.Count == 0) return;
            if (Model.CurSelectedProgramProfile == null) return;
            Model.CurSelectedKeybind = Model.CurSelectedProgramProfile.Keybinds[col[0]];
            Model.CurKBInput = Model.CurSelectedKeybind.InputSequence;
            Model.CurKBName = Model.CurSelectedKeybind.Name;
            Model.CurKBOutput = Model.CurSelectedKeybind.OutputSequence;
            View.UpdateViewKeybindFieldsFromSelectedKeybind(Model);
        }

        public void OpenConfigKeyModalDialog(object sender, EventArgs e) {
            if(Model.CurSelectedProgramProfile == null) {
                MessageBox.Show("No program selected!");
                return;
            }

            ConfigureKey form = new ConfigureKey();
            GlobalHotkey hotkey = form.CreateGlobalHotkeyFromConfigKey();
            if(hotkey!=null) Model.CurKBInput = hotkey;

            View.UpdateViewKeybindFieldsFromModelKeybindFields(Model);
        }

        public void OpenConfigSequenceModalDialog(object sender, EventArgs e) {
            OutputSequence seq = new OutputSequence();
            if (Model.CurSelectedKeybind != null) seq = Model.CurSelectedKeybind.OutputSequence;
            EditSequence dialog = new EditSequence(seq);
            dialog.ShowDialog();
            if(!dialog.Save) return;

            List<GlobalHotkey> chars = dialog.SendKeys;
            Model.CurKBOutput = new OutputSequence(chars);
            View.UpdateViewKeybindFieldsFromModelKeybindFields(Model);
        }

        public void KB_LV_ItemChecked(object sender, ItemCheckedEventArgs e) {
            if (Model.CurSelectedKeybind == null) return;
            Model.CurSelectedKeybind.Enabled = e.Item.Checked;
        }
    }
}