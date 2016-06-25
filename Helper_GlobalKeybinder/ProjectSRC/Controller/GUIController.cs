// GUIController.cs
// Copyright 2015
// 
// Project Lead: Need
// Contact:      
//     Mail:     mailto:needdragon@gmail.com 
//     Twitter: https://twitter.com/NeedDragon

using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using Helper_GlobalKeybinder.ProjectSRC.GUI;
using Helper_GlobalKeybinder.ProjectSRC.Model;

namespace Helper_GlobalKeybinder.ProjectSRC.Controller {
    public partial class GUIController {
        public static GUIController Instance;
        public GUIView View { get; set; }
        public Serializer Serializer { get; private set; }
        public GUIModel Model { get; set; }

        private Keybinder Keybinder { get; set; }

        public GUIController(GUIView view) {
            Instance = this;
            Serializer = new Serializer(this);
            Model = Serializer.Deserialize();
            if(Model == null) Model = new GUIModel();
            
            View = view;
            view.RegisterController(this);
            View.UpdateView(Model);

            Keybinder = new Keybinder(this);
            Keybinder.StartHook();
        }

        public void Save() {
            Serializer.Serialize(Model);
        }

        public void FormMainButtonControl(object sender, EventArgs e) {
            Button b = sender as Button;
            switch (b.Name) {
                case "b_select_createNew":
                    CreateNewConfig form1 = new CreateNewConfig();
                    form1.ShowDialog();
                    if (form1.Save) {
                        ProgramProfile profile = form1.NewProfile;
                        Model.Programs.Add(profile);
                        Model.CurSelectedProgramProfile = profile;
                    }
                    break;
                case "b_select_delete":
                    Model.Programs.Remove(Model.CurSelectedProgramProfile);
                    break;
                case "b_select_edit":
                    if (Model.CurSelectedProgramProfile == null) return;
                    CreateNewConfig form3 = new CreateNewConfig(Model.CurSelectedProgramProfile, false);
                    form3.ShowDialog();
                    if (form3.Save) {
                        ProgramProfile profile = form3.NewProfile;
                        Model.CurSelectedProgramProfile = profile;
                    }
                    break;
                case "b_select_unselect":
                    Model.CurSelectedProgramProfile = null;
                    break;
                case "b_edit_addNew":
                    if (Model.CurSelectedProgramProfile == null) return;
                    CreateKeybind form4 = new CreateKeybind();
                    form4.ShowDialog();
                    if (form4.Save) {
                        Keybind newKeybind = form4.NewKeybind;
                        Debug.WriteLine("Keybind is: " + newKeybind.Name+"/"+newKeybind.Enabled+"/"+newKeybind.ID+"/"+newKeybind.InputSequence.ToString()+"/"+newKeybind.OutputSequence.ToString());
                        Model.CurSelectedProgramProfile.Keybinds.Add(newKeybind);
                        Model.CurSelectedKeybind = newKeybind;
                    }
                    break;
                case "b_edit_deleteSelected":
                    if (Model.CurSelectedProgramProfile == null) return;
                    Model.CurSelectedProgramProfile.Keybinds.Remove(Model.CurSelectedKeybind);
                    break;
                case "b_edit_edit":
                    if (Model.CurSelectedProgramProfile == null) return;
                    CreateKeybind form5 = new CreateKeybind(Model.CurSelectedKeybind, false);
                    form5.ShowDialog();
                    if (form5.Save) {
                        Keybind newKeybind = form5.NewKeybind;
                        Model.CurSelectedKeybind = newKeybind;
                    }
                    break;
                case "b_edit_unselect":
                    Model.CurSelectedKeybind = null;
                    break;
            }
            View.UpdateView(Model);
        }

        public void SelectedKeyBindChanged(object sender, EventArgs e) {
            ListView lv = (ListView)sender;
            ListView.SelectedIndexCollection col = lv.SelectedIndices;
            if (col.Count == 0) return;
            if (Model.CurSelectedProgramProfile == null) return;
            Model.CurSelectedKeybind = Model.CurSelectedProgramProfile.Keybinds[col[0]];
        }

        public void KeyBind_ListView_ItemChecked(object sender, ItemCheckedEventArgs e) {
            if (Model.CurSelectedKeybind == null) return;
            Model.CurSelectedKeybind.Enabled = e.Item.Checked;
        }

        public void Close() {
            Keybinder.Close();
        }

        public void ProfilesSelectedIndexChanged(object sender, EventArgs e) {
            ListBox lb = sender as ListBox;
            if (lb == null) return;
            int selectedIndex = lb.SelectedIndex;
            if (selectedIndex == -1) return;
            Model.CurSelectedProgramProfile = Model.Programs[selectedIndex];
            View.UpdateKeybinds(Model);
        }
    }
}