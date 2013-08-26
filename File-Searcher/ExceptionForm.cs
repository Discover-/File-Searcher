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
    public partial class ExceptionForm : Form
    {
        private List<string> exceptionStringStore;
        private int indexOfExceptions = 0;
        private int totalExceptions = 0;

        public ExceptionForm(List<string> exceptionStringStore)
        {
            this.exceptionStringStore = exceptionStringStore;

            InitializeComponent();

            MinimumSize = new Size(Width, Height);

            totalExceptions = exceptionStringStore.Count() - 1;
            labelInfo.Text = "Exception 0 out of " + totalExceptions.ToString();
            textBoxExceptions.Anchor = AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Left;
        }

        private void ExceptionForm_Load(object sender, EventArgs e)
        {
            textBoxExceptions.Text = exceptionStringStore[0];
        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            if (indexOfExceptions - 1 >= 0)
            {
                textBoxExceptions.Text = exceptionStringStore[--indexOfExceptions];
                labelInfo.Text = "Exception " + indexOfExceptions.ToString() + " out of " + totalExceptions.ToString();
                buttonPrevious.Enabled = indexOfExceptions - 1 >= 0;
                buttonNext.Enabled = true;
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (totalExceptions > indexOfExceptions)
            {
                textBoxExceptions.Text = exceptionStringStore[++indexOfExceptions];
                labelInfo.Text = "Exception " + indexOfExceptions.ToString() + " out of " + totalExceptions.ToString();
                buttonNext.Enabled = !(indexOfExceptions + 1 > totalExceptions);
                buttonPrevious.Enabled = true;
            }
        }
    }
}
