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
            this.components = new System.ComponentModel.Container();
            this.b_select_createNew = new System.Windows.Forms.Button();
            this.b_select_delete = new System.Windows.Forms.Button();
            this.listView_edit_keybinds = new System.Windows.Forms.ListView();
            this.columnHeader0 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.b_select_unselect = new System.Windows.Forms.Button();
            this.listBox_profiles = new System.Windows.Forms.ListBox();
            this.b_select_edit = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.b_edit_unselect = new System.Windows.Forms.Button();
            this.b_edit_edit = new System.Windows.Forms.Button();
            this.b_edit_addNew = new System.Windows.Forms.Button();
            this.b_edit_deleteSelected = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // b_select_createNew
            // 
            this.b_select_createNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.b_select_createNew.Location = new System.Drawing.Point(262, 19);
            this.b_select_createNew.Name = "b_select_createNew";
            this.b_select_createNew.Size = new System.Drawing.Size(170, 21);
            this.b_select_createNew.TabIndex = 1;
            this.b_select_createNew.Text = "Create new program config";
            this.b_select_createNew.UseVisualStyleBackColor = true;
            // 
            // b_select_delete
            // 
            this.b_select_delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.b_select_delete.Location = new System.Drawing.Point(262, 73);
            this.b_select_delete.Name = "b_select_delete";
            this.b_select_delete.Size = new System.Drawing.Size(170, 21);
            this.b_select_delete.TabIndex = 2;
            this.b_select_delete.Text = "Delete selected program config";
            this.b_select_delete.UseVisualStyleBackColor = true;
            // 
            // listView_edit_keybinds
            // 
            this.listView_edit_keybinds.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView_edit_keybinds.CheckBoxes = true;
            this.listView_edit_keybinds.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader0,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView_edit_keybinds.FullRowSelect = true;
            this.listView_edit_keybinds.HideSelection = false;
            this.listView_edit_keybinds.Location = new System.Drawing.Point(6, 19);
            this.listView_edit_keybinds.MultiSelect = false;
            this.listView_edit_keybinds.Name = "listView_edit_keybinds";
            this.listView_edit_keybinds.Size = new System.Drawing.Size(700, 456);
            this.listView_edit_keybinds.TabIndex = 3;
            this.listView_edit_keybinds.UseCompatibleStateImageBehavior = false;
            this.listView_edit_keybinds.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader0
            // 
            this.columnHeader0.Text = "ID";
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
            this.groupBox1.Controls.Add(this.b_select_unselect);
            this.groupBox1.Controls.Add(this.listBox_profiles);
            this.groupBox1.Controls.Add(this.b_select_edit);
            this.groupBox1.Controls.Add(this.b_select_delete);
            this.groupBox1.Controls.Add(this.b_select_createNew);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(438, 481);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Config select";
            // 
            // b_select_unselect
            // 
            this.b_select_unselect.Location = new System.Drawing.Point(262, 100);
            this.b_select_unselect.Name = "b_select_unselect";
            this.b_select_unselect.Size = new System.Drawing.Size(170, 23);
            this.b_select_unselect.TabIndex = 9;
            this.b_select_unselect.Text = "Unselect";
            this.b_select_unselect.UseVisualStyleBackColor = true;
            // 
            // listBox_profiles
            // 
            this.listBox_profiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox_profiles.FormattingEnabled = true;
            this.listBox_profiles.Location = new System.Drawing.Point(9, 19);
            this.listBox_profiles.Name = "listBox_profiles";
            this.listBox_profiles.Size = new System.Drawing.Size(247, 459);
            this.listBox_profiles.TabIndex = 8;
            // 
            // b_select_edit
            // 
            this.b_select_edit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.b_select_edit.Location = new System.Drawing.Point(262, 46);
            this.b_select_edit.Name = "b_select_edit";
            this.b_select_edit.Size = new System.Drawing.Size(170, 21);
            this.b_select_edit.TabIndex = 7;
            this.b_select_edit.Text = "Edit selected program config";
            this.b_select_edit.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.b_edit_unselect);
            this.groupBox2.Controls.Add(this.b_edit_edit);
            this.groupBox2.Controls.Add(this.b_edit_addNew);
            this.groupBox2.Controls.Add(this.b_edit_deleteSelected);
            this.groupBox2.Controls.Add(this.listView_edit_keybinds);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(877, 481);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Config edit";
            // 
            // b_edit_unselect
            // 
            this.b_edit_unselect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.b_edit_unselect.Location = new System.Drawing.Point(712, 106);
            this.b_edit_unselect.Name = "b_edit_unselect";
            this.b_edit_unselect.Size = new System.Drawing.Size(159, 23);
            this.b_edit_unselect.TabIndex = 7;
            this.b_edit_unselect.Text = "Unselect";
            this.b_edit_unselect.UseVisualStyleBackColor = true;
            // 
            // b_edit_edit
            // 
            this.b_edit_edit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.b_edit_edit.Location = new System.Drawing.Point(712, 48);
            this.b_edit_edit.Name = "b_edit_edit";
            this.b_edit_edit.Size = new System.Drawing.Size(159, 23);
            this.b_edit_edit.TabIndex = 6;
            this.b_edit_edit.Text = "Edit selected keybind";
            this.b_edit_edit.UseVisualStyleBackColor = true;
            // 
            // b_edit_addNew
            // 
            this.b_edit_addNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.b_edit_addNew.Location = new System.Drawing.Point(712, 19);
            this.b_edit_addNew.Name = "b_edit_addNew";
            this.b_edit_addNew.Size = new System.Drawing.Size(159, 23);
            this.b_edit_addNew.TabIndex = 5;
            this.b_edit_addNew.Text = "Create new keybind";
            this.b_edit_addNew.UseVisualStyleBackColor = true;
            // 
            // b_edit_deleteSelected
            // 
            this.b_edit_deleteSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.b_edit_deleteSelected.Location = new System.Drawing.Point(712, 77);
            this.b_edit_deleteSelected.Name = "b_edit_deleteSelected";
            this.b_edit_deleteSelected.Size = new System.Drawing.Size(159, 23);
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
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(1319, 481);
            this.splitContainer1.SplitterDistance = 438;
            this.splitContainer1.TabIndex = 6;
            // 
            // GUIView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1319, 481);
            this.Controls.Add(this.splitContainer1);
            this.MinimumSize = new System.Drawing.Size(610, 350);
            this.Name = "GUIView";
            this.Text = "GUIView";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Button b_select_createNew;
        private Button b_select_delete;
        private ListView listView_edit_keybinds;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button b_edit_edit;
        private Button b_edit_addNew;
        private Button b_edit_deleteSelected;
        private Button b_select_edit;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ToolTip toolTip;
        private ColumnHeader columnHeader0;
        private ListBox listBox_profiles;
        private SplitContainer splitContainer1;
        private Button b_select_unselect;
        private Button b_edit_unselect;
    }
}