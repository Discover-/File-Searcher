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
            this.txtBoxFileSearch = new System.Windows.Forms.TextBox();
            this.btnStopSearching = new System.Windows.Forms.Button();
            this.listViewResults = new System.Windows.Forms.ListView();
            this.checkBoxShowDir = new System.Windows.Forms.CheckBox();
            this.groupBoxOptions = new System.Windows.Forms.GroupBox();
            this.checkBoxIgnoreCaseSensitivity = new System.Windows.Forms.CheckBox();
            this.checkBoxIgnoreFilesWithoutExtension = new System.Windows.Forms.CheckBox();
            this.checkBoxShowExceptions = new System.Windows.Forms.CheckBox();
            this.checkBoxShowAllResultsAtOnce = new System.Windows.Forms.CheckBox();
            this.checkBoxUseProgressBar = new System.Windows.Forms.CheckBox();
            this.checkBoxSearchForFileContent = new System.Windows.Forms.CheckBox();
            this.checkBoxReverseExtensions = new System.Windows.Forms.CheckBox();
            this.checkBoxShowHiddenFiles = new System.Windows.Forms.CheckBox();
            this.checkBoxIgnoreRecycledFiles = new System.Windows.Forms.CheckBox();
            this.groupBoxSearchInfo = new System.Windows.Forms.GroupBox();
            this.lblIgnoreExtensions = new System.Windows.Forms.Label();
            this.txtBoxExtensions = new System.Windows.Forms.TextBox();
            this.lblHeaderDirectories = new System.Windows.Forms.Label();
            this.btnSearchDir = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblSearchFile = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.btnClear = new System.Windows.Forms.Button();
            this.buttonOpenFilter = new System.Windows.Forms.Button();
            this.groupBoxOptions.SuspendLayout();
            this.groupBoxSearchInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBoxDirectorySearch
            // 
            this.txtBoxDirectorySearch.Location = new System.Drawing.Point(19, 49);
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
            this.checkBoxIncludeSubDirs.TabIndex = 4;
            this.checkBoxIncludeSubDirs.Text = "Include subdirectories";
            this.checkBoxIncludeSubDirs.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(678, 143);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 15;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtBoxFileSearch
            // 
            this.txtBoxFileSearch.Location = new System.Drawing.Point(5, 93);
            this.txtBoxFileSearch.Name = "txtBoxFileSearch";
            this.txtBoxFileSearch.Size = new System.Drawing.Size(355, 20);
            this.txtBoxFileSearch.TabIndex = 2;
            this.txtBoxFileSearch.TextChanged += new System.EventHandler(this.txtBoxFileSearch_TextChanged);
            // 
            // btnStopSearching
            // 
            this.btnStopSearching.Enabled = false;
            this.btnStopSearching.Location = new System.Drawing.Point(678, 169);
            this.btnStopSearching.Name = "btnStopSearching";
            this.btnStopSearching.Size = new System.Drawing.Size(75, 23);
            this.btnStopSearching.TabIndex = 16;
            this.btnStopSearching.Text = "Stop";
            this.btnStopSearching.UseVisualStyleBackColor = true;
            this.btnStopSearching.Click += new System.EventHandler(this.btnStopSearching_Click);
            // 
            // listViewResults
            // 
            this.listViewResults.Location = new System.Drawing.Point(14, 224);
            this.listViewResults.Name = "listViewResults";
            this.listViewResults.Size = new System.Drawing.Size(739, 240);
            this.listViewResults.TabIndex = 8;
            this.listViewResults.UseCompatibleStateImageBehavior = false;
            // 
            // checkBoxShowDir
            // 
            this.checkBoxShowDir.AutoSize = true;
            this.checkBoxShowDir.Checked = true;
            this.checkBoxShowDir.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxShowDir.Location = new System.Drawing.Point(9, 39);
            this.checkBoxShowDir.Name = "checkBoxShowDir";
            this.checkBoxShowDir.Size = new System.Drawing.Size(124, 17);
            this.checkBoxShowDir.TabIndex = 8;
            this.checkBoxShowDir.Text = "Show directory of file";
            this.checkBoxShowDir.UseVisualStyleBackColor = true;
            this.checkBoxShowDir.CheckedChanged += new System.EventHandler(this.checkBoxShowDir_CheckedChanged);
            // 
            // groupBoxOptions
            // 
            this.groupBoxOptions.Controls.Add(this.checkBoxIgnoreCaseSensitivity);
            this.groupBoxOptions.Controls.Add(this.checkBoxIgnoreFilesWithoutExtension);
            this.groupBoxOptions.Controls.Add(this.checkBoxShowExceptions);
            this.groupBoxOptions.Controls.Add(this.checkBoxShowAllResultsAtOnce);
            this.groupBoxOptions.Controls.Add(this.checkBoxUseProgressBar);
            this.groupBoxOptions.Controls.Add(this.checkBoxSearchForFileContent);
            this.groupBoxOptions.Controls.Add(this.checkBoxReverseExtensions);
            this.groupBoxOptions.Controls.Add(this.checkBoxShowHiddenFiles);
            this.groupBoxOptions.Controls.Add(this.checkBoxIgnoreRecycledFiles);
            this.groupBoxOptions.Controls.Add(this.checkBoxShowDir);
            this.groupBoxOptions.Controls.Add(this.labelOptions);
            this.groupBoxOptions.Controls.Add(this.checkBoxIncludeSubDirs);
            this.groupBoxOptions.Location = new System.Drawing.Point(13, 137);
            this.groupBoxOptions.Name = "groupBoxOptions";
            this.groupBoxOptions.Size = new System.Drawing.Size(659, 81);
            this.groupBoxOptions.TabIndex = 10;
            this.groupBoxOptions.TabStop = false;
            // 
            // checkBoxIgnoreCaseSensitivity
            // 
            this.checkBoxIgnoreCaseSensitivity.AutoSize = true;
            this.checkBoxIgnoreCaseSensitivity.Checked = true;
            this.checkBoxIgnoreCaseSensitivity.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxIgnoreCaseSensitivity.Enabled = false;
            this.checkBoxIgnoreCaseSensitivity.Location = new System.Drawing.Point(329, 59);
            this.checkBoxIgnoreCaseSensitivity.Name = "checkBoxIgnoreCaseSensitivity";
            this.checkBoxIgnoreCaseSensitivity.Size = new System.Drawing.Size(130, 17);
            this.checkBoxIgnoreCaseSensitivity.TabIndex = 14;
            this.checkBoxIgnoreCaseSensitivity.Text = "Ignore case sensitivity";
            this.checkBoxIgnoreCaseSensitivity.UseVisualStyleBackColor = true;
            // 
            // checkBoxIgnoreFilesWithoutExtension
            // 
            this.checkBoxIgnoreFilesWithoutExtension.AutoSize = true;
            this.checkBoxIgnoreFilesWithoutExtension.Location = new System.Drawing.Point(168, 59);
            this.checkBoxIgnoreFilesWithoutExtension.Name = "checkBoxIgnoreFilesWithoutExtension";
            this.checkBoxIgnoreFilesWithoutExtension.Size = new System.Drawing.Size(162, 17);
            this.checkBoxIgnoreFilesWithoutExtension.TabIndex = 13;
            this.checkBoxIgnoreFilesWithoutExtension.Text = "Ignore files without extension";
            this.checkBoxIgnoreFilesWithoutExtension.UseVisualStyleBackColor = true;
            // 
            // checkBoxShowExceptions
            // 
            this.checkBoxShowExceptions.AutoSize = true;
            this.checkBoxShowExceptions.Location = new System.Drawing.Point(9, 59);
            this.checkBoxShowExceptions.Name = "checkBoxShowExceptions";
            this.checkBoxShowExceptions.Size = new System.Drawing.Size(131, 17);
            this.checkBoxShowExceptions.TabIndex = 12;
            this.checkBoxShowExceptions.Text = "Show exception errors";
            this.checkBoxShowExceptions.UseVisualStyleBackColor = true;
            // 
            // checkBoxShowAllResultsAtOnce
            // 
            this.checkBoxShowAllResultsAtOnce.AutoSize = true;
            this.checkBoxShowAllResultsAtOnce.Location = new System.Drawing.Point(519, 39);
            this.checkBoxShowAllResultsAtOnce.Name = "checkBoxShowAllResultsAtOnce";
            this.checkBoxShowAllResultsAtOnce.Size = new System.Drawing.Size(138, 17);
            this.checkBoxShowAllResultsAtOnce.TabIndex = 11;
            this.checkBoxShowAllResultsAtOnce.Text = "Show all results at once";
            this.checkBoxShowAllResultsAtOnce.UseVisualStyleBackColor = true;
            // 
            // checkBoxUseProgressBar
            // 
            this.checkBoxUseProgressBar.AutoSize = true;
            this.checkBoxUseProgressBar.Location = new System.Drawing.Point(519, 19);
            this.checkBoxUseProgressBar.Name = "checkBoxUseProgressBar";
            this.checkBoxUseProgressBar.Size = new System.Drawing.Size(106, 17);
            this.checkBoxUseProgressBar.TabIndex = 7;
            this.checkBoxUseProgressBar.Text = "Use progress bar";
            this.checkBoxUseProgressBar.UseVisualStyleBackColor = true;
            this.checkBoxUseProgressBar.CheckedChanged += new System.EventHandler(this.checkBoxUseProgressBar_CheckedChanged);
            // 
            // checkBoxSearchForFileContent
            // 
            this.checkBoxSearchForFileContent.AutoSize = true;
            this.checkBoxSearchForFileContent.Location = new System.Drawing.Point(329, 39);
            this.checkBoxSearchForFileContent.Name = "checkBoxSearchForFileContent";
            this.checkBoxSearchForFileContent.Size = new System.Drawing.Size(167, 17);
            this.checkBoxSearchForFileContent.TabIndex = 10;
            this.checkBoxSearchForFileContent.Text = "Search for file content instead";
            this.checkBoxSearchForFileContent.UseVisualStyleBackColor = true;
            this.checkBoxSearchForFileContent.CheckedChanged += new System.EventHandler(this.checkBoxSearchForFileContent_CheckedChanged);
            // 
            // checkBoxReverseExtensions
            // 
            this.checkBoxReverseExtensions.AutoSize = true;
            this.checkBoxReverseExtensions.Location = new System.Drawing.Point(329, 19);
            this.checkBoxReverseExtensions.Name = "checkBoxReverseExtensions";
            this.checkBoxReverseExtensions.Size = new System.Drawing.Size(136, 17);
            this.checkBoxReverseExtensions.TabIndex = 6;
            this.checkBoxReverseExtensions.Text = "Reverse extension field";
            this.checkBoxReverseExtensions.UseVisualStyleBackColor = true;
            this.checkBoxReverseExtensions.CheckedChanged += new System.EventHandler(this.checkBoxReverseExtensions_CheckedChanged);
            // 
            // checkBoxShowHiddenFiles
            // 
            this.checkBoxShowHiddenFiles.AutoSize = true;
            this.checkBoxShowHiddenFiles.Location = new System.Drawing.Point(168, 39);
            this.checkBoxShowHiddenFiles.Name = "checkBoxShowHiddenFiles";
            this.checkBoxShowHiddenFiles.Size = new System.Drawing.Size(109, 17);
            this.checkBoxShowHiddenFiles.TabIndex = 9;
            this.checkBoxShowHiddenFiles.Text = "Show hidden files";
            this.checkBoxShowHiddenFiles.UseVisualStyleBackColor = true;
            // 
            // checkBoxIgnoreRecycledFiles
            // 
            this.checkBoxIgnoreRecycledFiles.AutoSize = true;
            this.checkBoxIgnoreRecycledFiles.Checked = true;
            this.checkBoxIgnoreRecycledFiles.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxIgnoreRecycledFiles.Location = new System.Drawing.Point(168, 19);
            this.checkBoxIgnoreRecycledFiles.Name = "checkBoxIgnoreRecycledFiles";
            this.checkBoxIgnoreRecycledFiles.Size = new System.Drawing.Size(120, 17);
            this.checkBoxIgnoreRecycledFiles.TabIndex = 5;
            this.checkBoxIgnoreRecycledFiles.Text = "Ignore recycled files";
            this.checkBoxIgnoreRecycledFiles.UseVisualStyleBackColor = true;
            // 
            // groupBoxSearchInfo
            // 
            this.groupBoxSearchInfo.Controls.Add(this.lblIgnoreExtensions);
            this.groupBoxSearchInfo.Controls.Add(this.txtBoxExtensions);
            this.groupBoxSearchInfo.Controls.Add(this.lblHeaderDirectories);
            this.groupBoxSearchInfo.Controls.Add(this.btnSearchDir);
            this.groupBoxSearchInfo.Controls.Add(this.txtBoxFileSearch);
            this.groupBoxSearchInfo.Controls.Add(this.label2);
            this.groupBoxSearchInfo.Controls.Add(this.lblSearchFile);
            this.groupBoxSearchInfo.Location = new System.Drawing.Point(14, 7);
            this.groupBoxSearchInfo.Name = "groupBoxSearchInfo";
            this.groupBoxSearchInfo.Size = new System.Drawing.Size(740, 122);
            this.groupBoxSearchInfo.TabIndex = 10;
            this.groupBoxSearchInfo.TabStop = false;
            // 
            // lblIgnoreExtensions
            // 
            this.lblIgnoreExtensions.AutoSize = true;
            this.lblIgnoreExtensions.Location = new System.Drawing.Point(378, 73);
            this.lblIgnoreExtensions.Name = "lblIgnoreExtensions";
            this.lblIgnoreExtensions.Size = new System.Drawing.Size(196, 13);
            this.lblIgnoreExtensions.TabIndex = 5;
            this.lblIgnoreExtensions.Text = "Extensions to ignore (split by semicolon):";
            // 
            // txtBoxExtensions
            // 
            this.txtBoxExtensions.Location = new System.Drawing.Point(378, 93);
            this.txtBoxExtensions.Name = "txtBoxExtensions";
            this.txtBoxExtensions.Size = new System.Drawing.Size(355, 20);
            this.txtBoxExtensions.TabIndex = 3;
            this.txtBoxExtensions.TextChanged += new System.EventHandler(this.txtBoxExtensions_TextChanged);
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
            // btnSearchDir
            // 
            this.btnSearchDir.Location = new System.Drawing.Point(709, 41);
            this.btnSearchDir.Name = "btnSearchDir";
            this.btnSearchDir.Size = new System.Drawing.Size(24, 22);
            this.btnSearchDir.TabIndex = 1;
            this.btnSearchDir.Text = "...";
            this.btnSearchDir.UseVisualStyleBackColor = true;
            this.btnSearchDir.Click += new System.EventHandler(this.btnSearchDir_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Directory to search in:";
            // 
            // lblSearchFile
            // 
            this.lblSearchFile.AutoSize = true;
            this.lblSearchFile.Location = new System.Drawing.Point(6, 73);
            this.lblSearchFile.Name = "lblSearchFile";
            this.lblSearchFile.Size = new System.Drawing.Size(348, 13);
            this.lblSearchFile.TabIndex = 2;
            this.lblSearchFile.Text = "Filename to search for (if left empty all files in the directory will be shown):";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(14, 495);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(740, 23);
            this.progressBar.TabIndex = 11;
            // 
            // btnClear
            // 
            this.btnClear.Enabled = false;
            this.btnClear.Location = new System.Drawing.Point(678, 195);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 17;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // buttonOpenFilter
            // 
            this.buttonOpenFilter.Location = new System.Drawing.Point(677, 468);
            this.buttonOpenFilter.Name = "buttonOpenFilter";
            this.buttonOpenFilter.Size = new System.Drawing.Size(75, 23);
            this.buttonOpenFilter.TabIndex = 18;
            this.buttonOpenFilter.Text = "Open filter";
            this.buttonOpenFilter.UseVisualStyleBackColor = true;
            this.buttonOpenFilter.Click += new System.EventHandler(this.buttonOpenFilter_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 525);
            this.Controls.Add(this.buttonOpenFilter);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.progressBar);
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
        private System.Windows.Forms.TextBox txtBoxFileSearch;
        private System.Windows.Forms.Button btnStopSearching;
        private System.Windows.Forms.ListView listViewResults;
        private System.Windows.Forms.CheckBox checkBoxShowDir;
        private System.Windows.Forms.GroupBox groupBoxOptions;
        private System.Windows.Forms.GroupBox groupBoxSearchInfo;
        private System.Windows.Forms.Button btnSearchDir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblSearchFile;
        private System.Windows.Forms.Label lblHeaderDirectories;
        private System.Windows.Forms.CheckBox checkBoxIgnoreRecycledFiles;
        private System.Windows.Forms.CheckBox checkBoxShowHiddenFiles;
        private System.Windows.Forms.Label lblIgnoreExtensions;
        private System.Windows.Forms.TextBox txtBoxExtensions;
        private System.Windows.Forms.CheckBox checkBoxReverseExtensions;
        private System.Windows.Forms.CheckBox checkBoxSearchForFileContent;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.CheckBox checkBoxUseProgressBar;
        private System.Windows.Forms.CheckBox checkBoxShowAllResultsAtOnce;
        private System.Windows.Forms.CheckBox checkBoxShowExceptions;
        private System.Windows.Forms.CheckBox checkBoxIgnoreFilesWithoutExtension;
        private System.Windows.Forms.CheckBox checkBoxIgnoreCaseSensitivity;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button buttonOpenFilter;
    }
}

