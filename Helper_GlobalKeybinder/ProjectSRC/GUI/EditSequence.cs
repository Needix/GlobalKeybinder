using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Helper_GlobalKeybinder.ProjectSRC.Model;

namespace Helper_GlobalKeybinder.ProjectSRC.GUI {
    public partial class EditSequence : Form {
        public List<GlobalHotkey> Hotkeys { get; private set; } 
        public bool Save;

        public EditSequence() {
            InitializeComponent();
            Hotkeys = new List<GlobalHotkey>();
        }

        //TODO: Add "SendText" option (multiple characters)

        private void b_moveDown_Click(object sender, EventArgs e) {
            int index = listBox_keys.SelectedIndex;
            if(index == -1 || index >= listBox_keys.Items.Count || index+1 >= listBox_keys.Items.Count) return;
            
            GlobalHotkey hotkey = Hotkeys[index];
            Hotkeys.RemoveAt(index);
            Hotkeys.Insert(index + 1, hotkey);

            object selChar = listBox_keys.Items[index];
            listBox_keys.Items.RemoveAt(index);
            listBox_keys.Items.Insert(index+1, selChar);
            listBox_keys.SelectedIndex = index + 1;
        }

        private void b_moveUp_Click(object sender, EventArgs e) {
            int index = listBox_keys.SelectedIndex;
            if(index == -1 || index >= listBox_keys.Items.Count || index == 0 ) return;
            
            GlobalHotkey hotkey = Hotkeys[index];
            Hotkeys.RemoveAt(index);
            Hotkeys.Insert(index - 1, hotkey);

            object selChar = listBox_keys.Items[index];
            listBox_keys.Items.RemoveAt(index);
            listBox_keys.Items.Insert(index-1, selChar);
            listBox_keys.SelectedIndex = index - 1;
        }

        private void b_save_Click(object sender, EventArgs e) {
            Save = true;
            this.Close();
        }

        private void b_remove_Click(object sender, EventArgs e) {
            int index = listBox_keys.SelectedIndex;
            if(index == -1 || index>=listBox_keys.Items.Count) return;

            Hotkeys.RemoveAt(index);
            listBox_keys.Items.RemoveAt(index);
        }

        private void b_edit_keyEdit_Click(object sender, EventArgs e) {
            ConfigureKey key = new ConfigureKey();
            key.ShowDialog();
            if(!key.Save) return;

            GlobalHotkey hotkey = new GlobalHotkey(GlobalHotkey.CalcModifier(key.Shift, key.Alt, key.Control), key.SelectedChar, GUIView.Instance);
            Hotkeys.Add(hotkey);
            listBox_keys.Items.Add(hotkey);
        }

        private void b_addText_Click(object sender, EventArgs e) {
            string text = textBox1.Text;
            GlobalHotkey hotkey = new GlobalHotkey(text.ToCharArray(), GUIView.Instance);
            Hotkeys.Add(hotkey);
            listBox_keys.Items.Add(hotkey);
        }
    }
}
