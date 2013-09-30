namespace File_Searcher
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.checkBoxAlwaysShowDetailedRestrictions = new System.Windows.Forms.CheckBox();
            this.checkBoxAutoSaveSettings = new System.Windows.Forms.CheckBox();
            this.checkBoxPromptToQuit = new System.Windows.Forms.CheckBox();
            this.checkBoxPromptShowProgressbar = new System.Windows.Forms.CheckBox();
            this.checkBoxPromptOpenFile = new System.Windows.Forms.CheckBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.groupBoxSettings = new System.Windows.Forms.GroupBox();
            this.groupBoxSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBoxAlwaysShowDetailedRestrictions
            // 
            this.checkBoxAlwaysShowDetailedRestrictions.AutoSize = true;
            this.checkBoxAlwaysShowDetailedRestrictions.Location = new System.Drawing.Point(6, 88);
            this.checkBoxAlwaysShowDetailedRestrictions.Name = "checkBoxAlwaysShowDetailedRestrictions";
            this.checkBoxAlwaysShowDetailedRestrictions.Size = new System.Drawing.Size(180, 17);
            this.checkBoxAlwaysShowDetailedRestrictions.TabIndex = 7;
            this.checkBoxAlwaysShowDetailedRestrictions.Text = "Always show detailed restrictions";
            this.checkBoxAlwaysShowDetailedRestrictions.UseVisualStyleBackColor = true;
            // 
            // checkBoxAutoSaveSettings
            // 
            this.checkBoxAutoSaveSettings.AutoSize = true;
            this.checkBoxAutoSaveSettings.Location = new System.Drawing.Point(6, 157);
            this.checkBoxAutoSaveSettings.Name = "checkBoxAutoSaveSettings";
            this.checkBoxAutoSaveSettings.Size = new System.Drawing.Size(113, 17);
            this.checkBoxAutoSaveSettings.TabIndex = 6;
            this.checkBoxAutoSaveSettings.Text = "Auto save settings";
            this.checkBoxAutoSaveSettings.UseVisualStyleBackColor = true;
            // 
            // checkBoxPromptToQuit
            // 
            this.checkBoxPromptToQuit.AutoSize = true;
            this.checkBoxPromptToQuit.Checked = true;
            this.checkBoxPromptToQuit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxPromptToQuit.Location = new System.Drawing.Point(6, 65);
            this.checkBoxPromptToQuit.Name = "checkBoxPromptToQuit";
            this.checkBoxPromptToQuit.Size = new System.Drawing.Size(147, 17);
            this.checkBoxPromptToQuit.TabIndex = 5;
            this.checkBoxPromptToQuit.Text = "Prompt me if I want to exit";
            this.checkBoxPromptToQuit.UseVisualStyleBackColor = true;
            // 
            // checkBoxPromptShowProgressbar
            // 
            this.checkBoxPromptShowProgressbar.AutoSize = true;
            this.checkBoxPromptShowProgressbar.Checked = true;
            this.checkBoxPromptShowProgressbar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxPromptShowProgressbar.Location = new System.Drawing.Point(6, 42);
            this.checkBoxPromptShowProgressbar.Name = "checkBoxPromptShowProgressbar";
            this.checkBoxPromptShowProgressbar.Size = new System.Drawing.Size(214, 17);
            this.checkBoxPromptShowProgressbar.TabIndex = 4;
            this.checkBoxPromptShowProgressbar.Text = "Prompt me if I want to show progressbar";
            this.checkBoxPromptShowProgressbar.UseVisualStyleBackColor = true;
            // 
            // checkBoxPromptOpenFile
            // 
            this.checkBoxPromptOpenFile.AutoSize = true;
            this.checkBoxPromptOpenFile.Checked = true;
            this.checkBoxPromptOpenFile.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxPromptOpenFile.Location = new System.Drawing.Point(6, 19);
            this.checkBoxPromptOpenFile.Name = "checkBoxPromptOpenFile";
            this.checkBoxPromptOpenFile.Size = new System.Drawing.Size(180, 17);
            this.checkBoxPromptOpenFile.TabIndex = 1;
            this.checkBoxPromptOpenFile.Text = "Prompt me if I want to open a file";
            this.checkBoxPromptOpenFile.UseVisualStyleBackColor = true;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(12, 198);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 1;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(94, 198);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(75, 23);
            this.buttonClear.TabIndex = 2;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(175, 198);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(75, 23);
            this.buttonExit.TabIndex = 3;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // groupBoxSettings
            // 
            this.groupBoxSettings.Controls.Add(this.checkBoxPromptOpenFile);
            this.groupBoxSettings.Controls.Add(this.checkBoxAlwaysShowDetailedRestrictions);
            this.groupBoxSettings.Controls.Add(this.checkBoxPromptToQuit);
            this.groupBoxSettings.Controls.Add(this.checkBoxPromptShowProgressbar);
            this.groupBoxSettings.Controls.Add(this.checkBoxAutoSaveSettings);
            this.groupBoxSettings.Location = new System.Drawing.Point(12, 12);
            this.groupBoxSettings.Name = "groupBoxSettings";
            this.groupBoxSettings.Size = new System.Drawing.Size(238, 180);
            this.groupBoxSettings.TabIndex = 8;
            this.groupBoxSettings.TabStop = false;
            this.groupBoxSettings.Text = "Settings";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 229);
            this.Controls.Add(this.groupBoxSettings);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "File Searcher Settings";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SettingsForm_FormClosed);
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SettingsForm_KeyDown);
            this.groupBoxSettings.ResumeLayout(false);
            this.groupBoxSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxPromptOpenFile;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.CheckBox checkBoxPromptShowProgressbar;
        private System.Windows.Forms.CheckBox checkBoxPromptToQuit;
        private System.Windows.Forms.CheckBox checkBoxAutoSaveSettings;
        private System.Windows.Forms.CheckBox checkBoxAlwaysShowDetailedRestrictions;
        private System.Windows.Forms.GroupBox groupBoxSettings;
    }
}