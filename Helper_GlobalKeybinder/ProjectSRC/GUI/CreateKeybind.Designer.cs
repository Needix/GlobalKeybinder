namespace Helper_GlobalKeybinder.ProjectSRC.GUI {
    partial class CreateKeybind {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
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
            this.b_edit_sequence = new System.Windows.Forms.Button();
            this.b_edit_configKey = new System.Windows.Forms.Button();
            this.tb_edit_kbSequence = new System.Windows.Forms.TextBox();
            this.tb_edit_kbKey = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_edit_kbName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.b_save = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // b_edit_sequence
            // 
            this.b_edit_sequence.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.b_edit_sequence.Location = new System.Drawing.Point(12, 361);
            this.b_edit_sequence.Name = "b_edit_sequence";
            this.b_edit_sequence.Size = new System.Drawing.Size(475, 23);
            this.b_edit_sequence.TabIndex = 22;
            this.b_edit_sequence.Text = "Edit Sequence...";
            this.b_edit_sequence.UseVisualStyleBackColor = true;
            this.b_edit_sequence.Click += new System.EventHandler(this.b_edit_sequence_Click);
            // 
            // b_edit_configKey
            // 
            this.b_edit_configKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.b_edit_configKey.Location = new System.Drawing.Point(365, 36);
            this.b_edit_configKey.Name = "b_edit_configKey";
            this.b_edit_configKey.Size = new System.Drawing.Size(122, 21);
            this.b_edit_configKey.TabIndex = 21;
            this.b_edit_configKey.Text = "Configure KeyboardKey...";
            this.b_edit_configKey.UseVisualStyleBackColor = true;
            this.b_edit_configKey.Click += new System.EventHandler(this.b_edit_configKey_Click);
            // 
            // tb_edit_kbSequence
            // 
            this.tb_edit_kbSequence.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_edit_kbSequence.Location = new System.Drawing.Point(12, 63);
            this.tb_edit_kbSequence.Multiline = true;
            this.tb_edit_kbSequence.Name = "tb_edit_kbSequence";
            this.tb_edit_kbSequence.ReadOnly = true;
            this.tb_edit_kbSequence.Size = new System.Drawing.Size(475, 276);
            this.tb_edit_kbSequence.TabIndex = 20;
            // 
            // tb_edit_kbKey
            // 
            this.tb_edit_kbKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_edit_kbKey.Location = new System.Drawing.Point(116, 36);
            this.tb_edit_kbKey.Name = "tb_edit_kbKey";
            this.tb_edit_kbKey.ReadOnly = true;
            this.tb_edit_kbKey.Size = new System.Drawing.Size(243, 20);
            this.tb_edit_kbKey.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Keybind Key:";
            // 
            // tb_edit_kbName
            // 
            this.tb_edit_kbName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_edit_kbName.Location = new System.Drawing.Point(116, 10);
            this.tb_edit_kbName.Name = "tb_edit_kbName";
            this.tb_edit_kbName.Size = new System.Drawing.Size(371, 20);
            this.tb_edit_kbName.TabIndex = 17;
            this.tb_edit_kbName.TextChanged += new System.EventHandler(this.tb_edit_kbName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Keybind name:";
            // 
            // b_save
            // 
            this.b_save.Location = new System.Drawing.Point(12, 391);
            this.b_save.Name = "b_save";
            this.b_save.Size = new System.Drawing.Size(474, 23);
            this.b_save.TabIndex = 23;
            this.b_save.Text = "Save";
            this.b_save.UseVisualStyleBackColor = true;
            this.b_save.Click += new System.EventHandler(this.b_save_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 345);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(467, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "WARNING: Avoid adding the keybind key to the sequence as this could result in an " +
    "infinite loop!!!";
            // 
            // CreateKeybind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 426);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.b_save);
            this.Controls.Add(this.b_edit_sequence);
            this.Controls.Add(this.b_edit_configKey);
            this.Controls.Add(this.tb_edit_kbSequence);
            this.Controls.Add(this.tb_edit_kbKey);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_edit_kbName);
            this.Controls.Add(this.label2);
            this.Name = "CreateKeybind";
            this.Text = "CreateKeybind";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button b_edit_sequence;
        private System.Windows.Forms.Button b_edit_configKey;
        private System.Windows.Forms.TextBox tb_edit_kbSequence;
        private System.Windows.Forms.TextBox tb_edit_kbKey;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_edit_kbName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button b_save;
        private System.Windows.Forms.Label label1;
    }
}