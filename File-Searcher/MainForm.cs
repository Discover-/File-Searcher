using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Diagnostics;
using Timer = System.Windows.Forms.Timer;
using File_Searcher.Properties;

namespace File_Searcher
{
    public sealed partial class MainForm : Form
    {
        private Thread searchThread = null;
        private int oldWidth = 0, originalHeight = 0, originalWidth = 0, originalResultsHeight = 0;
        private readonly ListViewColumnSorter lvwColumnSorter = new ListViewColumnSorter();
        private readonly List<ListViewItem> listViewResultsContainer = new List<ListViewItem>();
        private readonly List<Control> controlsToDisable = new List<Control>();
        private readonly List<string> exceptionStringStore = new List<string>();
        public Timer timerMoveForProgressBar = null, timerMoveForDetailedRestrictions = null;
        private bool checkBoxIncludeDirFilenameWasEnabled = false;

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MinimumSize = new Size(Width, Height);
            MaximumSize = new Size(Width + 700, Height);
            //MaximumSize = new Size(Width + 700, Height + 50);

            originalHeight = Height;
            originalWidth = Width;

            timerMoveForProgressBar = new Timer { Enabled = false, Interval = 16 };
            timerMoveForProgressBar.Tick += timerMoveForProgressBar_Tick;

            timerMoveForDetailedRestrictions = new Timer { Enabled = false, Interval = 16 };
            timerMoveForDetailedRestrictions.Tick += timerMoveForDetailedRestrictions_Tick;

            listViewResults.Columns.Add("Extension", 60, HorizontalAlignment.Right);
            listViewResults.Columns.Add("Name", 430, HorizontalAlignment.Left);
            listViewResults.Columns.Add("Size", 35, HorizontalAlignment.Right);
            listViewResults.Columns.Add("Sizetype", 55, HorizontalAlignment.Right);
            listViewResults.Columns.Add("Last Modified", 138, HorizontalAlignment.Right);
            listViewResults.Columns.Add("", 0, HorizontalAlignment.Right);

            //! Set all anchors; this makes the controls properly resize along with the form when it gets resized.
            InitializeAnchors();

            oldWidth = Width; //! We store the initial width of the form so that we know how far the form was resized
                              //! which allows us to determine how many pixels the 'Name' column need to be increased.

            //! Initialize progress bar; default should be on 0%.
            progressBar.Minimum = 0;
            progressBar.Maximum = 100;
            progressBar.Value = 0;

            //! Add all controls we disable once we start searching to the list controlling this
            FillControlsToDisable();

            addTooltip(checkBoxIgnoreRecycledFiles, "A lot of files found when searching through a root directory like the C disk are found in a recycle bin folder which make no sense if listed.");
            addTooltip(checkBoxReverseExtensions, "Checking this will mean the text box saying 'Extensions to ignore' will now be reversed, thus only show files containing extensions in that field");
            addTooltip(checkBoxSearchForFileContent, "This will make the 'Filename' field transfer into a field to determine which text must be included in the searched files in order to show uo");
            addTooltip(checkBoxShowHiddenFiles, "Determines whether or not you want to show hidden files or not.");
            addTooltip(checkBoxShowExceptions, "This is basically meant for error-tracking. This software is written in C# which means sometimes code return errors and only developers can see them (under certain circumstances). Checking this will show the errors in a new window when the process finished.");
            addTooltip(checkBoxShowProgress, "This will enable the progressbar shown at the bottom of the application. The reason it's default unchecked is because it will make the process take quite a lot longer.");
            addTooltip(checkBoxShowFilesWithoutExtension, "Checking this will make files without any extension be shown as well (like most of the README files).");
            addTooltip(checkBoxIgnoreCaseSensitivity, "Checking this will allow you to ignore case sensitivity in the file name/content search field.");
            addTooltip(checkBoxIncludeDirFilename, "Checking this will mean that the criteria filled in the 'Filename' criteria field is also searched for in the directory. So if the directory of a file is 'C:/ExampleFolder/VersionTwo/version.txt' and the criteria is 'two', it will only show this item if this checkbox is checked.");

            txtBoxDirectorySearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtBoxDirectorySearch.AutoCompleteSource = AutoCompleteSource.FileSystemDirectories;

            menuItemExit.ShortcutKeys = (Keys.Shift | Keys.F5);
            menuItemExit.ShortcutKeyDisplayString = "(Shift + F5)";

            menuItemSettings.ShortcutKeys = Keys.F1;
            menuItemSettings.ShortcutKeyDisplayString = "(F1)";

            menuItemAbout.ShortcutKeys = (Keys.Alt | Keys.F1);
            menuItemAbout.ShortcutKeyDisplayString = "(Alt + F1)";

            originalResultsHeight = listViewResults.Height;

            if (Settings.Default.AlwaysShowDetailedRestrictions)
            {
                checkBoxShowDetailedRestrictions.Checked = true;
                listViewResults.Height -= 25;
                listViewResults.Location = new Point(listViewResults.Location.X, listViewResults.Location.Y + 25);
            }
        }

        private void InitializeAnchors()
        {
            listViewResults.Anchor = AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Left;
            txtBoxDirectorySearch.Anchor = AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Left;
            groupBoxSearchInfo.Anchor = AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Left;
            groupBoxOptions.Anchor = AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Left;
            progressBar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Left;
            txtBoxExtensions.Anchor = AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Left;
            btnSearchDir.Anchor = AnchorStyles.Right;
            btnSearch.Anchor = AnchorStyles.Right;
            btnClear.Anchor = AnchorStyles.Right;
            btnStopSearching.Anchor = AnchorStyles.Right;
            btnOpenFilter.Anchor = AnchorStyles.Right;
        }
        
        private void FillControlsToDisable()
        {
            controlsToDisable.Clear();
            controlsToDisable.Add(checkBoxIgnoreRecycledFiles);
            controlsToDisable.Add(checkBoxIncludeSubDirs);
            controlsToDisable.Add(checkBoxReverseExtensions);
            controlsToDisable.Add(checkBoxSearchForFileContent);
            controlsToDisable.Add(checkBoxShowDir);
            controlsToDisable.Add(checkBoxShowHiddenFiles);
            controlsToDisable.Add(checkBoxShowProgress);
            controlsToDisable.Add(checkBoxShowExceptions);
            controlsToDisable.Add(checkBoxShowFilesWithoutExtension);
            controlsToDisable.Add(txtBoxDirectorySearch);
            controlsToDisable.Add(txtBoxFileSearch);
            controlsToDisable.Add(txtBoxExtensions);
            controlsToDisable.Add(btnSearchDir);
            controlsToDisable.Add(btnOpenFilter);
            controlsToDisable.Add(checkBoxShowDetailedRestrictions);
            controlsToDisable.Add(btnClear); //! This one should be added no matter what

            if (checkBoxIgnoreCaseSensitivity.Enabled)
                controlsToDisable.Add(checkBoxIgnoreCaseSensitivity);

            if (checkBoxIncludeDirFilename.Enabled)
                controlsToDisable.Add(checkBoxIncludeDirFilename);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            //! We need a try-catch block because this is also called when the app is created (and listViewResults' columns are not yet initialized).
            try
            {
                listViewResults.Columns[1].Width -= oldWidth - Width;
                oldWidth = Width;
            }
            catch (Exception exception)
            {
                if (checkBoxShowExceptions.Checked)
                    exceptionStringStore.Add(exception.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listViewResultsContainer.Clear();
            searchThread = new Thread(StartSearching);
            searchThread.Start();
        }

        private void StartSearching()
        {
            string searchDirectory = txtBoxDirectorySearch.Text;
            string searchFileText = txtBoxFileSearch.Text;
            string extensionField = txtBoxExtensions.Text;

            if (!txtBoxDirectorySearch.Text.EndsWith("\\"))
                searchDirectory += "\\";

            if (String.IsNullOrWhiteSpace(searchDirectory))
            {
                MessageBox.Show("The search directory field was left empty!", "An error has occurred!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Directory.Exists(searchDirectory))
            {
                MessageBox.Show("The directory to search for could not be found!", "An error has occurred!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Path.HasExtension(searchDirectory))
            {
                MessageBox.Show("The search directory field contains an extension!", "An error has occurred!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!String.IsNullOrWhiteSpace(searchFileText) && Directory.Exists(searchFileText))
            {
                MessageBox.Show("The field for filename contains a directory!", "An error has occurred!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!String.IsNullOrWhiteSpace(extensionField))
            {
                if (Directory.Exists(extensionField))
                {
                    MessageBox.Show("The field for extensions contains a directory!", "An error has occurred!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (extensionField.Substring(extensionField.Length - 1) == ";")
                {
                    MessageBox.Show("The field for extensions may not end with a semicolon!", "An error has occurred!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string[] splitExtensionsField = txtBoxExtensions.Text.Split(';');
                string duplicateExtension = "";

                if (ArrayHasDuplicates(splitExtensionsField, ref duplicateExtension))
                {
                    MessageBox.Show("The extension '" + duplicateExtension + "' was listed more than once!", "An error has occurred!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                foreach (string ext in splitExtensionsField)
                {
                    if (ext.Substring(0, 1) != ".")
                    {
                        MessageBox.Show("The extension '" + ext + "' did not start with a period!", "An error has occurred!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            FillControlsToDisable();

            UseWaitCursor = true;

            SetEnabledOfControl(btnSearch, false);
            SetEnabledOfControl(btnStopSearching, true);

            checkBoxIncludeDirFilenameWasEnabled = checkBoxIncludeDirFilename.Enabled;

            foreach (var control in controlsToDisable)
                SetEnabledOfControl(control, false);

            SetProgressBarMaxValue(progressBar, 100);
            SetProgressBarValue(progressBar, 0);

            ClearListViewResults(listViewResults);

            if (checkBoxShowProgress.Checked)
            {
                var directoryCountTotal = 0;
                GetDirectoryCount(searchDirectory, ref directoryCountTotal);
                SetProgressBarMaxValue(progressBar, directoryCountTotal);
            }

            //! Function also fills up the listbox on the fly
            var allFiles = GetAllFilesFromDirectoryAndFillResults(searchDirectory, checkBoxIncludeSubDirs.Checked);

            if (String.IsNullOrWhiteSpace(allFiles))
            {
                var illegalCharacters = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());

                if (!String.IsNullOrWhiteSpace(txtBoxFileSearch.Text) && !String.IsNullOrWhiteSpace(extensionField))
                {
                    for (var i = 0; i < illegalCharacters.Count(); ++i)
                    {
                        if (!txtBoxFileSearch.Text.Contains(illegalCharacters[i]))
                            continue;

                        MessageBox.Show("The searched directory contains no files matching the given criteria (most likely because you specified an illegal character in one of the criteria fields).", "An error has occurred!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                }

                if ((checkBoxSearchForFileContent.Checked && !String.IsNullOrWhiteSpace(txtBoxFileSearch.Text)) || Path.HasExtension(txtBoxFileSearch.Text) || Path.HasExtension(extensionField))
                    MessageBox.Show("The searched directory contains no files matching the given criteria.", "An error has occurred!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("The searched directory contains no files at all.", "An error has occurred!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                SetEnabledOfControl(btnSearch, true);
                SetEnabledOfControl(btnStopSearching, false);

                SetProgressBarMaxValue(progressBar, 100);
                SetProgressBarValue(progressBar, 0);

                UseWaitCursor = false;

                foreach (var control in controlsToDisable)
                    SetEnabledOfControl(control, true);

                return;
            }

            SetEnabledOfControl(btnSearch, true);
            SetEnabledOfControl(btnStopSearching, false);

            SetProgressBarMaxValue(progressBar, 100);
            SetProgressBarValue(progressBar, 0);

            UseWaitCursor = false;

            foreach (var control in controlsToDisable)
                SetEnabledOfControl(control, true);
        }

        private void GetDirectoryCount(string searchDirectory, ref int directoryCountTotal)
        {
            //! We need a try-catch block because accessing files without permissions does not work for some reason
            //! and breaks with an exception.
            try
            {
                var directories = Directory.GetDirectories(searchDirectory);
                directoryCountTotal += directories.Count();

                foreach (string dir in directories)
                    GetDirectoryCount(dir, ref directoryCountTotal);
            }
            catch (Exception exception)
            {
                if (checkBoxShowExceptions.Checked)
                    exceptionStringStore.Add(exception.ToString());
            }
        }

        private string GetAllFilesFromDirectoryAndFillResults(string directorySearch, bool includingSubDirs)
        {
            var stringBuilder = new StringBuilder(100);

            //! We need a try-catch block because accessing files without permissions does not work for some reason
            //! and breaks with an exception.
            try
            {
                string search = txtBoxFileSearch.Text;
                bool hasSearch = search.Length > 0;
                IEnumerable<string> enumerator = includingSubDirs ? FastDirectoryEnumerator.GetAllDirectories(directorySearch) : FastDirectoryEnumerator.GetDirectories(directorySearch, "*");

                foreach (var directory in enumerator)
                {
                    if (checkBoxShowProgress.Checked)
                        SetProgressBarValue(progressBar, progressBar.Value + 1);

                    foreach (FileData file in FastDirectoryEnumerator.GetFiles(directory, "*"))
                    {
                        string fileName = file.Path;

                        if (fileName.Length == 0)
                            continue;

                        if (checkBoxIgnoreRecycledFiles.Checked && fileName.IndexOf("recycle", StringComparison.OrdinalIgnoreCase) >= 0)
                            continue;

                        if (!checkBoxShowHiddenFiles.Checked && (file.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
                            continue;

                        if (hasSearch)
                        {
                            var fileToCheck = fileName;

                            if (!checkBoxIncludeDirFilename.Checked && checkBoxIncludeDirFilenameWasEnabled)
                                fileToCheck = Path.GetFileName(fileName);

                            if (checkBoxSearchForFileContent.Checked)
                            {
                                if (checkBoxIgnoreCaseSensitivity.Checked)
                                {
                                    if (!File.ReadAllText(fileName).ToLower().Contains(search.ToLower()))
                                        continue;
                                }
                                else if (!File.ReadAllText(fileName).Contains(search))
                                    continue;
                            }
                            else
                            {
                                //! Can't add an .Enabled call here because it is disabled during the process
                                if (checkBoxIgnoreCaseSensitivity.Checked)// && checkBoxIgnoreCaseSensitivity.Enabled)
                                {
                                    if (fileToCheck.IndexOf(search, StringComparison.OrdinalIgnoreCase) <= 0)
                                        continue;
                                }
                                else if (fileToCheck.IndexOf(search) <= 0)
                                    continue;
                            }
                        }

                        if (!checkBoxShowFilesWithoutExtension.Checked && !Path.HasExtension(fileName))
                            continue;

                        if (!String.IsNullOrWhiteSpace(txtBoxExtensions.Text))
                        {
                            //! If we only list specific extensions (field is not left empty) and the given file has no
                            //! extension, we can safely ignore it.
                            //if (checkBoxReverseExtensions.Checked && !Path.HasExtension(file))
                            //    continue;

                            string[] splitExtensionsField = txtBoxExtensions.Text.Split(';');
                            bool foundExtensionMatch = splitExtensionsField.Any(t => fileName.EndsWith(t, StringComparison.OrdinalIgnoreCase));

                            if (foundExtensionMatch)
                            {
                                if (!checkBoxReverseExtensions.Checked) //! Extensions to show instead of ignore in the field now
                                    continue;
                            }
                            else if (checkBoxReverseExtensions.Checked)
                                continue;
                        }

                        if (checkBoxShowDetailedRestrictions.Checked)
                        {
                            if (checkBoxFilesNewerThan.Checked)
                                if (!(DateTime.Compare(file.CreationTime, datePickerFilesNewerThan.Value.Date) > 0))
                                    continue;

                            if (checkBoxFilesOlderThan.Checked)
                                if (!(DateTime.Compare(file.CreationTime, datePickerFilesOlderThan.Value.Date) < 0))
                                    continue;
                        }

                        stringBuilder.AppendLine(file.Name);

                        string extension = Path.GetExtension(fileName).ToLower();
                        string fileSizeType = "";
                        string fileSize = convertBytesFormat(file.Size, ref fileSizeType);

                        if (!checkBoxShowDir.Checked)
                            fileName = Path.GetFileName(file.Name);

                        AddItemToListView(listViewResults, new ListViewItem(new[] { extension, fileName, fileSize, fileSizeType, file.LastWriteTime.ToString(CultureInfo.InvariantCulture), fileName }));
                    }
                }
            }
            catch (Exception exception)
            {
                if (checkBoxShowExceptions.Checked)
                    exceptionStringStore.Add(exception.ToString());
            }

            return stringBuilder.ToString();
        }

        private void btnSearchDir_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog { Description = "Select a directory in which you want to search for files and directories." };

            if (txtBoxDirectorySearch.Text.Length > 0 && Directory.Exists(txtBoxDirectorySearch.Text))
                fbd.SelectedPath = txtBoxDirectorySearch.Text;

            if (fbd.ShowDialog() == DialogResult.OK)
                txtBoxDirectorySearch.Text = fbd.SelectedPath;
        }

        private void btnStopSearching_Click(object sender, EventArgs e)
        {
            if (searchThread != null && searchThread.IsAlive)
            {
                searchThread.Abort();
                searchThread = null;
            }

            SetEnabledOfControl(btnSearch, true);
            SetEnabledOfControl(btnStopSearching, false);

            SetProgressBarMaxValue(progressBar, 100);
            SetProgressBarValue(progressBar, 0);

            UseWaitCursor = false;

            foreach (var control in controlsToDisable)
                SetEnabledOfControl(control, true);

            if (checkBoxShowExceptions.Checked && exceptionStringStore.Count > 0)
            {
                new ExceptionForm(exceptionStringStore).ShowDialog(this);
                exceptionStringStore.Clear();
            }
        }

        private void checkBoxShowDir_CheckedChanged(object sender, EventArgs e)
        {
            //! Update current results with path. SubItems[5] returns text of a column which is not visible (Width = 0)
            //! and which contains the full directory/path to the file.
            if (checkBoxShowDir.Checked)
            {
                foreach (ListViewItem item in listViewResults.Items)
                    item.SubItems[1].Text = item.SubItems[5].Text;
            }
            else
            {
                foreach (ListViewItem item in listViewResults.Items)
                    item.SubItems[1].Text = Path.GetFileName(item.SubItems[1].Text);
            }
        }

        private string convertBytesFormat(long bytes, ref string fileType)
        {
            if (fileType == null)
                throw new ArgumentNullException("fileType");

            string[] sizes = { "B", "KB", "MB", "GB", "TB", "PB" };
            var order = 0;

            while (bytes >= 1024 && order + 1 < sizes.Length)
            {
                order++;
                bytes = bytes / 1024;
            }

            fileType = sizes[order];
            return String.Format("{0:0.##}", bytes);
        }

        private void checkBoxReverseExtensions_CheckedChanged(object sender, EventArgs e)
        {
            //! Using String::Replace doesn't have the same effect for some reason
            if (checkBoxReverseExtensions.Checked)
                lblIgnoreExtensions.Text = "Extensions to show (split by semicolon):";
            else
                lblIgnoreExtensions.Text = "Extensions to ignore (split by semicolon):";
        }

        private void checkBoxSearchForFileContent_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxIncludeDirFilename.Enabled = !checkBoxSearchForFileContent.Checked;

            if (checkBoxSearchForFileContent.Checked)
                lblSearchFile.Text = "File content to search for (if left empty all files in the directory will be shown):";
            else
                lblSearchFile.Text = "Filename to search for (if left empty all files in the directory will be shown):";
        }

        private void listViewResults_DoubleClick(object sender, EventArgs e)
        {
            var selectedItemName = listViewResults.SelectedItems[0].SubItems[5].Text;

            if (String.IsNullOrWhiteSpace(selectedItemName))
                return;

            //! Need to use a variable to store whether or not the user had shift down before the 'Are you sure?'
            //! box was opened, otherwise it would only work if Shift was down when the confirmation box was closed.
            var hadShiftDown = (Control.ModifierKeys & Keys.Shift) != 0;

            if (!Settings.Default.PromptOpenFile || MessageBox.Show(String.Format("Are you sure you want to open this {0}?", hadShiftDown ? "directory" : "file"), "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                StartProcess(hadShiftDown ? Path.GetDirectoryName(selectedItemName) : selectedItemName);
        }

        private void StartProcess(string filename)
        {
            try
            {
                new Process { StartInfo = new ProcessStartInfo(filename) }.Start();
            }
            catch (Exception)
            {
                MessageBox.Show(String.Format("The process '{0}' could not be opened!", Path.GetFileName(filename)), "An error has occurred!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listViewResults_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            var myListView = (ListView)sender;
            myListView.ListViewItemSorter = lvwColumnSorter;

            //! Determine if clicked column is already the column that is being sorted
            if (e.Column != lvwColumnSorter.SortColumn)
            {
                //! Set the column number that is to be sorted; default to ascending
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }
            else
                //! Reverse the current sort direction for this column
                lvwColumnSorter.Order = lvwColumnSorter.Order == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;

            //! Perform the sort with these new sort options
            myListView.Sort();
        }

        private void addTooltip(Control control, string tooltipMsg)
        {
            var toolTip = new ToolTip();
            toolTip.SetToolTip(control, tooltipMsg);
            toolTip.ShowAlways = true;
        }

        private bool ArrayHasDuplicates(string[] arrayString, ref string duplicateString)
        {
            var listValues = new List<string>();
            foreach (string str in arrayString)
            {
                if (listValues.Contains(str))
                {
                    duplicateString = str;
                    return true;
                }

                listValues.Add(str);
            }

            return false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            listViewResults.Clear();
            btnClear.Enabled = false;
        }

        private void txtBoxFileSearch_TextChanged(object sender, EventArgs e)
        {
            checkBoxIgnoreCaseSensitivity.Enabled = (!String.IsNullOrWhiteSpace(txtBoxFileSearch.Text) || !String.IsNullOrWhiteSpace(txtBoxExtensions.Text));

            if (!checkBoxSearchForFileContent.Checked)
                checkBoxIncludeDirFilename.Enabled = checkBoxIgnoreCaseSensitivity.Enabled;
        }

        private void txtBoxExtensions_TextChanged(object sender, EventArgs e)
        {
            checkBoxIgnoreCaseSensitivity.Enabled = (!String.IsNullOrWhiteSpace(txtBoxFileSearch.Text) || !String.IsNullOrWhiteSpace(txtBoxExtensions.Text));
        }

        private void buttonOpenFilter_Click(object sender, EventArgs e)
        {
            new FilteredResultsForm(listViewResults.Items).ShowDialog(this);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    if (listViewResults.SelectedItems.Count > 0 && !(txtBoxDirectorySearch.Focused || txtBoxFileSearch.Focused || txtBoxExtensions.Focused))
                    {
                        var hadShiftDown = ((Control.ModifierKeys & Keys.Shift) != 0);

                        if (!Settings.Default.PromptOpenFile || MessageBox.Show(String.Format("Are you sure you want to open {0}?", listViewResults.SelectedItems.Count > 1 ? String.Format("the selected ({0}) {1}", listViewResults.SelectedItems.Count, hadShiftDown ? "directories" : "files") : String.Format("this {0}", hadShiftDown ? "directory" : "file")), "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            foreach (ListViewItem item in listViewResults.SelectedItems)
                                StartProcess(hadShiftDown ? Path.GetDirectoryName(item.SubItems[5].Text) + "\\" : item.SubItems[5].Text);
                    }
                    else if (btnSearch.Enabled)
                        button2_Click(sender, e); // Start searching
                    break;
                case Keys.Escape:
                    TryCloseApplication();
                    break;
            }
        }

        //! Needs object and eventargs so we can attach a .Click event to it from menu item 'Exit'
        private void TryCloseApplication(object sender = null, EventArgs e = null)
        {
            if (!Settings.Default.PromptToQuit || MessageBox.Show("Are you sure you want to quit?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Close();
        }

        private void checkBoxUseProgressBar_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowProgress.Checked)
            {
                if (!Settings.Default.PromptShowProgressBar || MessageBox.Show("Are you sure you want to initialize a progress bar? The progress will take a lot longer than it would normally (if the directory we search in is big).", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    MaximumSize = new Size(Width, Height + 30);
                    timerMoveForProgressBar.Enabled = true;

                    foreach (Control control in Controls)
                        if (!(control is MenuStrip))
                            control.Anchor = AnchorStyles.Top;
                }
                else
                    checkBoxShowProgress.Checked = false;
            }
            else
            {
                foreach (Control control in Controls)
                    if (!(control is MenuStrip))
                        control.Anchor = AnchorStyles.Top;

                timerMoveForProgressBar.Enabled = true;
            }
        }

        private void timerMoveForProgressBar_Tick(object sender, EventArgs e)
        {
            if (checkBoxShowProgress.Checked)
            {
                if (Height >= originalHeight + 30)
                {
                    InitializeAnchors();
                    Height = originalHeight + 30;
                    timerMoveForProgressBar.Enabled = false;
                    MaximumSize = new Size(originalWidth + 700, Height);
                }
                else
                    Height += 5;
            }
            else
            {
                if (Height > originalHeight)
                    Height -= 5;
                else
                {
                    InitializeAnchors();
                    Height = originalHeight;
                    timerMoveForProgressBar.Enabled = false;
                    MaximumSize = new Size(originalWidth + 700, Height);
                }
            }
        }

        private void menuItemSettings_Click(object sender, EventArgs e)
        {
            new SettingsForm().ShowDialog(this);
        }

        private void menuItemAbout_Click(object sender, EventArgs e)
        {
            new AboutForm().ShowDialog(this);
        }

        private void checkBoxShowDetailedRestrictions_CheckedChanged(object sender, EventArgs e)
        {
            timerMoveForDetailedRestrictions.Enabled = true;
        }

        private void timerMoveForDetailedRestrictions_Tick(object sender, EventArgs e)
        {
            if (checkBoxShowDetailedRestrictions.Checked)
            {
                if (listViewResults.Height > originalResultsHeight - 25)
                {
                    listViewResults.Height -= 5;
                    listViewResults.Location = new Point(listViewResults.Location.X, listViewResults.Location.Y + 5);
                }
                else
                {
                    listViewResults.Height = originalResultsHeight - 25;
                    timerMoveForDetailedRestrictions.Enabled = false;
                }
            }
            else
            {
                if (listViewResults.Height < originalResultsHeight)
                {
                    listViewResults.Height += 5;
                    listViewResults.Location = new Point(listViewResults.Location.X, listViewResults.Location.Y - 5);
                }
                else
                {
                    listViewResults.Height = originalResultsHeight;
                    timerMoveForDetailedRestrictions.Enabled = false;
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            datePickerFilesNewerThan.Enabled = checkBoxFilesNewerThan.Checked;
        }

        private void checkBoxFilesOlderThan_CheckedChanged(object sender, EventArgs e)
        {
            datePickerFilesOlderThan.Enabled = checkBoxFilesOlderThan.Checked;
        }

        //! Cross-thread functions:
        private delegate void SetEnabledOfControlDelegate(Control control, bool enable);

        private void SetEnabledOfControl(Control control, bool enable)
        {
            if (control.InvokeRequired)
            {
                Invoke(new SetEnabledOfControlDelegate(SetEnabledOfControl), new object[] { control, enable });
                return;
            }

            control.Enabled = enable;
        }

        private delegate void AddItemToListViewDelegate(ListView listView, ListViewItem item);

        private void AddItemToListView(ListView listView, ListViewItem item)
        {
            if (listView.InvokeRequired)
            {
                Invoke(new AddItemToListViewDelegate(AddItemToListView), new object[] { listView, item });
                return;
            }

            listView.Items.Add(item);
        }

        private delegate void ClearListViewResultsDelegate(ListView listView);

        private void ClearListViewResults(ListView listView)
        {
            if (listView.InvokeRequired)
            {
                Invoke(new ClearListViewResultsDelegate(ClearListViewResults), new object[] { listView });
                return;
            }

            listView.Items.Clear();
        }

        private delegate void SetProgressBarMaxValueDelegate(ProgressBar progressBar, int value);

        private void SetProgressBarMaxValue(ProgressBar progressBar, int value)
        {
            if (progressBar.InvokeRequired)
            {
                Invoke(new SetProgressBarMaxValueDelegate(SetProgressBarMaxValue), new object[] { progressBar, value });
                return;
            }

            progressBar.Maximum = value;
        }

        private delegate void SetProgressBarValueDelegate(ProgressBar progressBar, int value);

        private void SetProgressBarValue(ProgressBar progressBar, int value)
        {
            if (progressBar.InvokeRequired)
            {
                Invoke(new SetProgressBarValueDelegate(SetProgressBarValue), new object[] { progressBar, value });
                return;
            }

            if (value >= progressBar.Maximum)
            {
                progressBar.Value = progressBar.Maximum;
                return;
            }

            progressBar.Value = value;
        }
    }
}
