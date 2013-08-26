using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace File_Searcher
{
    public partial class MainForm : Form
    {
        private Thread searchThread = null;
        private int oldWidth = 0;
        private ListViewColumnSorter lvwColumnSorter = new ListViewColumnSorter();
        private List<ListViewItem> listViewResultsContainer = new List<ListViewItem>();
        private List<Control> controlsToDisable = new List<Control>();
        private List<string> exceptionStringStore = new List<string>();

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MaximizeBox = false; //! This looks ugly if set to true when button is pressed while we have a hardcoded max size
            MinimizeBox = true;
            MinimumSize = new Size(Width, Height);
            MaximumSize = new Size(Width + 700, Height);

            listViewResults.View = View.Details;
            listViewResults.Columns.Add("Extension", 60, HorizontalAlignment.Right);
            listViewResults.Columns.Add("Name", 430, HorizontalAlignment.Left);
            listViewResults.Columns.Add("Size", 35, HorizontalAlignment.Right);
            listViewResults.Columns.Add("Sizetype", 55, HorizontalAlignment.Right);
            listViewResults.Columns.Add("Last Modified", 155, HorizontalAlignment.Right);
            listViewResults.Columns.Add("", 0, HorizontalAlignment.Right);

            //! Set all anchors; this makes the controls properly resize along with the form when it gets resized.
            txtBoxDirectorySearch.Anchor = AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Left;
            btnSearchDir.Anchor = AnchorStyles.Right;
            btnSearch.Anchor = AnchorStyles.Right;
            btnStopSearching.Anchor = AnchorStyles.Right;
            listViewResults.Anchor = AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Left;
            groupBoxSearchInfo.Anchor = AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Left;
            progressBar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Left;
            txtBoxExtensions.Anchor = AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Left;

            oldWidth = Width; //! We store the initial width of the form so that we know how far the form was resized
                              //! which allows us to determine how many pixels the 'Name' column need to be increased.

            listViewResults.FullRowSelect = true; //! This will make clicking on a row in the results select the full row.

            //! Initialize progress bar; default should be on 0%.
            progressBar.Minimum = 0;
            progressBar.Maximum = 100;
            progressBar.Value = 0;

            listViewResults.DoubleClick += listViewResults_DoubleClick;

            listViewResults.ListViewItemSorter = lvwColumnSorter;
            listViewResults.ColumnClick += new ColumnClickEventHandler(listViewResults_ColumnClick);

            //! Add all controls we disable once we start searching to the list controlling this
            controlsToDisable.Add(checkBoxIgnoreRecycledFiles);
            controlsToDisable.Add(checkBoxIncludeSubDirs);
            controlsToDisable.Add(checkBoxReverseExtensions);
            controlsToDisable.Add(checkBoxSearchForFileContent);
            controlsToDisable.Add(checkBoxShowAllResultsAtOnce);
            controlsToDisable.Add(checkBoxShowDir);
            controlsToDisable.Add(checkBoxShowHiddenFiles);
            controlsToDisable.Add(checkBoxUseProgressBar);
            controlsToDisable.Add(checkBoxShowExceptions);
            controlsToDisable.Add(checkBoxIgnoreFilesWithoutExtension);
            controlsToDisable.Add(checkBoxIgnoreCaseSensitivity);
            controlsToDisable.Add(txtBoxDirectorySearch);
            controlsToDisable.Add(txtBoxFileSearch);
            controlsToDisable.Add(txtBoxExtensions);
            controlsToDisable.Add(btnSearchDir);

            addTooltip(checkBoxIgnoreRecycledFiles, "A lot of files found when searching through a root directory like the C disk are found in a recycle bin folder which make no sense if listed.");
            addTooltip(checkBoxReverseExtensions, "Checking this will mean the text box saying 'Extensions to ignore' will now be reversed, thus only show files containing extensions in that field");
            addTooltip(checkBoxSearchForFileContent, "This will make the 'Filename' field transfer into a field to determine which text must be included in the searched files in order to show uo");
            addTooltip(checkBoxShowHiddenFiles, "Determines whether or not you want to show hidden files or not.");
            addTooltip(checkBoxShowAllResultsAtOnce, "If this is checked, instead of live-updating the result box below, it will be filled all at once when the process finished.");
            addTooltip(checkBoxShowExceptions, "This is basically meant for error-tracking. This software is written in C# which means sometimes code return errors and only developers can see them (under certain circumstances). Checking this will show the errors in a new window when the process finished.");
            addTooltip(checkBoxUseProgressBar, "This will enable the progressbar shown at the bottom of the application. The reason it's default unchecked is because it will make the process take quite a lot longer.");
            addTooltip(checkBoxIgnoreFilesWithoutExtension, "Checking this will make files without any extension be ignored (like most of the README files).");
            addTooltip(checkBoxIgnoreCaseSensitivity, "Checking this will allow you to ignore case sensitivity in the file name/content search field.");
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
            searchThread = new Thread(new ThreadStart(StartSearching));
            searchThread.Start();
        }

        private void StartSearching()
        {
            string searchDirectory = txtBoxDirectorySearch.Text;
            string searchFileText = txtBoxFileSearch.Text;
            string extensionField = txtBoxExtensions.Text;

            if (searchDirectory == String.Empty)
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

            if (searchFileText != String.Empty && Directory.Exists(searchFileText))
            {
                MessageBox.Show("The field for filename contains a directory!", "An error has occurred!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (extensionField != String.Empty)
            {
                if (Directory.Exists(extensionField))
                {
                    MessageBox.Show("The field for extensions contains a directory!", "An error has occurred!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (extensionField.Substring(extensionField.Length - 1) != ";")
                {
                    MessageBox.Show("The field for extensions must end with a semicolon!", "An error has occurred!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            UseWaitCursor = true;

            SetEnabledOfControl(btnSearch, false);
            SetEnabledOfControl(btnStopSearching, true);

            foreach (Control control in controlsToDisable)
                SetEnabledOfControl(control, false);

            SetProgressBarMaxValue(progressBar, 100);
            SetProgressBarValue(progressBar, 0);

            string allFiles = "";

            ClearListViewResults(listViewResults);

            if (checkBoxUseProgressBar.Checked)
            {
                int directoryCountTotal = 0;
                GetDirectoryCount(searchDirectory, ref directoryCountTotal);
                SetProgressBarMaxValue(progressBar, directoryCountTotal);
            }

            //! Function also fills up the listbox on the fly
            GetAllFilesFromDirectoryAndFillResults(searchDirectory, checkBoxIncludeSubDirs.Checked, ref allFiles);

            if (listViewResultsContainer != null && checkBoxShowAllResultsAtOnce.Checked && listViewResultsContainer.Count() > 0)
            {
                foreach (ListViewItem item in listViewResultsContainer)
                    AddItemToListView(listViewResults, item);

                listViewResultsContainer.Clear();
            }

            if (allFiles == String.Empty)
            {
                if (Path.HasExtension(txtBoxFileSearch.Text) || Path.HasExtension(extensionField))
                    MessageBox.Show("The searched directory contains no files matching your criteria.", "An error has occurred!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("The searched directory contains no files at all.", "An error has occurred!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                SetEnabledOfControl(btnSearch, true);
                SetEnabledOfControl(btnStopSearching, false);

                SetProgressBarMaxValue(progressBar, 100);
                SetProgressBarValue(progressBar, 0);

                UseWaitCursor = false;

                foreach (Control control in controlsToDisable)
                    SetEnabledOfControl(control, true);

                return;
            }

            SetEnabledOfControl(btnSearch, true);
            SetEnabledOfControl(btnStopSearching, false);

            SetProgressBarMaxValue(progressBar, 100);
            SetProgressBarValue(progressBar, 0);

            UseWaitCursor = false;

            foreach (Control control in controlsToDisable)
                SetEnabledOfControl(control, true);
        }

        private void GetDirectoryCount(string searchDirectory, ref int directoryCountTotal)
        {
            //! We need a try-catch block because accessing files without permissions does not work for some reason
            //! and breaks with an exception.
            try
            {
                string[] directories = Directory.GetDirectories(searchDirectory);
                directoryCountTotal += directories.Count();

                for (int i = 0; i < directories.Length; i++)
                    GetDirectoryCount(directories[i], ref directoryCountTotal);
            }
            catch (Exception exception)
            {
                if (checkBoxShowExceptions.Checked)
                    exceptionStringStore.Add(exception.ToString());
            }
        }

        private void GetAllFilesFromDirectoryAndFillResults(string directorySearch, bool includingSubDirs, ref string allFiles)
        {
            //! We need a try-catch block because accessing files without permissions does not work for some reason
            //! and breaks with an exception.
            try
            {
                string[] directories = Directory.GetDirectories(directorySearch);
                string[] files = Directory.GetFiles(directorySearch);

                if (checkBoxUseProgressBar.Checked)
                    SetProgressBarValue(progressBar, progressBar.Value + 1);

                for (int i = 0; i < files.Length; i++)
                {
                    if (files[i] == "")
                        continue;

                    if (checkBoxIgnoreRecycledFiles.Checked && files[i].IndexOf("recycle", StringComparison.OrdinalIgnoreCase) >= 0)
                        continue;

                    if (!checkBoxShowHiddenFiles.Checked && (File.GetAttributes(files[i]) & FileAttributes.Hidden) == FileAttributes.Hidden)
                        continue;

                    if (txtBoxFileSearch.Text != "")
                    {
                        if (checkBoxSearchForFileContent.Checked)
                        {
                            if (checkBoxIgnoreCaseSensitivity.Checked)
                            {
                                if (!File.ReadAllText(files[i]).ToLower().Contains(txtBoxFileSearch.Text.ToLower()))
                                    continue;
                            }
                            else if (!File.ReadAllText(files[i]).Contains(txtBoxFileSearch.Text))
                                continue;
                        }
                        else
                        {
                            if (checkBoxIgnoreCaseSensitivity.Checked)
                            {
                                if (!files[i].ToLower().Contains(txtBoxFileSearch.Text.ToLower()))
                                    continue;
                            }
                            else if (!files[i].Contains(txtBoxFileSearch.Text))
                                continue;
                        }
                    }
                    
                    if (checkBoxIgnoreFilesWithoutExtension.Checked && !Path.HasExtension(txtBoxExtensions.Text))
                        continue;

                    if (txtBoxExtensions.Text != String.Empty)
                    {
                        //! If we only list specific extensions (field is not left empty) and the given file has no
                        //! extension, we can safely ignore it.
                        if (checkBoxReverseExtensions.Checked && !Path.HasExtension(files[i]))
                            continue;

                        string[] splitExtensionsField = txtBoxExtensions.Text.Split(';');
                        bool foundExtensionMatch = false;

                        for (int x = 0; x < splitExtensionsField.Length; x++)
                        {
                            if (Path.GetExtension(files[i]).ToLower() == splitExtensionsField[x].ToLower())
                            {
                                foundExtensionMatch = true;
                                break;
                            }
                        }

                        if (foundExtensionMatch)
                        {
                            if (!checkBoxReverseExtensions.Checked) //! Extensions to show instead of ignore in the field now
                                continue;
                        }
                        else if (checkBoxReverseExtensions.Checked)
                            continue;
                    }

                    allFiles += files[i] + "\n"; //! Need to fill up the reference...

                    string fileName = files[i];
                    string extension = Path.GetExtension(files[i]).ToLower();
                    //string fileSize = (new FileInfo(files[i]).Length / 1024).ToString();
                    string fileSizeType = "";
                    string fileSize = convertBytesFormat((int)new FileInfo(files[i]).Length, ref fileSizeType);

                    if (!checkBoxShowDir.Checked)
                        fileName = Path.GetFileName(fileName);

                    ListViewItem listViewItem = new ListViewItem(new[] { extension, fileName, fileSize, fileSizeType, new FileInfo(files[i]).LastWriteTime.ToString(), fileName });

                    if (checkBoxShowAllResultsAtOnce.Checked)
                        listViewResultsContainer.Add(listViewItem);
                    else
                        AddItemToListView(listViewResults, listViewItem);
                }

                //! If we include sub directories, recursive call this function up to every single directory.
                if (includingSubDirs)
                    for (int i = 0; i < directories.Length; i++)
                        GetAllFilesFromDirectoryAndFillResults(directories[i], true, ref allFiles);
            }
            catch (Exception exception)
            {
                if (checkBoxShowExceptions.Checked)
                    exceptionStringStore.Add(exception.ToString());
            }
        }

        private void btnSearchDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Select a directory in which you want to search for files and directories.";

            if (txtBoxDirectorySearch.Text != "" && Directory.Exists(txtBoxDirectorySearch.Text))
                fbd.SelectedPath = txtBoxDirectorySearch.Text;

            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
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

            if (listViewResultsContainer != null && checkBoxShowAllResultsAtOnce.Checked && listViewResultsContainer.Count() > 0)
            {
                foreach (ListViewItem item in listViewResultsContainer)
                    AddItemToListView(listViewResults, item);

                listViewResultsContainer.Clear();
            }

            foreach (Control control in controlsToDisable)
                SetEnabledOfControl(control, true);

            if (checkBoxShowExceptions.Checked)
                new Thread(StartExceptionForm).Start();
        }

        private void StartExceptionForm()
        {
            Application.Run(new ExceptionForm(exceptionStringStore));
            exceptionStringStore.Clear();
        }

        private void checkBoxShowDir_CheckedChanged(object sender, EventArgs e)
        {
            //! Update current results with path
            foreach (ListViewItem item in listViewResults.Items)
                item.SubItems[1].Text = checkBoxShowDir.Checked ? item.SubItems[5].Text : Path.GetFileName(item.SubItems[1].Text);
        }

        private string convertBytesFormat(int bytes, ref string fileType)
        {
            string[] sizes = { "B", "KB", "MB", "GB" };
            int order = 0;

            while (bytes >= 1024 && order + 1 < sizes.Length)
            {
                order++;
                bytes = bytes / 1024;
            }

            fileType = sizes[order];
            return String.Format("{0:0.##}", bytes);
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

        private void checkBoxReverseExtensions_CheckedChanged(object sender, EventArgs e)
        {
            //! Using string::replace doesn't have the same effect for some reason
            if (checkBoxReverseExtensions.Checked)
                lblIgnoreExtensions.Text = "Extensions to show (split by semicolon):";
            else
                lblIgnoreExtensions.Text = "Extensions to ignore (split by semicolon):";
        }

        private void checkBoxSearchForFileContent_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSearchForFileContent.Checked)
                lblSearchFile.Text = "File content to search for (if left empty all files in the directory will be shown):";
            else
                lblSearchFile.Text = "Filename to search for (if left empty all files in the directory will be shown):";
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

            if (progressBar.Value >= progressBar.Maximum)
            {
                progressBar.Value = progressBar.Maximum;
                return;
            }

            progressBar.Value = value;
        }

        private void listViewResults_DoubleClick(object sender, EventArgs e)
        {
            if (listViewResults.SelectedItems.Count == 1)
            {
                string selectedItemName = listViewResults.SelectedItems[0].SubItems[1].Text;

                if (selectedItemName != String.Empty)
                {
                    if (MessageBox.Show("Are you sure you want to open this file?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Process process = new Process();
                        process.StartInfo = new ProcessStartInfo(selectedItemName);
                        process.Start();
                    }
                }
            }
        }

        private void listViewResults_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListView myListView = (ListView)sender;

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

        private void checkBoxUseProgressBar_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxUseProgressBar.Checked)
                if (MessageBox.Show("Are you sure you want to initialize a progress bar? The progress will take a lot longer than it would normally (if the directory we search in is big).", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    checkBoxUseProgressBar.Checked = false;
        }

        private void addTooltip(Control control, string tooltipMsg)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(control, tooltipMsg);
            toolTip.ShowAlways = true;
        }
    }
}
