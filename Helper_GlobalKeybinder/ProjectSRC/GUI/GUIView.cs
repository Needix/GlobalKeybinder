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

            //toolTip.Show("Press this button once. After that press any non-printable character. The character will be copied to your clipboard so you can use it.", b_edit_addNonPrintableCharacter);
        }

        /// <summary>
        /// Used to register all gui events
        /// </summary>
        private void RegisterCustomEvents() {
            //this.Closing += _controller.Serializer.Save;

            b_select_selectProcess.Click += _controller.OpenChooseProcessModalDialog;
            b_edit_configKey.Click += _controller.OpenConfigKeyModalDialog;
            b_select_addNew.Click += _controller.AddNewProcessConfig;
            b_select_save.Click += _controller.SaveProcessConfig;
            b_select_delete.Click += _controller.DeleteProcessConfig;
            tb_select_exe.TextChanged += _controller.ProgramExeChanged;
            comboBox_select_programSelect.SelectedIndexChanged += _controller.SelectedProgramChanged;
            checkBox_select_enabled.CheckedChanged += _controller.ProgramEnabledChanged;

            tb_edit_kbName.TextChanged += _controller.KBTextChanged;
            tb_edit_kbKey.TextChanged += _controller.KBTextChanged;
            tb_edit_kbSequence.TextChanged += _controller.KBTextChanged;
            listView_edit_keybinds.SelectedIndexChanged += _controller.SelectedKBChanged;
            listView_edit_keybinds.ColumnWidthChanged += ListViewKBColumnWidthChanged;
            listView_edit_keybinds.ItemChecked += _controller.KB_LV_ItemChecked;
            b_edit_sequence.Click += _controller.OpenConfigSequenceModalDialog;
            b_edit_deleteSelected.Click += _controller.KBButtonClick;
            b_edit_save.Click += _controller.KBButtonClick;
            b_edit_addNew.Click += _controller.KBButtonClick;
        }
        
        private const int _minimumColumnWidth = 50;
        public void ListViewKBColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e) {
            if(listView_edit_keybinds.Columns[e.ColumnIndex].Width < _minimumColumnWidth) {
                listView_edit_keybinds.Columns[e.ColumnIndex].Width = _minimumColumnWidth;
            }
        }

        /// <summary>
        /// Registers the controller with this view
        /// </summary>
        /// <param name="controller">The controller to register</param>
        public void RegisterController(GUIController controller) {
            _controller = controller;
            RegisterCustomEvents();
        }
        
        /// <summary>
        /// Updates all visuals in the gui
        /// </summary>
        /// <param name="model">The GUIModel to use</param>
        public void UpdateView(GUIModel model) {
            UpdateProgramProfileListItems(model);
            
            UpdateProgramProfileFields(model);
            
            UpdateKeybindFields(model);
            UpdateKeybindListViewItems(model);
        }

        public void UpdateProgramProfileListItems(GUIModel model) {
            object selectedComboBoxEntry = comboBox_select_programSelect.SelectedItem;
            comboBox_select_programSelect.Items.Clear();
            foreach(ProgramProfile program in model.Programs) {
                comboBox_select_programSelect.Items.Add(program);
            }
            comboBox_select_programSelect.SelectedItem = selectedComboBoxEntry;
        }
        /// <summary>
        /// Automatically tries to select the entry in the combobox with matches CurExeName (useful for automatically selecting newly added element)
        /// </summary>
        /// <param name="model">The GUIModel to use</param>
        public void UpdateProgramComboboxSelection(GUIModel model) {
            foreach(object item in comboBox_select_programSelect.Items) {
                if(((ProgramProfile)item).ToString() == model.CurExeName) {
                    comboBox_select_programSelect.SelectedIndex =
                        comboBox_select_programSelect.FindStringExact(model.CurExeName);
                    return;
                }
            }
        }
        public void UpdateProgramProfileFields(GUIModel model) {
            tb_select_exe.Text = model.CurExeName;
            if(model.CurSelectedProgramProfile != null) checkBox_select_enabled.Checked = model.CurSelectedProgramProfile.Enabled;
        }

        private void UpdateKeybindFields(GUIModel model) {
            if(model.CurKBInput != null) tb_edit_kbKey.Text = model.CurKBInput.ToString();
            if(model.CurKBOutput != null) tb_edit_kbSequence.Lines = model.CurKBOutput.ToString().Split('\n');
        }
        private void UpdateKeybindListViewItems(GUIModel model) {
            listView_edit_keybinds.Items.Clear();
            if(model.CurSelectedProgramProfile != null) {
                foreach(Keybind keybind in model.CurSelectedProgramProfile.Keybinds) {
                    listView_edit_keybinds.Items.Add(keybind.Name)
                        .SubItems.AddRange(new[] {
                            keybind.InputSequence.ToString(),
                            keybind.OutputSequence.ToString()
                        }
                        );
                    listView_edit_keybinds.Items[listView_edit_keybinds.Items.Count - 1].Checked = keybind.Enabled;
                }
                if(listView_edit_keybinds.Items.Count != 0) listView_edit_keybinds.Columns[0].Width = -1; //TODO: Is this really good?
            }
        }

        protected override void OnClosing(CancelEventArgs e) {
            base.OnClosing(e);

            _controller.Close();

            foreach(ProgramProfile programProfile in _controller.Model.Programs) {
                foreach(Keybind keybind in programProfile.Keybinds) {
                    //keybind.InputSequence.Unregister();
                }
            }
        }

        /*
        protected override void WndProc(ref Message m) {
	        if (m.Msg == GUIController.WM_HOTKEY_MSG_ID) _controller.HandleHotkey(m.LParam);
	        base.WndProc(ref m);
	    }
        */
    }
}
