using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace File_Searcher
{
    public sealed partial class ExceptionForm : Form
    {
        private readonly List<string> exceptionStringStore;
        private readonly int totalExceptions;
        private int indexOfExceptions;

        public ExceptionForm(List<string> exceptionStringStore)
        {
            this.exceptionStringStore = exceptionStringStore;

            InitializeComponent();

            MinimumSize = new Size(Width, Height);

            totalExceptions = exceptionStringStore.Count() - 1;
            labelInfo.Text = "Exception 0 out of " + totalExceptions;
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
                labelInfo.Text = "Exception " + indexOfExceptions + " out of " + totalExceptions;
                buttonPrevious.Enabled = indexOfExceptions - 1 >= 0;
                buttonNext.Enabled = true;
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (totalExceptions > indexOfExceptions)
            {
                textBoxExceptions.Text = exceptionStringStore[++indexOfExceptions];
                labelInfo.Text = "Exception " + indexOfExceptions + " out of " + totalExceptions;
                buttonNext.Enabled = !(indexOfExceptions + 1 > totalExceptions);
                buttonPrevious.Enabled = true;
            }
        }
    }
}
