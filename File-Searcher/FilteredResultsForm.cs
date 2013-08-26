using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace File_Searcher
{
    public partial class FilteredResultsForm : Form
    {
        public FilteredResultsForm(ListView listViewResults)
        {
            InitializeComponent();
            this.listViewResults = listViewResults;

            this.listViewResults.View = View.Details;
            this.listViewResults.Columns.Add("Extension", 60, HorizontalAlignment.Right);
            this.listViewResults.Columns.Add("Name", 430, HorizontalAlignment.Left);
            this.listViewResults.Columns.Add("Size", 35, HorizontalAlignment.Right);
            this.listViewResults.Columns.Add("Sizetype", 55, HorizontalAlignment.Right);
            this.listViewResults.Columns.Add("Last Modified", 138, HorizontalAlignment.Right);
            this.listViewResults.Columns.Add("", 0, HorizontalAlignment.Right);

            this.listViewResults.FullRowSelect = true; //! This will make clicking on a row in the results select the full row.

            //this.listViewResults.DoubleClick += listViewResults_DoubleClick;

            //this.listViewResults.ListViewItemSorter = lvwColumnSorter;
            //this.listViewResults.ColumnClick += new ColumnClickEventHandler(listViewResults_ColumnClick);

            //! Set all anchors; this makes the controls properly resize along with the form when it gets resized.
            this.listViewResults.Anchor = AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Left;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
