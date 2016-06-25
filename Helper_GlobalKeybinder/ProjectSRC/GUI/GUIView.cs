// GUIView.cs
// Copyright 2015
// 
// Project Lead: Need
// Contact:      
//     Mail:     mailto:needdragon@gmail.com 
//     Twitter: https://twitter.com/NeedDragon

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;
using Helper_GlobalKeybinder.ProjectSRC.Controller;
using Helper_GlobalKeybinder.ProjectSRC.Model;

namespace Helper_GlobalKeybinder.ProjectSRC.GUI {
    public partial class GUIView : Form {
        public static GUIView Instance;
        private GUIController _controller;

        public GUIView() {
            Instance = this;
            InitializeComponent();
        }
        
        /// <summary>
        /// Used to register all gui events
        /// </summary>
        private void RegisterCustomEvents() {
            this.Closing += CloseForm;
            this.Closing += _controller.Serializer.Save;

            b_select_createNew.Click += _controller.FormMainButtonControl;
            b_select_delete.Click += _controller.FormMainButtonControl;
            b_select_edit.Click += _controller.FormMainButtonControl;
            b_select_unselect.Click += _controller.FormMainButtonControl;
            b_edit_addNew.Click += _controller.FormMainButtonControl;
            b_edit_deleteSelected.Click += _controller.FormMainButtonControl;
            b_edit_edit.Click += _controller.FormMainButtonControl;
            b_edit_unselect.Click += _controller.FormMainButtonControl;

            listBox_profiles.SelectedIndexChanged += _controller.ProfilesSelectedIndexChanged;
            listView_edit_keybinds.SelectedIndexChanged += _controller.SelectedKeyBindChanged;
            listView_edit_keybinds.ColumnWidthChanged += ListViewKBColumnWidthChanged;
            listView_edit_keybinds.ItemChecked += _controller.KeyBind_ListView_ItemChecked;
        }

        /// <summary>
        /// Registers the controller with this view
        /// </summary>
        /// <param name="controller">The controller to register</param>
        public void RegisterController(GUIController controller) {
            _controller = controller;
            RegisterCustomEvents();
        }
        
        //TODO: Add keydown, keyup to view (so user can decide for themselves)
        //TODO: Improve "press key" gui (mouse (special popup?))

        /// <summary>
        /// Updates all visuals in the gui
        /// </summary>
        /// <param name="model">The GUIModel to use</param>
        public void UpdateView(GUIModel model) {
            UpdateProgramProfile(model);
            UpdateKeybinds(model);
            _controller.Save();
        }

        public void UpdateProgramProfile(GUIModel model) {
            listBox_profiles.Items.Clear();
            foreach (ProgramProfile programProfile in model.Programs) {
                listBox_profiles.Items.Add(programProfile);
            }
            if(model.CurSelectedProgramProfile!=null) listBox_profiles.SelectedIndex = listBox_profiles.Items.IndexOf(model.CurSelectedProgramProfile);
        }
        
        public void UpdateKeybinds(GUIModel model) {
            ListView.SelectedIndexCollection col = listView_edit_keybinds.SelectedIndices;
            ListViewItem selectedItem = null;
            if (col.Count > 0) selectedItem = listView_edit_keybinds.Items[col[0]];
            listView_edit_keybinds.Items.Clear();

            if(model.CurSelectedProgramProfile != null) {
                foreach(Keybind keybind in model.CurSelectedProgramProfile.Keybinds) {
                    listView_edit_keybinds.Items.Add(keybind.ID+"")
                    .SubItems.AddRange( 
                        new[] {
                            keybind.Name,
                            keybind.InputSequence.ToString(),
                            keybind.OutputSequence.ToString()
                        }
                    );
                    listView_edit_keybinds.Items[listView_edit_keybinds.Items.Count - 1].Checked = keybind.Enabled;
                }
                if(listView_edit_keybinds.Items.Count != 0) listView_edit_keybinds.Columns[1].Width = -1;
            }

            if (selectedItem != null) {
                for (int i = 0; i < listView_edit_keybinds.Items.Count; i++) {
                    ListViewItem curItem = listView_edit_keybinds.Items[i];
                    if (curItem.Text == selectedItem.Text) {
                        listView_edit_keybinds.SelectedIndices.Add(i);
                        break;
                    }
                }
            }
        }
        
        private void CloseForm(object sender, CancelEventArgs e) {
            _controller.Close();
        }

        private const int _minimumColumnWidth = 50;
        public void ListViewKBColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e) {
            if (listView_edit_keybinds.Columns[e.ColumnIndex].Width < _minimumColumnWidth) {
                listView_edit_keybinds.Columns[e.ColumnIndex].Width = _minimumColumnWidth;
            }
        }
    }
}
