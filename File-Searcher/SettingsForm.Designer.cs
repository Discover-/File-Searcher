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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageGeneral = new System.Windows.Forms.TabPage();
            this.tabPageShortcuts = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxShortcutAbout = new System.Windows.Forms.TextBox();
            this.textBoxShortcutSettings = new System.Windows.Forms.TextBox();
            this.textBoxShortcutExit = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPageGeneral.SuspendLayout();
            this.tabPageShortcuts.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBoxAlwaysShowDetailedRestrictions
            // 
            this.checkBoxAlwaysShowDetailedRestrictions.AutoSize = true;
            this.checkBoxAlwaysShowDetailedRestrictions.Location = new System.Drawing.Point(6, 76);
            this.checkBoxAlwaysShowDetailedRestrictions.Name = "checkBoxAlwaysShowDetailedRestrictions";
            this.checkBoxAlwaysShowDetailedRestrictions.Size = new System.Drawing.Size(180, 17);
            this.checkBoxAlwaysShowDetailedRestrictions.TabIndex = 7;
            this.checkBoxAlwaysShowDetailedRestrictions.Text = "Always show detailed restrictions";
            this.checkBoxAlwaysShowDetailedRestrictions.UseVisualStyleBackColor = true;
            // 
            // checkBoxAutoSaveSettings
            // 
            this.checkBoxAutoSaveSettings.AutoSize = true;
            this.checkBoxAutoSaveSettings.Location = new System.Drawing.Point(6, 131);
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
            this.checkBoxPromptToQuit.Location = new System.Drawing.Point(6, 53);
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
            this.checkBoxPromptShowProgressbar.Location = new System.Drawing.Point(6, 30);
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
            this.checkBoxPromptOpenFile.Location = new System.Drawing.Point(6, 7);
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
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageGeneral);
            this.tabControl1.Controls.Add(this.tabPageShortcuts);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(238, 180);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPageGeneral
            // 
            this.tabPageGeneral.Controls.Add(this.checkBoxAlwaysShowDetailedRestrictions);
            this.tabPageGeneral.Controls.Add(this.checkBoxPromptOpenFile);
            this.tabPageGeneral.Controls.Add(this.checkBoxAutoSaveSettings);
            this.tabPageGeneral.Controls.Add(this.checkBoxPromptShowProgressbar);
            this.tabPageGeneral.Controls.Add(this.checkBoxPromptToQuit);
            this.tabPageGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabPageGeneral.Name = "tabPageGeneral";
            this.tabPageGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGeneral.Size = new System.Drawing.Size(230, 154);
            this.tabPageGeneral.TabIndex = 0;
            this.tabPageGeneral.Text = "General";
            this.tabPageGeneral.UseVisualStyleBackColor = true;
            // 
            // tabPageShortcuts
            // 
            this.tabPageShortcuts.Controls.Add(this.label3);
            this.tabPageShortcuts.Controls.Add(this.textBoxShortcutAbout);
            this.tabPageShortcuts.Controls.Add(this.textBoxShortcutSettings);
            this.tabPageShortcuts.Controls.Add(this.textBoxShortcutExit);
            this.tabPageShortcuts.Controls.Add(this.label2);
            this.tabPageShortcuts.Controls.Add(this.label1);
            this.tabPageShortcuts.Location = new System.Drawing.Point(4, 22);
            this.tabPageShortcuts.Name = "tabPageShortcuts";
            this.tabPageShortcuts.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageShortcuts.Size = new System.Drawing.Size(230, 154);
            this.tabPageShortcuts.TabIndex = 1;
            this.tabPageShortcuts.Text = "Shortcuts";
            this.tabPageShortcuts.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "About:";
            // 
            // textBoxShortcutAbout
            // 
            this.textBoxShortcutAbout.Location = new System.Drawing.Point(62, 59);
            this.textBoxShortcutAbout.Name = "textBoxShortcutAbout";
            this.textBoxShortcutAbout.Size = new System.Drawing.Size(162, 20);
            this.textBoxShortcutAbout.TabIndex = 3;
            // 
            // textBoxShortcutSettings
            // 
            this.textBoxShortcutSettings.Location = new System.Drawing.Point(62, 33);
            this.textBoxShortcutSettings.Name = "textBoxShortcutSettings";
            this.textBoxShortcutSettings.Size = new System.Drawing.Size(162, 20);
            this.textBoxShortcutSettings.TabIndex = 2;
            // 
            // textBoxShortcutExit
            // 
            this.textBoxShortcutExit.Location = new System.Drawing.Point(62, 6);
            this.textBoxShortcutExit.Name = "textBoxShortcutExit";
            this.textBoxShortcutExit.Size = new System.Drawing.Size(162, 20);
            this.textBoxShortcutExit.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Settings:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Exit:";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 229);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonSave);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.Text = "File Searcher Settings";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SettingsForm_FormClosed);
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SettingsForm_KeyDown);
            this.tabControl1.ResumeLayout(false);
            this.tabPageGeneral.ResumeLayout(false);
            this.tabPageGeneral.PerformLayout();
            this.tabPageShortcuts.ResumeLayout(false);
            this.tabPageShortcuts.PerformLayout();
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
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageGeneral;
        private System.Windows.Forms.TabPage tabPageShortcuts;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxShortcutAbout;
        private System.Windows.Forms.TextBox textBoxShortcutSettings;
        private System.Windows.Forms.TextBox textBoxShortcutExit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}