using File_Searcher.Properties;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace File_Searcher
{
    public partial class FilteredResultsForm : Form
    {
        private readonly ListView.ListViewItemCollection initialItemCollection;
        private readonly ListViewColumnSorter lvwColumnSorter = new ListViewColumnSorter();

        public FilteredResultsForm(ListView.ListViewItemCollection items)
        {
            InitializeComponent();

            MinimumSize = new Size(Width, Height);
            MaximumSize = new Size(Width, Height + 500);

            initialItemCollection = items;
            InitializeListView(ref listViewResultsFilter, items);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBoxFilterType.SelectedIndex < 0)
            {
                MessageBox.Show("You must select a filter type!", "An error has occurred!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var tempListViewCopy = new ListView();
            InitializeListView(ref tempListViewCopy);

            foreach (ListViewItem item in initialItemCollection)
            {
                if (item.SubItems[comboBoxFilterType.SelectedIndex].Text.ToLower().Contains(textBoxFilter.Text.ToLower()))
                {
                    var listViewItem = new ListViewItem(new[] { item.SubItems[0].Text, item.SubItems[1].Text, item.SubItems[2].Text, item.SubItems[3].Text, item.SubItems[4].Text });
                    tempListViewCopy.Items.Add(listViewItem);
                }
            }

            listViewResultsFilter.Clear();
            InitializeListView(ref listViewResultsFilter, tempListViewCopy.Items);
        }

        private void InitializeListView(ref ListView listView, ListView.ListViewItemCollection items = null)
        {
            listView.View = View.Details;
            listView.Columns.Add("Extension", 60, HorizontalAlignment.Right);
            listView.Columns.Add("Name", 430, HorizontalAlignment.Left);
            listView.Columns.Add("Size", 35, HorizontalAlignment.Right);
            listView.Columns.Add("Sizetype", 55, HorizontalAlignment.Right);
            listView.Columns.Add("Last Modified", 138, HorizontalAlignment.Right);
            listView.FullRowSelect = true;
            //! This will make clicking on a row in the results select the full row.
            listView.Anchor = AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Left;

            if (items != null)
                foreach (ListViewItem item in items)
                    listView.Items.Add((ListViewItem)item.Clone());
        }

        private void FiltedResultsForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    Close();
                    break;
                case Keys.Enter:
                    if (textBoxFilter.Focused)
                        buttonFilter.PerformClick();
                    break;
            }
        }

        private void listView_ColumnClick(object sender, ColumnClickEventArgs e)
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

        private void listViewResultsFilter_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                if (listViewResultsFilter.FocusedItem.Bounds.Contains(e.Location))
                    contextMenuStripListView.Show(Cursor.Position);
        }

        private void listViewResultsFilter_DoubleClick(object sender, EventArgs e)
        {
            var selectedItemName = listViewResultsFilter.SelectedItems[0].SubItems[5].Text;

            if (String.IsNullOrWhiteSpace(selectedItemName))
                return;

            if (!Settings.Default.PromptOpenFile || MessageBox.Show("Are you sure you want to open this file", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                StartProcess(selectedItemName);
        }

        private void StartProcess(string filename, string argument = "")
        {
            try
            {
                Process.Start(filename, argument);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(String.Format("The process '{0}' could not be opened!", Path.GetFileName(filename)), "An error has occurred!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
