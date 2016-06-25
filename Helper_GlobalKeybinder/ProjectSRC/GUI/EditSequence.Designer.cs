namespace Helper_GlobalKeybinder.ProjectSRC.GUI {
    partial class EditSequence {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.label1 = new System.Windows.Forms.Label();
            this.listBox_keys = new System.Windows.Forms.ListBox();
            this.b_moveUp = new System.Windows.Forms.Button();
            this.b_moveDown = new System.Windows.Forms.Button();
            this.b_remove = new System.Windows.Forms.Button();
            this.b_save = new System.Windows.Forms.Button();
            this.b_edit_keyEdit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_addText = new System.Windows.Forms.TextBox();
            this.b_addText = new System.Windows.Forms.Button();
            this.b_addTextWithDelay = new System.Windows.Forms.Button();
            this.b_addDelayToSelected = new System.Windows.Forms.Button();
            this.tb_delay = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.b_unselect = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(469, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Press this key once. After that press any key to add it to the list. Press it a s" +
    "econd time to cancel it:";
            // 
            // listBox_keys
            // 
            this.listBox_keys.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox_keys.FormattingEnabled = true;
            this.listBox_keys.Location = new System.Drawing.Point(11, 19);
            this.listBox_keys.Name = "listBox_keys";
            this.listBox_keys.Size = new System.Drawing.Size(500, 199);
            this.listBox_keys.TabIndex = 2;
            // 
            // b_moveUp
            // 
            this.b_moveUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.b_moveUp.Location = new System.Drawing.Point(517, 19);
            this.b_moveUp.Name = "b_moveUp";
            this.b_moveUp.Size = new System.Drawing.Size(189, 23);
            this.b_moveUp.TabIndex = 3;
            this.b_moveUp.Text = "Move up";
            this.b_moveUp.UseVisualStyleBackColor = true;
            this.b_moveUp.Click += new System.EventHandler(this.b_moveUp_Click);
            // 
            // b_moveDown
            // 
            this.b_moveDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.b_moveDown.Location = new System.Drawing.Point(517, 48);
            this.b_moveDown.Name = "b_moveDown";
            this.b_moveDown.Size = new System.Drawing.Size(188, 23);
            this.b_moveDown.TabIndex = 4;
            this.b_moveDown.Text = "Move down";
            this.b_moveDown.UseVisualStyleBackColor = true;
            this.b_moveDown.Click += new System.EventHandler(this.b_moveDown_Click);
            // 
            // b_remove
            // 
            this.b_remove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.b_remove.Location = new System.Drawing.Point(517, 77);
            this.b_remove.Name = "b_remove";
            this.b_remove.Size = new System.Drawing.Size(188, 23);
            this.b_remove.TabIndex = 5;
            this.b_remove.Text = "Remove";
            this.b_remove.UseVisualStyleBackColor = true;
            this.b_remove.Click += new System.EventHandler(this.b_remove_Click);
            // 
            // b_save
            // 
            this.b_save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.b_save.Location = new System.Drawing.Point(517, 198);
            this.b_save.Name = "b_save";
            this.b_save.Size = new System.Drawing.Size(189, 23);
            this.b_save.TabIndex = 6;
            this.b_save.Text = "Save\r\n";
            this.b_save.UseVisualStyleBackColor = true;
            this.b_save.Click += new System.EventHandler(this.b_save_Click);
            // 
            // b_edit_keyEdit
            // 
            this.b_edit_keyEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.b_edit_keyEdit.Location = new System.Drawing.Point(503, 11);
            this.b_edit_keyEdit.Name = "b_edit_keyEdit";
            this.b_edit_keyEdit.Size = new System.Drawing.Size(204, 23);
            this.b_edit_keyEdit.TabIndex = 7;
            this.b_edit_keyEdit.Text = "...";
            this.b_edit_keyEdit.UseVisualStyleBackColor = true;
            this.b_edit_keyEdit.Click += new System.EventHandler(this.b_edit_keyEdit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Add text (e.g. chat):";
            // 
            // tb_addText
            // 
            this.tb_addText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_addText.Location = new System.Drawing.Point(112, 46);
            this.tb_addText.Name = "tb_addText";
            this.tb_addText.Size = new System.Drawing.Size(385, 20);
            this.tb_addText.TabIndex = 9;
            // 
            // b_addText
            // 
            this.b_addText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.b_addText.Location = new System.Drawing.Point(503, 43);
            this.b_addText.Name = "b_addText";
            this.b_addText.Size = new System.Drawing.Size(75, 23);
            this.b_addText.TabIndex = 10;
            this.b_addText.Text = "Add Text";
            this.b_addText.UseVisualStyleBackColor = true;
            this.b_addText.Click += new System.EventHandler(this.b_addText_Click);
            // 
            // b_addTextWithDelay
            // 
            this.b_addTextWithDelay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.b_addTextWithDelay.Location = new System.Drawing.Point(584, 43);
            this.b_addTextWithDelay.Name = "b_addTextWithDelay";
            this.b_addTextWithDelay.Size = new System.Drawing.Size(123, 23);
            this.b_addTextWithDelay.TabIndex = 14;
            this.b_addTextWithDelay.Text = "Add Text with delay";
            this.b_addTextWithDelay.UseVisualStyleBackColor = true;
            this.b_addTextWithDelay.Click += new System.EventHandler(this.b_addTextWithDelay_Click);
            // 
            // b_addDelayToSelected
            // 
            this.b_addDelayToSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.b_addDelayToSelected.Location = new System.Drawing.Point(573, 136);
            this.b_addDelayToSelected.Name = "b_addDelayToSelected";
            this.b_addDelayToSelected.Size = new System.Drawing.Size(128, 23);
            this.b_addDelayToSelected.TabIndex = 15;
            this.b_addDelayToSelected.Text = "Add/Set Delay";
            this.b_addDelayToSelected.UseVisualStyleBackColor = true;
            this.b_addDelayToSelected.Click += new System.EventHandler(this.b_addDelayToSelected_Click);
            // 
            // tb_delay
            // 
            this.tb_delay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_delay.Location = new System.Drawing.Point(517, 139);
            this.tb_delay.Name = "tb_delay";
            this.tb_delay.Size = new System.Drawing.Size(50, 20);
            this.tb_delay.TabIndex = 16;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.b_edit_keyEdit);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.b_addTextWithDelay);
            this.groupBox1.Controls.Add(this.tb_addText);
            this.groupBox1.Controls.Add(this.b_addText);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(713, 94);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Adding";
            // 
            // b_unselect
            // 
            this.b_unselect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.b_unselect.Location = new System.Drawing.Point(517, 106);
            this.b_unselect.Name = "b_unselect";
            this.b_unselect.Size = new System.Drawing.Size(188, 23);
            this.b_unselect.TabIndex = 18;
            this.b_unselect.Text = "Unselect";
            this.b_unselect.UseVisualStyleBackColor = true;
            this.b_unselect.Click += new System.EventHandler(this.b_unselect_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.listBox_keys);
            this.groupBox2.Controls.Add(this.b_unselect);
            this.groupBox2.Controls.Add(this.b_moveUp);
            this.groupBox2.Controls.Add(this.b_moveDown);
            this.groupBox2.Controls.Add(this.tb_delay);
            this.groupBox2.Controls.Add(this.b_remove);
            this.groupBox2.Controls.Add(this.b_addDelayToSelected);
            this.groupBox2.Controls.Add(this.b_save);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 94);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(713, 234);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Keys";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(514, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(185, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "NOTE: The delay is executed AFTER";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(295, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "NOTE: The delay for text is put in between EVERY character";
            // 
            // EditSequence
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 334);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "EditSequence";
            this.Text = "EditSequence";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox_keys;
        private System.Windows.Forms.Button b_moveUp;
        private System.Windows.Forms.Button b_moveDown;
        private System.Windows.Forms.Button b_remove;
        private System.Windows.Forms.Button b_save;
        private System.Windows.Forms.Button b_edit_keyEdit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_addText;
        private System.Windows.Forms.Button b_addText;
        private System.Windows.Forms.Button b_addTextWithDelay;
        private System.Windows.Forms.Button b_addDelayToSelected;
        private System.Windows.Forms.TextBox tb_delay;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button b_unselect;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}