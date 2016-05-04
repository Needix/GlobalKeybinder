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
            this.label3 = new System.Windows.Forms.Label();
            this.tb_addDelay = new System.Windows.Forms.TextBox();
            this.b_addDelay = new System.Windows.Forms.Button();
            this.b_addTextWithDelay = new System.Windows.Forms.Button();
            this.b_addDelayToSelected = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(471, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Press this Key once. After that press any Key to add it to the list. Press it a s" +
    "econd time to cancel it:";
            // 
            // listBox_keys
            // 
            this.listBox_keys.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox_keys.FormattingEnabled = true;
            this.listBox_keys.Location = new System.Drawing.Point(15, 103);
            this.listBox_keys.Name = "listBox_keys";
            this.listBox_keys.Size = new System.Drawing.Size(449, 160);
            this.listBox_keys.TabIndex = 2;
            // 
            // b_moveUp
            // 
            this.b_moveUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.b_moveUp.Location = new System.Drawing.Point(471, 103);
            this.b_moveUp.Name = "b_moveUp";
            this.b_moveUp.Size = new System.Drawing.Size(75, 23);
            this.b_moveUp.TabIndex = 3;
            this.b_moveUp.Text = "Move up";
            this.b_moveUp.UseVisualStyleBackColor = true;
            this.b_moveUp.Click += new System.EventHandler(this.b_moveUp_Click);
            // 
            // b_moveDown
            // 
            this.b_moveDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.b_moveDown.Location = new System.Drawing.Point(471, 132);
            this.b_moveDown.Name = "b_moveDown";
            this.b_moveDown.Size = new System.Drawing.Size(75, 23);
            this.b_moveDown.TabIndex = 4;
            this.b_moveDown.Text = "Move down";
            this.b_moveDown.UseVisualStyleBackColor = true;
            this.b_moveDown.Click += new System.EventHandler(this.b_moveDown_Click);
            // 
            // b_remove
            // 
            this.b_remove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.b_remove.Location = new System.Drawing.Point(470, 161);
            this.b_remove.Name = "b_remove";
            this.b_remove.Size = new System.Drawing.Size(75, 23);
            this.b_remove.TabIndex = 5;
            this.b_remove.Text = "Remove";
            this.b_remove.UseVisualStyleBackColor = true;
            this.b_remove.Click += new System.EventHandler(this.b_remove_Click);
            // 
            // b_save
            // 
            this.b_save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.b_save.Location = new System.Drawing.Point(471, 248);
            this.b_save.Name = "b_save";
            this.b_save.Size = new System.Drawing.Size(75, 23);
            this.b_save.TabIndex = 6;
            this.b_save.Text = "Save\r\n";
            this.b_save.UseVisualStyleBackColor = true;
            this.b_save.Click += new System.EventHandler(this.b_save_Click);
            // 
            // b_edit_keyEdit
            // 
            this.b_edit_keyEdit.Location = new System.Drawing.Point(489, 4);
            this.b_edit_keyEdit.Name = "b_edit_keyEdit";
            this.b_edit_keyEdit.Size = new System.Drawing.Size(57, 23);
            this.b_edit_keyEdit.TabIndex = 7;
            this.b_edit_keyEdit.Text = "...";
            this.b_edit_keyEdit.UseVisualStyleBackColor = true;
            this.b_edit_keyEdit.Click += new System.EventHandler(this.b_edit_keyEdit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Add text (e.g. chat):";
            // 
            // tb_addText
            // 
            this.tb_addText.Location = new System.Drawing.Point(118, 39);
            this.tb_addText.Name = "tb_addText";
            this.tb_addText.Size = new System.Drawing.Size(206, 20);
            this.tb_addText.TabIndex = 9;
            // 
            // b_addText
            // 
            this.b_addText.Location = new System.Drawing.Point(330, 36);
            this.b_addText.Name = "b_addText";
            this.b_addText.Size = new System.Drawing.Size(75, 23);
            this.b_addText.TabIndex = 10;
            this.b_addText.Text = "Add Text";
            this.b_addText.UseVisualStyleBackColor = true;
            this.b_addText.Click += new System.EventHandler(this.b_addText_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Add delay between key presses:";
            // 
            // tb_addDelay
            // 
            this.tb_addDelay.Location = new System.Drawing.Point(178, 66);
            this.tb_addDelay.Name = "tb_addDelay";
            this.tb_addDelay.Size = new System.Drawing.Size(286, 20);
            this.tb_addDelay.TabIndex = 12;
            this.tb_addDelay.Text = "10";
            // 
            // b_addDelay
            // 
            this.b_addDelay.Location = new System.Drawing.Point(471, 63);
            this.b_addDelay.Name = "b_addDelay";
            this.b_addDelay.Size = new System.Drawing.Size(75, 23);
            this.b_addDelay.TabIndex = 13;
            this.b_addDelay.Text = "Add delay";
            this.b_addDelay.UseVisualStyleBackColor = true;
            this.b_addDelay.Click += new System.EventHandler(this.b_addDelay_Click);
            // 
            // b_addTextWithDelay
            // 
            this.b_addTextWithDelay.Location = new System.Drawing.Point(411, 36);
            this.b_addTextWithDelay.Name = "b_addTextWithDelay";
            this.b_addTextWithDelay.Size = new System.Drawing.Size(134, 23);
            this.b_addTextWithDelay.TabIndex = 14;
            this.b_addTextWithDelay.Text = "Add Text with delay";
            this.b_addTextWithDelay.UseVisualStyleBackColor = true;
            this.b_addTextWithDelay.Click += new System.EventHandler(this.b_addTextWithDelay_Click);
            // 
            // b_addDelayToSelected
            // 
            this.b_addDelayToSelected.Location = new System.Drawing.Point(470, 201);
            this.b_addDelayToSelected.Name = "b_addDelayToSelected";
            this.b_addDelayToSelected.Size = new System.Drawing.Size(75, 23);
            this.b_addDelayToSelected.TabIndex = 15;
            this.b_addDelayToSelected.Text = "Set Delay";
            this.b_addDelayToSelected.UseVisualStyleBackColor = true;
            this.b_addDelayToSelected.Click += new System.EventHandler(this.b_addDelayToSelected_Click);
            // 
            // EditSequence
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 283);
            this.Controls.Add(this.b_addDelayToSelected);
            this.Controls.Add(this.b_addTextWithDelay);
            this.Controls.Add(this.b_addDelay);
            this.Controls.Add(this.tb_addDelay);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.b_addText);
            this.Controls.Add(this.tb_addText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.b_edit_keyEdit);
            this.Controls.Add(this.b_save);
            this.Controls.Add(this.b_remove);
            this.Controls.Add(this.b_moveDown);
            this.Controls.Add(this.b_moveUp);
            this.Controls.Add(this.listBox_keys);
            this.Controls.Add(this.label1);
            this.Name = "EditSequence";
            this.Text = "EditSequence";
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_addDelay;
        private System.Windows.Forms.Button b_addDelay;
        private System.Windows.Forms.Button b_addTextWithDelay;
        private System.Windows.Forms.Button b_addDelayToSelected;
    }
}