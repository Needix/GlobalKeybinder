using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using Helper_GlobalKeybinder.ProjectSRC.Model;

namespace Helper_GlobalKeybinder.ProjectSRC.GUI {
    public partial class EditSequence : Form {
        public List<GlobalHotkey> SendKeys { get; private set; } 
        public bool Save;
        
        public EditSequence(OutputSequence selectedKeybind) {
            InitializeComponent();

            LoadData(selectedKeybind);

            if(SendKeys == null) SendKeys = new List<GlobalHotkey>();
        }

        private void LoadData(OutputSequence sequence) {
            /*
            List<GlobalHotkey> newListe = new List<GlobalHotkey>();
            foreach (GlobalHotkey globalHotkey in sequence.Sequence) {
                newListe.Add(new GlobalHotkey(globalHotkey));
            }
            SendKeys = newListe;
            */
            SendKeys = sequence.Sequence;
            if (SendKeys == null) return;
            foreach (GlobalHotkey hotkey in SendKeys) {
                listBox_keys.Items.Add(hotkey);
            }
        }

        private void b_moveDown_Click(object sender, EventArgs e) {
            int index = listBox_keys.SelectedIndex;
            if(index == -1 || index >= listBox_keys.Items.Count || index+1 >= listBox_keys.Items.Count) return;
            
            GlobalHotkey hotkey = SendKeys[index];
            SendKeys.RemoveAt(index);
            SendKeys.Insert(index + 1, hotkey);

            object selChar = listBox_keys.Items[index];
            listBox_keys.Items.RemoveAt(index);
            listBox_keys.Items.Insert(index+1, selChar);
            listBox_keys.SelectedIndex = index + 1;
        }

        private void b_moveUp_Click(object sender, EventArgs e) {
            int index = listBox_keys.SelectedIndex;
            if(index == -1 || index >= listBox_keys.Items.Count || index == 0 ) return;
            
            GlobalHotkey hotkey = SendKeys[index];
            SendKeys.RemoveAt(index);
            SendKeys.Insert(index - 1, hotkey);

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

            SendKeys.RemoveAt(index);
            listBox_keys.Items.RemoveAt(index);
        }

        private void b_edit_keyEdit_Click(object sender, EventArgs e) {
            ConfigureKey key = new ConfigureKey();
            GlobalHotkey hotkey = key.CreateGlobalHotkeyFromConfigKey();

            if (hotkey == null) return;
            SendKeys.Add(hotkey);
            listBox_keys.Items.Add(hotkey);
        }

        private void b_addText_Click(object sender, EventArgs e) {
            AddText();
        }

        private void b_addTextWithDelay_Click(object sender, EventArgs e) {
            AddText(GetDelay());
        }

        private void AddText(int delay = -1) {
            string text = tb_addText.Text;
            Debug.WriteLine("Adding text: "+text+" with delay: "+delay);
            GlobalHotkey hotkey = new GlobalHotkey(text, delay);
            SendKeys.Add(hotkey);
            listBox_keys.Items.Add(hotkey);
        }
        
        private int GetDelay() {
            try {
                int delay = Convert.ToInt32(tb_delay.Text);
                if (delay < -1) delay = -1;
                return delay;
            }
            catch (FormatException) {
                return -1;
            }
        }

        private void b_addDelayToSelected_Click(object sender, EventArgs e) {
            int delay = GetDelay();
            if (delay == -1) return;
            if (listBox_keys.SelectedIndex == -1) {
                SendKeys.Add(new GlobalHotkey(delay));
                ReaddAllItems();
            } else {
                ((GlobalHotkey)listBox_keys.Items[listBox_keys.SelectedIndex]).Delay = delay;
                ReaddAllItems();
            }
        }

        private void ReaddAllItems() {
            listBox_keys.Items.Clear();
            foreach (GlobalHotkey hotkey in SendKeys) {
                listBox_keys.Items.Add(hotkey);
            }
        }

        private void b_unselect_Click(object sender, EventArgs e) {
            listBox_keys.SelectedIndices.Clear();
        }
    }
}
