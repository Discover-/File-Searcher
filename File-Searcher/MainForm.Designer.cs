namespace File_Searcher
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.txtBoxDirectorySearch = new System.Windows.Forms.TextBox();
            this.labelOptions = new System.Windows.Forms.Label();
            this.checkBoxIncludeSubDirs = new System.Windows.Forms.CheckBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtBoxFilenameSearch = new System.Windows.Forms.TextBox();
            this.btnStopSearching = new System.Windows.Forms.Button();
            this.listViewResults = new System.Windows.Forms.ListView();
            this.checkBoxShowDir = new System.Windows.Forms.CheckBox();
            this.groupBoxOptions = new System.Windows.Forms.GroupBox();
            this.groupBoxSearchInfo = new System.Windows.Forms.GroupBox();
            this.btnSearchDir = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.labelSearchFilename = new System.Windows.Forms.Label();
            this.lblHeaderDirectories = new System.Windows.Forms.Label();
            this.checkBoxIgnoreRecycledFiles = new System.Windows.Forms.CheckBox();
            this.checkBoxShowHiddenFiles = new System.Windows.Forms.CheckBox();
            this.textBoxExtensions = new System.Windows.Forms.TextBox();
            this.lblIgnoreExtensions = new System.Windows.Forms.Label();
            this.checkBoxReverseExtensions = new System.Windows.Forms.CheckBox();
            this.groupBoxOptions.SuspendLayout();
            this.groupBoxSearchInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBoxDirectorySearch
            // 
            this.txtBoxDirectorySearch.Location = new System.Drawing.Point(19, 56);
            this.txtBoxDirectorySearch.Name = "txtBoxDirectorySearch";
            this.txtBoxDirectorySearch.Size = new System.Drawing.Size(704, 20);
            this.txtBoxDirectorySearch.TabIndex = 0;
            this.txtBoxDirectorySearch.Text = "C:\\";
            // 
            // labelOptions
            // 
            this.labelOptions.AutoSize = true;
            this.labelOptions.Location = new System.Drawing.Point(6, 0);
            this.labelOptions.Name = "labelOptions";
            this.labelOptions.Size = new System.Drawing.Size(43, 13);
            this.labelOptions.TabIndex = 2;
            this.labelOptions.Text = "Options";
            // 
            // checkBoxIncludeSubDirs
            // 
            this.checkBoxIncludeSubDirs.AutoSize = true;
            this.checkBoxIncludeSubDirs.Checked = true;
            this.checkBoxIncludeSubDirs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxIncludeSubDirs.Location = new System.Drawing.Point(9, 19);
            this.checkBoxIncludeSubDirs.Name = "checkBoxIncludeSubDirs";
            this.checkBoxIncludeSubDirs.Size = new System.Drawing.Size(129, 17);
            this.checkBoxIncludeSubDirs.TabIndex = 3;
            this.checkBoxIncludeSubDirs.Text = "Include subdirectories";
            this.checkBoxIncludeSubDirs.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(678, 148);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtBoxFilenameSearch
            // 
            this.txtBoxFilenameSearch.Location = new System.Drawing.Point(5, 100);
            this.txtBoxFilenameSearch.Name = "txtBoxFilenameSearch";
            this.txtBoxFilenameSearch.Size = new System.Drawing.Size(355, 20);
            this.txtBoxFilenameSearch.TabIndex = 0;
            // 
            // btnStopSearching
            // 
            this.btnStopSearching.Enabled = false;
            this.btnStopSearching.Location = new System.Drawing.Point(678, 183);
            this.btnStopSearching.Name = "btnStopSearching";
            this.btnStopSearching.Size = new System.Drawing.Size(75, 23);
            this.btnStopSearching.TabIndex = 7;
            this.btnStopSearching.Text = "Stop";
            this.btnStopSearching.UseVisualStyleBackColor = true;
            this.btnStopSearching.Click += new System.EventHandler(this.btnStopSearching_Click);
            // 
            // listViewResults
            // 
            this.listViewResults.Location = new System.Drawing.Point(14, 213);
            this.listViewResults.Name = "listViewResults";
            this.listViewResults.Size = new System.Drawing.Size(739, 232);
            this.listViewResults.TabIndex = 8;
            this.listViewResults.UseCompatibleStateImageBehavior = false;
            // 
            // checkBoxShowDir
            // 
            this.checkBoxShowDir.AutoSize = true;
            this.checkBoxShowDir.Checked = true;
            this.checkBoxShowDir.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxShowDir.Location = new System.Drawing.Point(9, 42);
            this.checkBoxShowDir.Name = "checkBoxShowDir";
            this.checkBoxShowDir.Size = new System.Drawing.Size(124, 17);
            this.checkBoxShowDir.TabIndex = 9;
            this.checkBoxShowDir.Text = "Show directory of file";
            this.checkBoxShowDir.UseVisualStyleBackColor = true;
            this.checkBoxShowDir.CheckedChanged += new System.EventHandler(this.checkBoxShowDir_CheckedChanged);
            // 
            // groupBoxOptions
            // 
            this.groupBoxOptions.Controls.Add(this.checkBoxReverseExtensions);
            this.groupBoxOptions.Controls.Add(this.checkBoxShowHiddenFiles);
            this.groupBoxOptions.Controls.Add(this.checkBoxIgnoreRecycledFiles);
            this.groupBoxOptions.Controls.Add(this.checkBoxShowDir);
            this.groupBoxOptions.Controls.Add(this.labelOptions);
            this.groupBoxOptions.Controls.Add(this.checkBoxIncludeSubDirs);
            this.groupBoxOptions.Location = new System.Drawing.Point(13, 141);
            this.groupBoxOptions.Name = "groupBoxOptions";
            this.groupBoxOptions.Size = new System.Drawing.Size(659, 66);
            this.groupBoxOptions.TabIndex = 10;
            this.groupBoxOptions.TabStop = false;
            // 
            // groupBoxSearchInfo
            // 
            this.groupBoxSearchInfo.Controls.Add(this.lblIgnoreExtensions);
            this.groupBoxSearchInfo.Controls.Add(this.textBoxExtensions);
            this.groupBoxSearchInfo.Controls.Add(this.lblHeaderDirectories);
            this.groupBoxSearchInfo.Controls.Add(this.btnSearchDir);
            this.groupBoxSearchInfo.Controls.Add(this.txtBoxFilenameSearch);
            this.groupBoxSearchInfo.Controls.Add(this.label2);
            this.groupBoxSearchInfo.Controls.Add(this.labelSearchFilename);
            this.groupBoxSearchInfo.Location = new System.Drawing.Point(14, 7);
            this.groupBoxSearchInfo.Name = "groupBoxSearchInfo";
            this.groupBoxSearchInfo.Size = new System.Drawing.Size(740, 128);
            this.groupBoxSearchInfo.TabIndex = 10;
            this.groupBoxSearchInfo.TabStop = false;
            // 
            // btnSearchDir
            // 
            this.btnSearchDir.Location = new System.Drawing.Point(709, 49);
            this.btnSearchDir.Name = "btnSearchDir";
            this.btnSearchDir.Size = new System.Drawing.Size(24, 20);
            this.btnSearchDir.TabIndex = 1;
            this.btnSearchDir.Text = "...";
            this.btnSearchDir.UseVisualStyleBackColor = true;
            this.btnSearchDir.Click += new System.EventHandler(this.btnSearchDir_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Directory to search in:";
            // 
            // labelSearchFilename
            // 
            this.labelSearchFilename.AutoSize = true;
            this.labelSearchFilename.Location = new System.Drawing.Point(6, 80);
            this.labelSearchFilename.Name = "labelSearchFilename";
            this.labelSearchFilename.Size = new System.Drawing.Size(348, 13);
            this.labelSearchFilename.TabIndex = 2;
            this.labelSearchFilename.Text = "Filename to search for (if left empty all files in the directory will be shown):";
            // 
            // lblHeaderDirectories
            // 
            this.lblHeaderDirectories.AutoSize = true;
            this.lblHeaderDirectories.Location = new System.Drawing.Point(6, 0);
            this.lblHeaderDirectories.Name = "lblHeaderDirectories";
            this.lblHeaderDirectories.Size = new System.Drawing.Size(95, 13);
            this.lblHeaderDirectories.TabIndex = 3;
            this.lblHeaderDirectories.Text = "Search information";
            // 
            // checkBoxIgnoreRecycledFiles
            // 
            this.checkBoxIgnoreRecycledFiles.AutoSize = true;
            this.checkBoxIgnoreRecycledFiles.Location = new System.Drawing.Point(163, 19);
            this.checkBoxIgnoreRecycledFiles.Name = "checkBoxIgnoreRecycledFiles";
            this.checkBoxIgnoreRecycledFiles.Size = new System.Drawing.Size(120, 17);
            this.checkBoxIgnoreRecycledFiles.TabIndex = 10;
            this.checkBoxIgnoreRecycledFiles.Text = "Ignore recycled files";
            this.checkBoxIgnoreRecycledFiles.UseVisualStyleBackColor = true;
            // 
            // checkBoxShowHiddenFiles
            // 
            this.checkBoxShowHiddenFiles.AutoSize = true;
            this.checkBoxShowHiddenFiles.Location = new System.Drawing.Point(163, 42);
            this.checkBoxShowHiddenFiles.Name = "checkBoxShowHiddenFiles";
            this.checkBoxShowHiddenFiles.Size = new System.Drawing.Size(109, 17);
            this.checkBoxShowHiddenFiles.TabIndex = 11;
            this.checkBoxShowHiddenFiles.Text = "Show hidden files";
            this.checkBoxShowHiddenFiles.UseVisualStyleBackColor = true;
            // 
            // textBoxExtensions
            // 
            this.textBoxExtensions.Location = new System.Drawing.Point(378, 100);
            this.textBoxExtensions.Name = "textBoxExtensions";
            this.textBoxExtensions.Size = new System.Drawing.Size(355, 20);
            this.textBoxExtensions.TabIndex = 4;
            // 
            // lblIgnoreExtensions
            // 
            this.lblIgnoreExtensions.AutoSize = true;
            this.lblIgnoreExtensions.Location = new System.Drawing.Point(378, 80);
            this.lblIgnoreExtensions.Name = "lblIgnoreExtensions";
            this.lblIgnoreExtensions.Size = new System.Drawing.Size(196, 13);
            this.lblIgnoreExtensions.TabIndex = 5;
            this.lblIgnoreExtensions.Text = "Extensions to ignore (split by semicolon):";
            // 
            // checkBoxReverseExtensions
            // 
            this.checkBoxReverseExtensions.AutoSize = true;
            this.checkBoxReverseExtensions.Location = new System.Drawing.Point(311, 19);
            this.checkBoxReverseExtensions.Name = "checkBoxReverseExtensions";
            this.checkBoxReverseExtensions.Size = new System.Drawing.Size(136, 17);
            this.checkBoxReverseExtensions.TabIndex = 12;
            this.checkBoxReverseExtensions.Text = "Reverse extension field";
            this.checkBoxReverseExtensions.UseVisualStyleBackColor = true;
            this.checkBoxReverseExtensions.CheckedChanged += new System.EventHandler(this.checkBoxReverseExtensions_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 457);
            this.Controls.Add(this.listViewResults);
            this.Controls.Add(this.btnStopSearching);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtBoxDirectorySearch);
            this.Controls.Add(this.groupBoxSearchInfo);
            this.Controls.Add(this.groupBoxOptions);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "File-searcher";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBoxOptions.ResumeLayout(false);
            this.groupBoxOptions.PerformLayout();
            this.groupBoxSearchInfo.ResumeLayout(false);
            this.groupBoxSearchInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBoxDirectorySearch;
        private System.Windows.Forms.Label labelOptions;
        private System.Windows.Forms.CheckBox checkBoxIncludeSubDirs;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtBoxFilenameSearch;
        private System.Windows.Forms.Button btnStopSearching;
        private System.Windows.Forms.ListView listViewResults;
        private System.Windows.Forms.CheckBox checkBoxShowDir;
        private System.Windows.Forms.GroupBox groupBoxOptions;
        private System.Windows.Forms.GroupBox groupBoxSearchInfo;
        private System.Windows.Forms.Button btnSearchDir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelSearchFilename;
        private System.Windows.Forms.Label lblHeaderDirectories;
        private System.Windows.Forms.CheckBox checkBoxIgnoreRecycledFiles;
        private System.Windows.Forms.CheckBox checkBoxShowHiddenFiles;
        private System.Windows.Forms.Label lblIgnoreExtensions;
        private System.Windows.Forms.TextBox textBoxExtensions;
        private System.Windows.Forms.CheckBox checkBoxReverseExtensions;
    }
}

