namespace Helper_GlobalKeybinder.ProjectSRC.GUI {
    partial class CreateNewConfig {
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
            this.b_select_selectProcess = new System.Windows.Forms.Button();
            this.tb_select_exe = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbox_config_singleSend = new System.Windows.Forms.CheckBox();
            this.checkBox_select_enabled = new System.Windows.Forms.CheckBox();
            this.b_createSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // b_select_selectProcess
            // 
            this.b_select_selectProcess.Location = new System.Drawing.Point(453, 4);
            this.b_select_selectProcess.Name = "b_select_selectProcess";
            this.b_select_selectProcess.Size = new System.Drawing.Size(154, 23);
            this.b_select_selectProcess.TabIndex = 8;
            this.b_select_selectProcess.Text = "Select running process...";
            this.b_select_selectProcess.UseVisualStyleBackColor = true;
            this.b_select_selectProcess.Click += new System.EventHandler(this.b_select_selectProcess_Click);
            // 
            // tb_select_exe
            // 
            this.tb_select_exe.Location = new System.Drawing.Point(184, 6);
            this.tb_select_exe.Name = "tb_select_exe";
            this.tb_select_exe.Size = new System.Drawing.Size(263, 20);
            this.tb_select_exe.TabIndex = 7;
            this.tb_select_exe.TextChanged += new System.EventHandler(this.tb_select_exe_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Executable name (i.e. \"iexplorer\"):";
            // 
            // cbox_config_singleSend
            // 
            this.cbox_config_singleSend.AutoSize = true;
            this.cbox_config_singleSend.Location = new System.Drawing.Point(12, 32);
            this.cbox_config_singleSend.Name = "cbox_config_singleSend";
            this.cbox_config_singleSend.Size = new System.Drawing.Size(330, 17);
            this.cbox_config_singleSend.TabIndex = 9;
            this.cbox_config_singleSend.Text = "Use single send method (check this if game recieves keys twice)";
            this.cbox_config_singleSend.UseVisualStyleBackColor = true;
            this.cbox_config_singleSend.CheckedChanged += new System.EventHandler(this.cbox_config_singleSend_CheckedChanged);
            // 
            // checkBox_select_enabled
            // 
            this.checkBox_select_enabled.AutoSize = true;
            this.checkBox_select_enabled.Location = new System.Drawing.Point(12, 55);
            this.checkBox_select_enabled.Name = "checkBox_select_enabled";
            this.checkBox_select_enabled.Size = new System.Drawing.Size(65, 17);
            this.checkBox_select_enabled.TabIndex = 10;
            this.checkBox_select_enabled.Text = "Enabled";
            this.checkBox_select_enabled.UseVisualStyleBackColor = true;
            this.checkBox_select_enabled.CheckedChanged += new System.EventHandler(this.checkBox_select_enabled_CheckedChanged);
            // 
            // b_createSave
            // 
            this.b_createSave.Location = new System.Drawing.Point(532, 55);
            this.b_createSave.Name = "b_createSave";
            this.b_createSave.Size = new System.Drawing.Size(75, 23);
            this.b_createSave.TabIndex = 11;
            this.b_createSave.Text = "Save";
            this.b_createSave.UseVisualStyleBackColor = true;
            this.b_createSave.Click += new System.EventHandler(this.b_createSave_Click);
            // 
            // CreateNewConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 86);
            this.Controls.Add(this.b_createSave);
            this.Controls.Add(this.checkBox_select_enabled);
            this.Controls.Add(this.cbox_config_singleSend);
            this.Controls.Add(this.b_select_selectProcess);
            this.Controls.Add(this.tb_select_exe);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "CreateNewConfig";
            this.Text = "CreateNewConfig";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button b_select_selectProcess;
        private System.Windows.Forms.TextBox tb_select_exe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbox_config_singleSend;
        private System.Windows.Forms.CheckBox checkBox_select_enabled;
        private System.Windows.Forms.Button b_createSave;
    }
}