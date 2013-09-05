using System;
using System.Drawing;
using System.Windows.Forms;

namespace File_Searcher
{
    public partial class FilteredResultsForm : Form
    {
        private readonly ListView.ListViewItemCollection initialItemCollection;

        public FilteredResultsForm(ListView.ListViewItemCollection items)
        {
            InitializeComponent();
            MaximizeBox = false; //! This looks ugly if set to true when button is pressed while we have a hardcoded max size
            MinimizeBox = true;
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
    }
}
