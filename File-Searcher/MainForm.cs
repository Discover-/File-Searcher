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
        private int oldWidth;
        private ListViewColumnSorter lvwColumnSorter;
        private List<ListViewItem> listViewResultsContainer = null;

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Microsoft.Win32.RegistryKey key;
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Names");
            key.SetValue("Name", "Isabella");
            key.Close();

            MaximizeBox = false; //! This looks ugly if set to true when button is pressed while we have a hardcoded max size
            MinimizeBox = true;
            MinimumSize = new Size(Width, Height);
            MaximumSize = new Size(1300, Height);

            listViewResults.View = View.Details;
            ColumnHeader headerExt = listViewResults.Columns.Add("Extension", 1, HorizontalAlignment.Right);
            ColumnHeader headerName = listViewResults.Columns.Add("Name", 1, HorizontalAlignment.Left);
            ColumnHeader headerSize = listViewResults.Columns.Add("Size", 1, HorizontalAlignment.Right);
            ColumnHeader headerSizeType = listViewResults.Columns.Add("Sizetype", 1, HorizontalAlignment.Right);
            ColumnHeader headerLastModified = listViewResults.Columns.Add("Last Modified", 1, HorizontalAlignment.Right);
            ColumnHeader headerFullFilename = listViewResults.Columns.Add("", 1, HorizontalAlignment.Right);
            headerExt.Width = 60;
            headerName.Width = 430;
            headerSize.Width = 35;
            headerSizeType.Width = 55;
            headerLastModified.Width = 155; //! -5 becuase else we get a scrollbar
            headerFullFilename.Width = 0;

            txtBoxDirectorySearch.Anchor = AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Left;
            btnSearchDir.Anchor = AnchorStyles.Right;
            btnSearch.Anchor = AnchorStyles.Right;
            btnStopSearching.Anchor = AnchorStyles.Right;
            listViewResults.Anchor = AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Left;
            groupBoxSearchInfo.Anchor = AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Left;
            groupBoxOptions.Anchor = AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Left;
            progressBar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Left;
            textBoxExtensions.Anchor = AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Left;

            oldWidth = Width;
            listViewResults.FullRowSelect = true;

            progressBar.Minimum = 0;
            progressBar.Maximum = 100;
            progressBar.Value = 0;

            listViewResults.DoubleClick += listViewResults_DoubleClick;

            lvwColumnSorter = new ListViewColumnSorter();
            listViewResults.ListViewItemSorter = lvwColumnSorter;
            listViewResults.ColumnClick += new ColumnClickEventHandler(listViewResults_ColumnClick);

            listViewResultsContainer = new List<ListViewItem>();
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
            catch (Exception) { };
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
            string extensionField = textBoxExtensions.Text;

            if (searchDirectory == "" || searchDirectory == String.Empty)
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

            if (searchFileText != "" && searchFileText != String.Empty && Directory.Exists(searchFileText))
            {
                MessageBox.Show("The field for filename contains a directory!", "An error has occurred!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (extensionField != "" && extensionField != String.Empty)
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
                foreach (ListViewItem item in listViewResultsContainer)
                    AddItemToListView(listViewResults, item);

            if (allFiles == string.Empty)
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
                return;
            }

            SetEnabledOfControl(btnSearch, true);
            SetEnabledOfControl(btnStopSearching, false);

            SetProgressBarMaxValue(progressBar, 100);
            SetProgressBarValue(progressBar, 0);
        }

        private void GetDirectoryCount(string searchDirectory, ref int directoryCountTotal)
        {
            try
            {
                string[] directories = Directory.GetDirectories(searchDirectory);
                directoryCountTotal += directories.Count();

                for (int i = 0; i < directories.Length; i++)
                    GetDirectoryCount(directories[i], ref directoryCountTotal);
            }
            catch (Exception) { };
        }

        private void GetAllFilesFromDirectoryAndFillResults(string directorySearch, bool includingSubDirs, ref string allFiles)
        {
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

                    if (checkBoxIgnoreRecycledFiles.Checked && files[i].Contains("Recycle"))
                        continue;

                    if (textBoxExtensions.Text != string.Empty && Path.HasExtension(textBoxExtensions.Text))
                    {
                        string[] extensionsToIgnore = textBoxExtensions.Text.Split(';');
                        bool _break = false, _continue = false;

                        for (int x = 0; x < extensionsToIgnore.Length; x++)
                        {
                            //! Just writing it all out instead of using better-looking if-checks so nobody gets
                            //! confused trying to understand this code.
                            if (checkBoxReverseExtensions.Checked)
                            {
                                if (Path.GetExtension(files[i]) != extensionsToIgnore[x])
                                {
                                    _continue = true;
                                    break;
                                }
                            }
                            else if (Path.GetExtension(files[i]) == extensionsToIgnore[x])
                            {
                                _break = true;
                                break;
                            }
                        }

                        if (_break)
                            break;

                        if (_continue)
                            continue;
                    }

                    if (!checkBoxShowHiddenFiles.Checked && (File.GetAttributes(files[i]) & FileAttributes.Hidden) == FileAttributes.Hidden)
                        continue;

                    if (txtBoxFileSearch.Text != "")
                    {
                        if (checkBoxSearchForFileContent.Checked)
                        {
                            if (!File.ReadAllText(files[i]).Contains(txtBoxFileSearch.Text))
                                continue;
                        }
                        else if (!files[i].Contains(txtBoxFileSearch.Text))
                            continue;
                    }

                    allFiles += files[i] + "\n"; //! Need to fill up the reference...

                    if (Path.HasExtension(files[i]))
                    {
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
                }

                //! If we include sub directories, recursive call this function up to every single directory.
                if (includingSubDirs)
                    for (int i = 0; i < directories.Length; i++)
                        GetAllFilesFromDirectoryAndFillResults(directories[i], true, ref allFiles);
            }
            catch (Exception) { }; //! No need to do anything with the error.
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

                if (selectedItemName != "" && selectedItemName != String.Empty)
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

            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                    lvwColumnSorter.Order = SortOrder.Descending;
                else
                    lvwColumnSorter.Order = SortOrder.Ascending;
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            myListView.Sort();
        }
    }
}
