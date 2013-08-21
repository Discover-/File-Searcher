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

namespace File_Searcher
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = true;

            this.comboBoxSearchDir.TextChanged += new System.EventHandler(this.comboBoxSearchDir_TextChanged);
            comboBoxSearchDir_TextChanged(sender, e);

            listViewResults.View = View.Details;
            ColumnHeader headerExt = listViewResults.Columns.Add("Extension", 1, HorizontalAlignment.Right);
            ColumnHeader headerName = listViewResults.Columns.Add("Name", 1, HorizontalAlignment.Left);
            ColumnHeader headerSize = listViewResults.Columns.Add("Size (KB)", 1, HorizontalAlignment.Right);
            ColumnHeader headerLastModified = listViewResults.Columns.Add("Last Modified", 1, HorizontalAlignment.Right);
            headerExt.Width = 60;
            headerName.Width = 265;
            headerSize.Width = 85;
            headerLastModified.Width = 136; //! -4 becuase else we get a scrollbar
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string searchDirectory = txtBoxDirectorySearch.Text;

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

            string allFiles = "";
            GetAllFilesFromDirectory(searchDirectory, checkBoxIncludeSubDirs.Checked, ref allFiles);

            if (allFiles == string.Empty)
            {
                MessageBox.Show("The searched directory contains no files at all.", "An error has occurred!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string[] arrayFiles = allFiles.Split('\n');

            for (int i = 0; i < arrayFiles.Length; i++)
            {
                if (Path.HasExtension(arrayFiles[i]))
                {
                    string fileName = arrayFiles[i];
                    string extension = Path.GetExtension(arrayFiles[i]);
                    string fileSize = new FileInfo(arrayFiles[i]).Length.ToString();

                    if (!checkBoxShowDir.Checked)
                        fileName = Path.GetFileName(fileName);

                    listViewResults.Items.Add(new ListViewItem(new[] { extension, fileName, fileSize, new FileInfo(arrayFiles[i]).LastWriteTime.ToString() }));
                }
            }
        }

        private void comboBoxSearchDir_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxSearchDir_TextChanged(object sender, EventArgs e)
        {
            if (checkBoxIncludeSubDirs.Checked)
            {
                int prevSelectStart = comboBoxSearchDir.SelectionStart;
                int prevSelectLength = comboBoxSearchDir.SelectionLength;

                string allDirectories = "";
                GetAllSubDirectoriesFromDirectory(comboBoxSearchDir.Text, ref allDirectories);

                string[] arrayDirectories = allDirectories.Split('\n');

                comboBoxSearchDir.Items.Clear();

                for (int i = 0; i < arrayDirectories.Length; i++)
                    if (arrayDirectories[i] != string.Empty && arrayDirectories[i] != "" && !Path.HasExtension(arrayDirectories[i]))
                        comboBoxSearchDir.Items.Add(arrayDirectories[i]);

                comboBoxSearchDir.Select(prevSelectStart, prevSelectLength);
            }
        }

        private void GetAllFilesFromDirectory(string directorySearch, bool includingSubDirs, ref string allFiles)
        {
            string[] directories = Directory.GetDirectories(directorySearch);
            string[] files = Directory.GetFiles(directorySearch);

            for (int i = 0; i < files.Length; i++)
                if (files[i] != "")
                    if ((File.GetAttributes(files[i]) & FileAttributes.Hidden) != FileAttributes.Hidden)
                        allFiles += files[i] + "\n";

            //! If we include sub directories, recursive call this function up to every single directory.
            if (includingSubDirs)
                for (int i = 0; i < directories.Length; i++)
                    GetAllFilesFromDirectory(directories[i], true, ref allFiles);
        }

        private void GetAllSubDirectoriesFromDirectory(string directorySearch, ref string allDirectories)
        {
            string[] directories = Directory.GetDirectories(directorySearch);

            for (int i = 0; i < directories.Length; i++)
                allDirectories += directories[i] + "\n";
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
    }
}
