using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Helper_GlobalKeybinder.ProjectSRC.GUI {
    partial class GUIView {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new Container();
            this.comboBox_select_programSelect = new ComboBox();
            this.b_select_addNew = new Button();
            this.b_select_delete = new Button();
            this.listView_edit_keybinds = new ListView();
            this.columnHeader1 = ((ColumnHeader)(new ColumnHeader()));
            this.columnHeader2 = ((ColumnHeader)(new ColumnHeader()));
            this.columnHeader3 = ((ColumnHeader)(new ColumnHeader()));
            this.groupBox1 = new GroupBox();
            this.b_select_save = new Button();
            this.checkBox_select_enabled = new CheckBox();
            this.b_select_selectProcess = new Button();
            this.tb_select_exe = new TextBox();
            this.label1 = new Label();
            this.groupBox2 = new GroupBox();
            this.b_edit_sequence = new Button();
            this.b_edit_configKey = new Button();
            this.tb_edit_kbSequence = new TextBox();
            this.label4 = new Label();
            this.tb_edit_kbKey = new TextBox();
            this.label3 = new Label();
            this.tb_edit_kbName = new TextBox();
            this.label2 = new Label();
            this.b_edit_save = new Button();
            this.b_edit_addNew = new Button();
            this.b_edit_deleteSelected = new Button();
            this.toolTip = new ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox_select_programSelect
            // 
            this.comboBox_select_programSelect.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            this.comboBox_select_programSelect.FormattingEnabled = true;
            this.comboBox_select_programSelect.Location = new Point(6, 20);
            this.comboBox_select_programSelect.Name = "comboBox_select_programSelect";
            this.comboBox_select_programSelect.Size = new Size(1059, 21);
            this.comboBox_select_programSelect.TabIndex = 0;
            // 
            // b_select_addNew
            // 
            this.b_select_addNew.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
            this.b_select_addNew.Location = new Point(537, 79);
            this.b_select_addNew.Name = "b_select_addNew";
            this.b_select_addNew.Size = new Size(170, 21);
            this.b_select_addNew.TabIndex = 1;
            this.b_select_addNew.Text = "Add new program config";
            this.b_select_addNew.UseVisualStyleBackColor = true;
            // 
            // b_select_delete
            // 
            this.b_select_delete.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
            this.b_select_delete.Location = new Point(889, 79);
            this.b_select_delete.Name = "b_select_delete";
            this.b_select_delete.Size = new Size(170, 21);
            this.b_select_delete.TabIndex = 2;
            this.b_select_delete.Text = "Delete selected program config";
            this.b_select_delete.UseVisualStyleBackColor = true;
            // 
            // listView_edit_keybinds
            // 
            this.listView_edit_keybinds.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) 
            | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            this.listView_edit_keybinds.CheckBoxes = true;
            this.listView_edit_keybinds.Columns.AddRange(new ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView_edit_keybinds.FullRowSelect = true;
            this.listView_edit_keybinds.Location = new Point(6, 19);
            this.listView_edit_keybinds.MultiSelect = false;
            this.listView_edit_keybinds.Name = "listView_edit_keybinds";
            this.listView_edit_keybinds.Size = new Size(578, 320);
            this.listView_edit_keybinds.TabIndex = 3;
            this.listView_edit_keybinds.UseCompatibleStateImageBehavior = false;
            this.listView_edit_keybinds.View = View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "KeyStrokes";
            this.columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Output";
            this.columnHeader3.Width = 276;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.b_select_save);
            this.groupBox1.Controls.Add(this.checkBox_select_enabled);
            this.groupBox1.Controls.Add(this.b_select_selectProcess);
            this.groupBox1.Controls.Add(this.tb_select_exe);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.b_select_delete);
            this.groupBox1.Controls.Add(this.b_select_addNew);
            this.groupBox1.Controls.Add(this.comboBox_select_programSelect);
            this.groupBox1.Location = new Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(1071, 106);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Config select";
            // 
            // b_select_save
            // 
            this.b_select_save.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
            this.b_select_save.Location = new Point(713, 79);
            this.b_select_save.Name = "b_select_save";
            this.b_select_save.Size = new Size(170, 21);
            this.b_select_save.TabIndex = 7;
            this.b_select_save.Text = "Save program config";
            this.b_select_save.UseVisualStyleBackColor = true;
            // 
            // checkBox_select_enabled
            // 
            this.checkBox_select_enabled.AutoSize = true;
            this.checkBox_select_enabled.Location = new Point(9, 73);
            this.checkBox_select_enabled.Name = "checkBox_select_enabled";
            this.checkBox_select_enabled.Size = new Size(65, 17);
            this.checkBox_select_enabled.TabIndex = 6;
            this.checkBox_select_enabled.Text = "Enabled";
            this.checkBox_select_enabled.UseVisualStyleBackColor = true;
            // 
            // b_select_selectProcess
            // 
            this.b_select_selectProcess.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            this.b_select_selectProcess.Location = new Point(920, 45);
            this.b_select_selectProcess.Name = "b_select_selectProcess";
            this.b_select_selectProcess.Size = new Size(145, 23);
            this.b_select_selectProcess.TabIndex = 5;
            this.b_select_selectProcess.Text = "Select running process...";
            this.b_select_selectProcess.UseVisualStyleBackColor = true;
            // 
            // tb_select_exe
            // 
            this.tb_select_exe.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            this.tb_select_exe.Location = new Point(178, 47);
            this.tb_select_exe.Name = "tb_select_exe";
            this.tb_select_exe.Size = new Size(736, 20);
            this.tb_select_exe.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new Point(6, 50);
            this.label1.Name = "label1";
            this.label1.Size = new Size(167, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Executable name (i.e. \"iexplorer\"):";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) 
            | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.b_edit_sequence);
            this.groupBox2.Controls.Add(this.b_edit_configKey);
            this.groupBox2.Controls.Add(this.tb_edit_kbSequence);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.tb_edit_kbKey);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.tb_edit_kbName);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.b_edit_save);
            this.groupBox2.Controls.Add(this.b_edit_addNew);
            this.groupBox2.Controls.Add(this.b_edit_deleteSelected);
            this.groupBox2.Controls.Add(this.listView_edit_keybinds);
            this.groupBox2.Location = new Point(6, 124);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(1071, 345);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Config edit";
            // 
            // b_edit_sequence
            // 
            this.b_edit_sequence.Location = new Point(590, 287);
            this.b_edit_sequence.Name = "b_edit_sequence";
            this.b_edit_sequence.Size = new Size(475, 23);
            this.b_edit_sequence.TabIndex = 15;
            this.b_edit_sequence.Text = "Edit Sequence...";
            this.b_edit_sequence.UseVisualStyleBackColor = true;
            // 
            // b_edit_configKey
            // 
            this.b_edit_configKey.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            this.b_edit_configKey.Location = new Point(943, 39);
            this.b_edit_configKey.Name = "b_edit_configKey";
            this.b_edit_configKey.Size = new Size(122, 21);
            this.b_edit_configKey.TabIndex = 14;
            this.b_edit_configKey.Text = "Configure Key...";
            this.b_edit_configKey.UseVisualStyleBackColor = true;
            // 
            // tb_edit_kbSequence
            // 
            this.tb_edit_kbSequence.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Bottom) 
            | AnchorStyles.Right)));
            this.tb_edit_kbSequence.Location = new Point(590, 87);
            this.tb_edit_kbSequence.Multiline = true;
            this.tb_edit_kbSequence.Name = "tb_edit_kbSequence";
            this.tb_edit_kbSequence.ReadOnly = true;
            this.tb_edit_kbSequence.Size = new Size(475, 194);
            this.tb_edit_kbSequence.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new Point(590, 68);
            this.label4.Name = "label4";
            this.label4.Size = new Size(98, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Keybind sequence:";
            // 
            // tb_edit_kbKey
            // 
            this.tb_edit_kbKey.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            this.tb_edit_kbKey.Location = new Point(694, 39);
            this.tb_edit_kbKey.Name = "tb_edit_kbKey";
            this.tb_edit_kbKey.ReadOnly = true;
            this.tb_edit_kbKey.Size = new Size(243, 20);
            this.tb_edit_kbKey.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new Point(590, 42);
            this.label3.Name = "label3";
            this.label3.Size = new Size(69, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Keybind Key:";
            // 
            // tb_edit_kbName
            // 
            this.tb_edit_kbName.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            this.tb_edit_kbName.Location = new Point(694, 13);
            this.tb_edit_kbName.Name = "tb_edit_kbName";
            this.tb_edit_kbName.Size = new Size(371, 20);
            this.tb_edit_kbName.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new Point(590, 16);
            this.label2.Name = "label2";
            this.label2.Size = new Size(77, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Keybind name:";
            // 
            // b_edit_save
            // 
            this.b_edit_save.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
            this.b_edit_save.Location = new Point(755, 316);
            this.b_edit_save.Name = "b_edit_save";
            this.b_edit_save.Size = new Size(151, 23);
            this.b_edit_save.TabIndex = 6;
            this.b_edit_save.Text = "Save edited keybind";
            this.b_edit_save.UseVisualStyleBackColor = true;
            // 
            // b_edit_addNew
            // 
            this.b_edit_addNew.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
            this.b_edit_addNew.Location = new Point(590, 316);
            this.b_edit_addNew.Name = "b_edit_addNew";
            this.b_edit_addNew.Size = new Size(159, 23);
            this.b_edit_addNew.TabIndex = 5;
            this.b_edit_addNew.Text = "Add as new keybind";
            this.b_edit_addNew.UseVisualStyleBackColor = true;
            // 
            // b_edit_deleteSelected
            // 
            this.b_edit_deleteSelected.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
            this.b_edit_deleteSelected.Location = new Point(912, 316);
            this.b_edit_deleteSelected.Name = "b_edit_deleteSelected";
            this.b_edit_deleteSelected.Size = new Size(153, 23);
            this.b_edit_deleteSelected.TabIndex = 4;
            this.b_edit_deleteSelected.Text = "Delete selected keybind";
            this.b_edit_deleteSelected.UseVisualStyleBackColor = true;
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 10000;
            this.toolTip.InitialDelay = 0;
            this.toolTip.ReshowDelay = 100;
            // 
            // GUIView
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1095, 481);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MinimumSize = new Size(610, 350);
            this.Name = "GUIView";
            this.Text = "GUIView";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ComboBox comboBox_select_programSelect;
        private Button b_select_addNew;
        private Button b_select_delete;
        private ListView listView_edit_keybinds;
        private GroupBox groupBox1;
        private CheckBox checkBox_select_enabled;
        private Button b_select_selectProcess;
        private TextBox tb_select_exe;
        private Label label1;
        private GroupBox groupBox2;
        private Button b_edit_save;
        private Button b_edit_addNew;
        private Button b_edit_deleteSelected;
        private TextBox tb_edit_kbSequence;
        private Label label4;
        private TextBox tb_edit_kbKey;
        private Label label3;
        private TextBox tb_edit_kbName;
        private Label label2;
        private Button b_select_save;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ToolTip toolTip;
        private Button b_edit_configKey;
        private Button b_edit_sequence;
    }
}