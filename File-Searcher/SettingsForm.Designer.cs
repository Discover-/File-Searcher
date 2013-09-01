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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxPromptOpenFile = new System.Windows.Forms.CheckBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.checkBoxPromptShowProgressbar = new System.Windows.Forms.CheckBox();
            this.checkBoxPromptToQuit = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxPromptToQuit);
            this.groupBox1.Controls.Add(this.checkBoxPromptShowProgressbar);
            this.groupBox1.Controls.Add(this.checkBoxPromptOpenFile);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(238, 180);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // checkBoxPromptOpenFile
            // 
            this.checkBoxPromptOpenFile.AutoSize = true;
            this.checkBoxPromptOpenFile.Checked = true;
            this.checkBoxPromptOpenFile.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxPromptOpenFile.Location = new System.Drawing.Point(17, 19);
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
            this.buttonClear.Location = new System.Drawing.Point(93, 198);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(75, 23);
            this.buttonClear.TabIndex = 2;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(175, 197);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(75, 23);
            this.buttonExit.TabIndex = 3;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // checkBoxPromptShowProgressbar
            // 
            this.checkBoxPromptShowProgressbar.AutoSize = true;
            this.checkBoxPromptShowProgressbar.Checked = true;
            this.checkBoxPromptShowProgressbar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxPromptShowProgressbar.Location = new System.Drawing.Point(17, 42);
            this.checkBoxPromptShowProgressbar.Name = "checkBoxPromptShowProgressbar";
            this.checkBoxPromptShowProgressbar.Size = new System.Drawing.Size(214, 17);
            this.checkBoxPromptShowProgressbar.TabIndex = 4;
            this.checkBoxPromptShowProgressbar.Text = "Prompt me if I want to show progressbar";
            this.checkBoxPromptShowProgressbar.UseVisualStyleBackColor = true;
            // 
            // checkBoxPromptToQuit
            // 
            this.checkBoxPromptToQuit.AutoSize = true;
            this.checkBoxPromptToQuit.Location = new System.Drawing.Point(17, 65);
            this.checkBoxPromptToQuit.Name = "checkBoxPromptToQuit";
            this.checkBoxPromptToQuit.Size = new System.Drawing.Size(147, 17);
            this.checkBoxPromptToQuit.TabIndex = 5;
            this.checkBoxPromptToQuit.Text = "Prompt me if I want to exit";
            this.checkBoxPromptToQuit.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 229);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsForm";
            this.Text = "File-searcher settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBoxPromptOpenFile;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.CheckBox checkBoxPromptShowProgressbar;
        private System.Windows.Forms.CheckBox checkBoxPromptToQuit;
    }
}