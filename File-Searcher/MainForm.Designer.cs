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
            this.components = new System.ComponentModel.Container();
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
            this.checkBoxShowDetailedRestrictions = new System.Windows.Forms.CheckBox();
            this.checkBoxIncludeDirFilename = new System.Windows.Forms.CheckBox();
            this.checkBoxIgnoreCaseSensitivity = new System.Windows.Forms.CheckBox();
            this.checkBoxShowFilesWithoutExtension = new System.Windows.Forms.CheckBox();
            this.checkBoxShowExceptions = new System.Windows.Forms.CheckBox();
            this.checkBoxShowProgress = new System.Windows.Forms.CheckBox();
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
            this.btnOpenFilter = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuHeaderFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHeaderAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.datePickerFilesNewerThan = new System.Windows.Forms.DateTimePicker();
            this.checkBoxFilesNewerThan = new System.Windows.Forms.CheckBox();
            this.datePickerFilesOlderThan = new System.Windows.Forms.DateTimePicker();
            this.checkBoxFilesOlderThan = new System.Windows.Forms.CheckBox();
            this.contextMenuStripListView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeFromListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxOptions.SuspendLayout();
            this.groupBoxSearchInfo.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStripListView.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBoxDirectorySearch
            // 
            this.txtBoxDirectorySearch.Location = new System.Drawing.Point(19, 75);
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
            this.btnSearch.Location = new System.Drawing.Point(678, 169);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 16;
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
            this.btnStopSearching.Location = new System.Drawing.Point(678, 195);
            this.btnStopSearching.Name = "btnStopSearching";
            this.btnStopSearching.Size = new System.Drawing.Size(75, 23);
            this.btnStopSearching.TabIndex = 17;
            this.btnStopSearching.Text = "Stop";
            this.btnStopSearching.UseVisualStyleBackColor = true;
            this.btnStopSearching.Click += new System.EventHandler(this.btnStopSearching_Click);
            // 
            // listViewResults
            // 
            this.listViewResults.FullRowSelect = true;
            this.listViewResults.Location = new System.Drawing.Point(14, 250);
            this.listViewResults.Name = "listViewResults";
            this.listViewResults.Size = new System.Drawing.Size(740, 240);
            this.listViewResults.TabIndex = 8;
            this.listViewResults.UseCompatibleStateImageBehavior = false;
            this.listViewResults.View = System.Windows.Forms.View.Details;
            this.listViewResults.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewResults_ColumnClick);
            this.listViewResults.DoubleClick += new System.EventHandler(this.listViewResults_DoubleClick);
            this.listViewResults.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewResults_MouseClick);
            // 
            // checkBoxShowDir
            // 
            this.checkBoxShowDir.AutoSize = true;
            this.checkBoxShowDir.Checked = true;
            this.checkBoxShowDir.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxShowDir.Location = new System.Drawing.Point(324, 19);
            this.checkBoxShowDir.Name = "checkBoxShowDir";
            this.checkBoxShowDir.Size = new System.Drawing.Size(124, 17);
            this.checkBoxShowDir.TabIndex = 6;
            this.checkBoxShowDir.Text = "Show directory of file";
            this.checkBoxShowDir.UseVisualStyleBackColor = true;
            this.checkBoxShowDir.CheckedChanged += new System.EventHandler(this.checkBoxShowDir_CheckedChanged);
            // 
            // groupBoxOptions
            // 
            this.groupBoxOptions.Controls.Add(this.checkBoxShowDetailedRestrictions);
            this.groupBoxOptions.Controls.Add(this.checkBoxIncludeDirFilename);
            this.groupBoxOptions.Controls.Add(this.checkBoxIgnoreCaseSensitivity);
            this.groupBoxOptions.Controls.Add(this.checkBoxShowFilesWithoutExtension);
            this.groupBoxOptions.Controls.Add(this.checkBoxShowExceptions);
            this.groupBoxOptions.Controls.Add(this.checkBoxShowProgress);
            this.groupBoxOptions.Controls.Add(this.checkBoxSearchForFileContent);
            this.groupBoxOptions.Controls.Add(this.checkBoxReverseExtensions);
            this.groupBoxOptions.Controls.Add(this.checkBoxShowHiddenFiles);
            this.groupBoxOptions.Controls.Add(this.checkBoxIgnoreRecycledFiles);
            this.groupBoxOptions.Controls.Add(this.checkBoxShowDir);
            this.groupBoxOptions.Controls.Add(this.labelOptions);
            this.groupBoxOptions.Controls.Add(this.checkBoxIncludeSubDirs);
            this.groupBoxOptions.Location = new System.Drawing.Point(13, 163);
            this.groupBoxOptions.Name = "groupBoxOptions";
            this.groupBoxOptions.Size = new System.Drawing.Size(659, 81);
            this.groupBoxOptions.TabIndex = 10;
            this.groupBoxOptions.TabStop = false;
            // 
            // checkBoxShowDetailedRestrictions
            // 
            this.checkBoxShowDetailedRestrictions.AutoSize = true;
            this.checkBoxShowDetailedRestrictions.Location = new System.Drawing.Point(511, 58);
            this.checkBoxShowDetailedRestrictions.Name = "checkBoxShowDetailedRestrictions";
            this.checkBoxShowDetailedRestrictions.Size = new System.Drawing.Size(146, 17);
            this.checkBoxShowDetailedRestrictions.TabIndex = 15;
            this.checkBoxShowDetailedRestrictions.Text = "Show detailed restrictions";
            this.checkBoxShowDetailedRestrictions.UseVisualStyleBackColor = true;
            this.checkBoxShowDetailedRestrictions.CheckedChanged += new System.EventHandler(this.checkBoxShowDetailedRestrictions_CheckedChanged);
            // 
            // checkBoxIncludeDirFilename
            // 
            this.checkBoxIncludeDirFilename.AutoSize = true;
            this.checkBoxIncludeDirFilename.Enabled = false;
            this.checkBoxIncludeDirFilename.Location = new System.Drawing.Point(324, 58);
            this.checkBoxIncludeDirFilename.Name = "checkBoxIncludeDirFilename";
            this.checkBoxIncludeDirFilename.Size = new System.Drawing.Size(170, 17);
            this.checkBoxIncludeDirFilename.TabIndex = 14;
            this.checkBoxIncludeDirFilename.Text = "Search directory for criteria too";
            this.checkBoxIncludeDirFilename.UseVisualStyleBackColor = true;
            // 
            // checkBoxIgnoreCaseSensitivity
            // 
            this.checkBoxIgnoreCaseSensitivity.AutoSize = true;
            this.checkBoxIgnoreCaseSensitivity.Checked = true;
            this.checkBoxIgnoreCaseSensitivity.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxIgnoreCaseSensitivity.Enabled = false;
            this.checkBoxIgnoreCaseSensitivity.Location = new System.Drawing.Point(511, 19);
            this.checkBoxIgnoreCaseSensitivity.Name = "checkBoxIgnoreCaseSensitivity";
            this.checkBoxIgnoreCaseSensitivity.Size = new System.Drawing.Size(130, 17);
            this.checkBoxIgnoreCaseSensitivity.TabIndex = 7;
            this.checkBoxIgnoreCaseSensitivity.Text = "Ignore case sensitivity";
            this.checkBoxIgnoreCaseSensitivity.UseVisualStyleBackColor = true;
            // 
            // checkBoxShowFilesWithoutExtension
            // 
            this.checkBoxShowFilesWithoutExtension.AutoSize = true;
            this.checkBoxShowFilesWithoutExtension.Checked = true;
            this.checkBoxShowFilesWithoutExtension.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxShowFilesWithoutExtension.Location = new System.Drawing.Point(9, 39);
            this.checkBoxShowFilesWithoutExtension.Name = "checkBoxShowFilesWithoutExtension";
            this.checkBoxShowFilesWithoutExtension.Size = new System.Drawing.Size(159, 17);
            this.checkBoxShowFilesWithoutExtension.TabIndex = 8;
            this.checkBoxShowFilesWithoutExtension.Text = "Show files without extension";
            this.checkBoxShowFilesWithoutExtension.UseVisualStyleBackColor = true;
            // 
            // checkBoxShowExceptions
            // 
            this.checkBoxShowExceptions.AutoSize = true;
            this.checkBoxShowExceptions.Location = new System.Drawing.Point(9, 58);
            this.checkBoxShowExceptions.Name = "checkBoxShowExceptions";
            this.checkBoxShowExceptions.Size = new System.Drawing.Size(131, 17);
            this.checkBoxShowExceptions.TabIndex = 12;
            this.checkBoxShowExceptions.Text = "Show exception errors";
            this.checkBoxShowExceptions.UseVisualStyleBackColor = true;
            // 
            // checkBoxShowProgress
            // 
            this.checkBoxShowProgress.AutoSize = true;
            this.checkBoxShowProgress.Location = new System.Drawing.Point(511, 39);
            this.checkBoxShowProgress.Name = "checkBoxShowProgress";
            this.checkBoxShowProgress.Size = new System.Drawing.Size(114, 17);
            this.checkBoxShowProgress.TabIndex = 11;
            this.checkBoxShowProgress.Text = "Show progress bar";
            this.checkBoxShowProgress.UseVisualStyleBackColor = true;
            this.checkBoxShowProgress.CheckedChanged += new System.EventHandler(this.checkBoxUseProgressBar_CheckedChanged);
            // 
            // checkBoxSearchForFileContent
            // 
            this.checkBoxSearchForFileContent.AutoSize = true;
            this.checkBoxSearchForFileContent.Location = new System.Drawing.Point(324, 39);
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
            this.checkBoxReverseExtensions.Location = new System.Drawing.Point(168, 58);
            this.checkBoxReverseExtensions.Name = "checkBoxReverseExtensions";
            this.checkBoxReverseExtensions.Size = new System.Drawing.Size(136, 17);
            this.checkBoxReverseExtensions.TabIndex = 13;
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
            this.groupBoxSearchInfo.Location = new System.Drawing.Point(14, 33);
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
            this.progressBar.Location = new System.Drawing.Point(14, 523);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(740, 23);
            this.progressBar.TabIndex = 11;
            // 
            // btnClear
            // 
            this.btnClear.Enabled = false;
            this.btnClear.Location = new System.Drawing.Point(678, 221);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 18;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnOpenFilter
            // 
            this.btnOpenFilter.Enabled = false;
            this.btnOpenFilter.Location = new System.Drawing.Point(677, 494);
            this.btnOpenFilter.Name = "btnOpenFilter";
            this.btnOpenFilter.Size = new System.Drawing.Size(75, 23);
            this.btnOpenFilter.TabIndex = 19;
            this.btnOpenFilter.Text = "Open filter";
            this.btnOpenFilter.UseVisualStyleBackColor = true;
            this.btnOpenFilter.Click += new System.EventHandler(this.buttonOpenFilter_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuHeaderFiles,
            this.menuHeaderAbout});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(765, 24);
            this.menuStrip1.TabIndex = 19;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuHeaderFiles
            // 
            this.menuHeaderFiles.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemSettings,
            this.toolStripSeparator1,
            this.menuItemExit});
            this.menuHeaderFiles.Name = "menuHeaderFiles";
            this.menuHeaderFiles.Size = new System.Drawing.Size(37, 20);
            this.menuHeaderFiles.Text = "File";
            // 
            // menuItemSettings
            // 
            this.menuItemSettings.Name = "menuItemSettings";
            this.menuItemSettings.Size = new System.Drawing.Size(116, 22);
            this.menuItemSettings.Text = "Settings";
            this.menuItemSettings.Click += new System.EventHandler(this.menuItemSettings_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(113, 6);
            // 
            // menuItemExit
            // 
            this.menuItemExit.Name = "menuItemExit";
            this.menuItemExit.Size = new System.Drawing.Size(116, 22);
            this.menuItemExit.Text = "Exit";
            this.menuItemExit.Click += new System.EventHandler(this.TryCloseApplication);
            // 
            // menuHeaderAbout
            // 
            this.menuHeaderAbout.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemAbout});
            this.menuHeaderAbout.Name = "menuHeaderAbout";
            this.menuHeaderAbout.Size = new System.Drawing.Size(52, 20);
            this.menuHeaderAbout.Text = "About";
            // 
            // menuItemAbout
            // 
            this.menuItemAbout.Name = "menuItemAbout";
            this.menuItemAbout.Size = new System.Drawing.Size(107, 22);
            this.menuItemAbout.Text = "About";
            this.menuItemAbout.Click += new System.EventHandler(this.menuItemAbout_Click);
            // 
            // datePickerFilesNewerThan
            // 
            this.datePickerFilesNewerThan.Enabled = false;
            this.datePickerFilesNewerThan.Location = new System.Drawing.Point(131, 251);
            this.datePickerFilesNewerThan.Name = "datePickerFilesNewerThan";
            this.datePickerFilesNewerThan.Size = new System.Drawing.Size(210, 20);
            this.datePickerFilesNewerThan.TabIndex = 21;
            this.datePickerFilesNewerThan.Value = new System.DateTime(2013, 9, 4, 10, 7, 46, 0);
            // 
            // checkBoxFilesNewerThan
            // 
            this.checkBoxFilesNewerThan.AutoSize = true;
            this.checkBoxFilesNewerThan.Location = new System.Drawing.Point(22, 253);
            this.checkBoxFilesNewerThan.Name = "checkBoxFilesNewerThan";
            this.checkBoxFilesNewerThan.Size = new System.Drawing.Size(106, 17);
            this.checkBoxFilesNewerThan.TabIndex = 20;
            this.checkBoxFilesNewerThan.Text = "Files newer than:";
            this.checkBoxFilesNewerThan.UseVisualStyleBackColor = true;
            this.checkBoxFilesNewerThan.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // datePickerFilesOlderThan
            // 
            this.datePickerFilesOlderThan.Enabled = false;
            this.datePickerFilesOlderThan.Location = new System.Drawing.Point(462, 251);
            this.datePickerFilesOlderThan.Name = "datePickerFilesOlderThan";
            this.datePickerFilesOlderThan.Size = new System.Drawing.Size(210, 20);
            this.datePickerFilesOlderThan.TabIndex = 23;
            this.datePickerFilesOlderThan.Value = new System.DateTime(2013, 9, 4, 10, 7, 46, 0);
            // 
            // checkBoxFilesOlderThan
            // 
            this.checkBoxFilesOlderThan.AutoSize = true;
            this.checkBoxFilesOlderThan.Location = new System.Drawing.Point(359, 253);
            this.checkBoxFilesOlderThan.Name = "checkBoxFilesOlderThan";
            this.checkBoxFilesOlderThan.Size = new System.Drawing.Size(100, 17);
            this.checkBoxFilesOlderThan.TabIndex = 22;
            this.checkBoxFilesOlderThan.Text = "Files older than:";
            this.checkBoxFilesOlderThan.UseVisualStyleBackColor = true;
            this.checkBoxFilesOlderThan.CheckedChanged += new System.EventHandler(this.checkBoxFilesOlderThan_CheckedChanged);
            // 
            // contextMenuStripListView
            // 
            this.contextMenuStripListView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openDirectoryToolStripMenuItem,
            this.removeFromListToolStripMenuItem});
            this.contextMenuStripListView.Name = "contextMenuStripListView";
            this.contextMenuStripListView.Size = new System.Drawing.Size(165, 70);
            // 
            // openDirectoryToolStripMenuItem
            // 
            this.openDirectoryToolStripMenuItem.Name = "openDirectoryToolStripMenuItem";
            this.openDirectoryToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.openDirectoryToolStripMenuItem.Text = "Open directory";
            this.openDirectoryToolStripMenuItem.Click += new System.EventHandler(this.openDirectoryToolStripMenuItem_Click);
            // 
            // removeFromListToolStripMenuItem
            // 
            this.removeFromListToolStripMenuItem.Name = "removeFromListToolStripMenuItem";
            this.removeFromListToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.removeFromListToolStripMenuItem.Text = "Remove from list";
            this.removeFromListToolStripMenuItem.Click += new System.EventHandler(this.removeFromListToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 521);
            this.Controls.Add(this.btnOpenFilter);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.listViewResults);
            this.Controls.Add(this.btnStopSearching);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtBoxDirectorySearch);
            this.Controls.Add(this.groupBoxSearchInfo);
            this.Controls.Add(this.groupBoxOptions);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.datePickerFilesOlderThan);
            this.Controls.Add(this.datePickerFilesNewerThan);
            this.Controls.Add(this.checkBoxFilesOlderThan);
            this.Controls.Add(this.checkBoxFilesNewerThan);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "File Searcher";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.groupBoxOptions.ResumeLayout(false);
            this.groupBoxOptions.PerformLayout();
            this.groupBoxSearchInfo.ResumeLayout(false);
            this.groupBoxSearchInfo.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStripListView.ResumeLayout(false);
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
        private System.Windows.Forms.CheckBox checkBoxShowProgress;
        private System.Windows.Forms.CheckBox checkBoxShowExceptions;
        private System.Windows.Forms.CheckBox checkBoxShowFilesWithoutExtension;
        private System.Windows.Forms.CheckBox checkBoxIgnoreCaseSensitivity;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnOpenFilter;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuHeaderFiles;
        private System.Windows.Forms.ToolStripMenuItem menuItemSettings;
        private System.Windows.Forms.ToolStripMenuItem menuItemExit;
        private System.Windows.Forms.ToolStripMenuItem menuHeaderAbout;
        private System.Windows.Forms.ToolStripMenuItem menuItemAbout;
        private System.Windows.Forms.CheckBox checkBoxIncludeDirFilename;
        private System.Windows.Forms.DateTimePicker datePickerFilesNewerThan;
        private System.Windows.Forms.CheckBox checkBoxFilesNewerThan;
        private System.Windows.Forms.DateTimePicker datePickerFilesOlderThan;
        private System.Windows.Forms.CheckBox checkBoxFilesOlderThan;
        public System.Windows.Forms.ListView listViewResults;
        public System.Windows.Forms.CheckBox checkBoxShowDetailedRestrictions;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripListView;
        private System.Windows.Forms.ToolStripMenuItem openDirectoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeFromListToolStripMenuItem;
    }
}

