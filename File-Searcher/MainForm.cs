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

namespace File_Searcher
{
    public partial class MainForm : Form
    {
        private Thread searchThread = null;
        private int oldWidth;

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
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
            headerExt.Width = 60;
            headerName.Width = 430;
            headerSize.Width = 35;
            headerSizeType.Width = 55;
            headerLastModified.Width = 156; //! -4 becuase else we get a scrollbar

            txtBoxDirectorySearch.Anchor = AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Left;
            btnSearchDir.Anchor = AnchorStyles.Right;
            txtBoxFilenameSearch.Anchor = AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Left;
            btnSearch.Anchor = AnchorStyles.Right;
            btnStopSearching.Anchor = AnchorStyles.Right;
            listViewResults.Anchor = AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Left;

            oldWidth = Width;
            listViewResults.FullRowSelect = true;
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
            searchThread = new Thread(new ThreadStart(StartSearching));
            searchThread.Start();
        }

        private void StartSearching()
        {
            string searchDirectory = txtBoxDirectorySearch.Text;
            string searchFilename = txtBoxFilenameSearch.Text;

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

            if (searchFilename != "" && searchFilename != String.Empty && Directory.Exists(searchFilename))
            {
                MessageBox.Show("The field for filename contains a directory!", "An error has occurred!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SetEnabledOfControl(btnSearch, false);
            SetEnabledOfControl(btnStopSearching, true);

            string allFiles = "";

            ClearListViewResultsCrossThread(listViewResults);

            //! Function also fills up the listbox on the fly
            GetAllFilesFromDirectoryAndFillResults(searchDirectory, checkBoxIncludeSubDirs.Checked, ref allFiles);

            if (allFiles == string.Empty)
            {
                MessageBox.Show("The searched directory contains no files at all.", "An error has occurred!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SetEnabledOfControl(btnSearch, true);
            SetEnabledOfControl(btnStopSearching, false);
        }

        private void GetAllFilesFromDirectoryAndFillResults(string directorySearch, bool includingSubDirs, ref string allFiles)
        {
            try
            {
                string[] directories = Directory.GetDirectories(directorySearch);
                string[] files = Directory.GetFiles(directorySearch);

                for (int i = 0; i < files.Length; i++)
                {
                    if (files[i] != "")
                    {
                        if (txtBoxFilenameSearch.Text == "" || (txtBoxFilenameSearch.Text != "" && files[i].Contains(txtBoxFilenameSearch.Text)))
                        {
                            if ((File.GetAttributes(files[i]) & FileAttributes.Hidden) != FileAttributes.Hidden)
                            {
                                allFiles += files[i] + "\n"; //! Need to fill up the reference...

                                if (Path.HasExtension(files[i]))
                                {
                                    string fileName = files[i];
                                    string extension = Path.GetExtension(files[i]);
                                    //string fileSize = (new FileInfo(files[i]).Length / 1024).ToString();
                                    string fileSizeType = "";
                                    string fileSize = bytesToMegaByte((int)new FileInfo(files[i]).Length, ref fileSizeType);

                                    if (!checkBoxShowDir.Checked)
                                        fileName = Path.GetFileName(fileName);

                                    ListViewItem listViewItem = new ListViewItem(new[] { extension, fileName, fileSize, fileSizeType, new FileInfo(files[i]).LastWriteTime.ToString() });
                                    AddItemToListView(listViewResults, listViewItem);
                                }
                            }
                        }
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
        }

        private void checkBoxShowDir_CheckedChanged(object sender, EventArgs e)
        {
            //! Update current results with path
            foreach (ListViewItem item in listViewResults.Items)
                item.SubItems[1].Text = checkBoxShowDir.Checked ? Path.GetFullPath(item.SubItems[1].Text) : Path.GetFileName(item.SubItems[1].Text);
        }

        private string bytesToMegaByte(int bytes, ref string fileType)
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

        private delegate void ClearListViewResultsCrossThreadDelegate(ListView listView);

        private void ClearListViewResultsCrossThread(ListView listView)
        {
            if (listView.InvokeRequired)
            {
                Invoke(new ClearListViewResultsCrossThreadDelegate(ClearListViewResultsCrossThread), new object[] { listView });
                return;
            }

            listView.Items.Clear();
        }
    }
}
