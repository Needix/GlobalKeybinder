namespace Helper_GlobalKeybinder.ProjectSRC.GUI {
    partial class ConfigureKey {
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
            this.cb_key = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbox_shift = new System.Windows.Forms.CheckBox();
            this.cbox_alt = new System.Windows.Forms.CheckBox();
            this.cbox_control = new System.Windows.Forms.CheckBox();
            this.b_save = new System.Windows.Forms.Button();
            this.b_cancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_special = new System.Windows.Forms.ComboBox();
            this.b_save_special = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_delay = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cb_key
            // 
            this.cb_key.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_key.Appearance = System.Windows.Forms.Appearance.Button;
            this.cb_key.Location = new System.Drawing.Point(313, 12);
            this.cb_key.Name = "cb_key";
            this.cb_key.Size = new System.Drawing.Size(237, 24);
            this.cb_key.TabIndex = 0;
            this.cb_key.Text = "...";
            this.cb_key.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cb_key.UseVisualStyleBackColor = true;
            this.cb_key.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cb_key_KeyPress);
            this.cb_key.Leave += new System.EventHandler(this.cb_key_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(295, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Press this button. After that press the key you want to select: ";
            // 
            // cbox_shift
            // 
            this.cbox_shift.AutoSize = true;
            this.cbox_shift.Location = new System.Drawing.Point(94, 81);
            this.cbox_shift.Name = "cbox_shift";
            this.cbox_shift.Size = new System.Drawing.Size(47, 17);
            this.cbox_shift.TabIndex = 2;
            this.cbox_shift.Text = "Shift";
            this.cbox_shift.UseVisualStyleBackColor = true;
            // 
            // cbox_alt
            // 
            this.cbox_alt.AutoSize = true;
            this.cbox_alt.Location = new System.Drawing.Point(163, 81);
            this.cbox_alt.Name = "cbox_alt";
            this.cbox_alt.Size = new System.Drawing.Size(38, 17);
            this.cbox_alt.TabIndex = 3;
            this.cbox_alt.Text = "Alt";
            this.cbox_alt.UseVisualStyleBackColor = true;
            // 
            // cbox_control
            // 
            this.cbox_control.AutoSize = true;
            this.cbox_control.Location = new System.Drawing.Point(15, 81);
            this.cbox_control.Name = "cbox_control";
            this.cbox_control.Size = new System.Drawing.Size(59, 17);
            this.cbox_control.TabIndex = 4;
            this.cbox_control.Text = "Control";
            this.cbox_control.UseVisualStyleBackColor = true;
            // 
            // b_save
            // 
            this.b_save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.b_save.Location = new System.Drawing.Point(261, 77);
            this.b_save.Name = "b_save";
            this.b_save.Size = new System.Drawing.Size(101, 23);
            this.b_save.TabIndex = 5;
            this.b_save.Text = "Save normal key";
            this.b_save.UseVisualStyleBackColor = true;
            this.b_save.Click += new System.EventHandler(this.b_save_Click);
            // 
            // b_cancel
            // 
            this.b_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.b_cancel.Location = new System.Drawing.Point(475, 75);
            this.b_cancel.Name = "b_cancel";
            this.b_cancel.Size = new System.Drawing.Size(75, 23);
            this.b_cancel.TabIndex = 6;
            this.b_cancel.Text = "Cancel";
            this.b_cancel.UseVisualStyleBackColor = true;
            this.b_cancel.Click += new System.EventHandler(this.b_cancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Alternativly select a special key: ";
            // 
            // comboBox_special
            // 
            this.comboBox_special.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_special.FormattingEnabled = true;
            this.comboBox_special.Items.AddRange(new object[] {
            "Left Mouse Button",
            "Right Mouse Button",
            "Middle Mouse Button"});
            this.comboBox_special.Location = new System.Drawing.Point(178, 42);
            this.comboBox_special.Name = "comboBox_special";
            this.comboBox_special.Size = new System.Drawing.Size(161, 21);
            this.comboBox_special.TabIndex = 8;
            this.comboBox_special.SelectedIndexChanged += new System.EventHandler(this.comboBox_special_SelectedIndexChanged);
            // 
            // b_save_special
            // 
            this.b_save_special.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.b_save_special.Location = new System.Drawing.Point(368, 77);
            this.b_save_special.Name = "b_save_special";
            this.b_save_special.Size = new System.Drawing.Size(101, 23);
            this.b_save_special.TabIndex = 9;
            this.b_save_special.Text = "Save special key";
            this.b_save_special.UseVisualStyleBackColor = true;
            this.b_save_special.Click += new System.EventHandler(this.b_save_special_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(345, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Delay between down and up: ";
            // 
            // tb_delay
            // 
            this.tb_delay.Location = new System.Drawing.Point(500, 42);
            this.tb_delay.Name = "tb_delay";
            this.tb_delay.Size = new System.Drawing.Size(50, 20);
            this.tb_delay.TabIndex = 11;
            this.tb_delay.Text = "10";
            // 
            // ConfigureKey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 111);
            this.Controls.Add(this.tb_delay);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.b_save_special);
            this.Controls.Add(this.comboBox_special);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.b_cancel);
            this.Controls.Add(this.b_save);
            this.Controls.Add(this.cbox_control);
            this.Controls.Add(this.cbox_alt);
            this.Controls.Add(this.cbox_shift);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_key);
            this.Name = "ConfigureKey";
            this.Text = "ConfigureKey";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cb_key;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbox_shift;
        private System.Windows.Forms.CheckBox cbox_alt;
        private System.Windows.Forms.CheckBox cbox_control;
        private System.Windows.Forms.Button b_save;
        private System.Windows.Forms.Button b_cancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_special;
        private System.Windows.Forms.Button b_save_special;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_delay;
    }
}