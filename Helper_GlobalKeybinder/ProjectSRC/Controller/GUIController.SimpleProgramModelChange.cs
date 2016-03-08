using System;
using System.Diagnostics;
using System.Windows.Forms;
using Helper_GlobalKeybinder.ProjectSRC.GUI;
using Helper_GlobalKeybinder.ProjectSRC.Model;

namespace Helper_GlobalKeybinder.ProjectSRC.Controller {
    public partial class GUIController {
        /// <summary>
        /// Called when user changes the program in the "programlist" combobox
        /// Updates all the infofields
        /// </summary>
        /// <param name="sender">The combobox</param>
        /// <param name="e">The arguments</param>
        public void SelectedProgramChanged(object sender, EventArgs e) {
            ComboBox cbox = (ComboBox)sender;
            string text = cbox.Text;
            foreach(ProgramProfile program in Model.Programs) {
                if(text == program.Name) {
                    Model.CurSelectedProgramProfile = program;
                    Model.CurExeName = program.Name;
                    break;
                }
            }
            View.UpdateProgramProfileFields(Model);
            View.UpdateProgramComboboxSelection(Model);
            //View.UpdateView(Model);
        }
        /// <summary>
        /// Called when the "Enabled" checkbox was changed
        /// </summary>
        /// <param name="sender">The "Enabled" checkbox</param>
        /// <param name="e">The arguments</param>
        public void ProgramEnabledChanged(object sender, EventArgs e) {
            //Model.CurExeEnabled = ((CheckBox)sender).Checked;
            Model.CurSelectedProgramProfile.Enabled = ((CheckBox) sender).Checked;
            //View.UpdateView(Model);
        }
        /// <summary>
        /// Called when the "ExecutableName" textfield was changed
        /// </summary>
        /// <param name="sender">The textfield</param>
        /// <param name="e">The arguments</param>
        public void ProgramExeChanged(object sender, EventArgs e) {
            Model.CurExeName = ((TextBox)sender).Text;
            //View.UpdateView(Model);
        }

        /// <summary>
        /// Opens the "ChooseProcess" dialog (modal)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OpenChooseProcessModalDialog(object sender, EventArgs e) {
            SelectProcess selectProcessDialog = new SelectProcess();
            selectProcessDialog.ShowDialog();
            if(selectProcessDialog.SelectedProcess == null) return;

            string selectedProcessName = selectProcessDialog.SelectedProcess.Name;
            Model.CurExeName = selectedProcessName;
            View.UpdateProgramProfileFields(Model);
            //View.UpdateView(Model);
        }

        /// <summary>
        /// Adds a new program to the programlist
        /// </summary>
        /// <param name="sender">The sender that fired this method</param>
        /// <param name="e">The arguments the sender specified</param>
        public void AddNewProcessConfig(object sender, EventArgs e) {
            if(string.IsNullOrEmpty(Model.CurExeName)) return;
            ProgramProfile prof = Model.CreateProgramFromData();
            Model.Programs.Add(prof);
            View.UpdateView(Model);
            Model.CurExeName = prof.Name;
            Model.CurSelectedProgramProfile = prof;
            View.UpdateProgramComboboxSelection(Model);
        }
        /// <summary>
        /// Saves the new data in the currently selected program
        /// </summary>
        /// <param name="sender">The sender that fired this method</param>
        /// <param name="e">The arguments the sender specified</param>
        public void SaveProcessConfig(object sender, EventArgs e) {
            Model.CurSelectedProgramProfile.Name = Model.CurExeName;
            View.UpdateView(Model);
        }
        /// <summary>
        /// Deletes the currently selected program from the programlist
        /// </summary>
        /// <param name="sender">The sender that fired this method</param>
        /// <param name="e">The arguments the sender specified</param>
        public void DeleteProcessConfig(object sender, EventArgs e) {
            Model.Programs.Remove(Model.CurSelectedProgramProfile);
            View.UpdateView(Model);
        }
    }
}