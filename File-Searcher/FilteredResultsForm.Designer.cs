namespace File_Searcher
{
    partial class FilteredResultsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FilteredResultsForm));
            this.listViewResultsFilter = new System.Windows.Forms.ListView();
            this.textBoxFilter = new System.Windows.Forms.TextBox();
            this.comboBoxFilterType = new System.Windows.Forms.ComboBox();
            this.buttonFilter = new System.Windows.Forms.Button();
            this.contextMenuStripListView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openWithToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeFromListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripListView.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewResultsFilter
            // 
            this.listViewResultsFilter.Location = new System.Drawing.Point(11, 39);
            this.listViewResultsFilter.Name = "listViewResultsFilter";
            this.listViewResultsFilter.Size = new System.Drawing.Size(739, 240);
            this.listViewResultsFilter.TabIndex = 0;
            this.listViewResultsFilter.UseCompatibleStateImageBehavior = false;
            this.listViewResultsFilter.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_ColumnClick);
            this.listViewResultsFilter.DoubleClick += new System.EventHandler(this.listViewResultsFilter_DoubleClick);
            this.listViewResultsFilter.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewResultsFilter_MouseClick);
            // 
            // textBoxFilter
            // 
            this.textBoxFilter.Location = new System.Drawing.Point(138, 13);
            this.textBoxFilter.Name = "textBoxFilter";
            this.textBoxFilter.Size = new System.Drawing.Size(531, 20);
            this.textBoxFilter.TabIndex = 1;
            // 
            // comboBoxFilterType
            // 
            this.comboBoxFilterType.FormattingEnabled = true;
            this.comboBoxFilterType.Items.AddRange(new object[] {
            "Extension",
            "Name",
            "Size",
            "Sizetype",
            "Last modified"});
            this.comboBoxFilterType.Location = new System.Drawing.Point(11, 12);
            this.comboBoxFilterType.Name = "comboBoxFilterType";
            this.comboBoxFilterType.Size = new System.Drawing.Size(121, 21);
            this.comboBoxFilterType.TabIndex = 2;
            this.comboBoxFilterType.Text = "Filter type";
            // 
            // buttonFilter
            // 
            this.buttonFilter.Location = new System.Drawing.Point(675, 13);
            this.buttonFilter.Name = "buttonFilter";
            this.buttonFilter.Size = new System.Drawing.Size(75, 20);
            this.buttonFilter.TabIndex = 3;
            this.buttonFilter.Text = "Filter";
            this.buttonFilter.UseVisualStyleBackColor = true;
            this.buttonFilter.Click += new System.EventHandler(this.button1_Click);
            // 
            // contextMenuStripListView
            // 
            this.contextMenuStripListView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openWithToolStripMenuItem,
            this.openDirectoryToolStripMenuItem,
            this.removeFromListToolStripMenuItem});
            this.contextMenuStripListView.Name = "contextMenuStripListView";
            this.contextMenuStripListView.Size = new System.Drawing.Size(165, 70);
            // 
            // openWithToolStripMenuItem
            // 
            this.openWithToolStripMenuItem.Name = "openWithToolStripMenuItem";
            this.openWithToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.openWithToolStripMenuItem.Text = "Open with...";
            // 
            // openDirectoryToolStripMenuItem
            // 
            this.openDirectoryToolStripMenuItem.Name = "openDirectoryToolStripMenuItem";
            this.openDirectoryToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.openDirectoryToolStripMenuItem.Text = "Open directory";
            // 
            // removeFromListToolStripMenuItem
            // 
            this.removeFromListToolStripMenuItem.Name = "removeFromListToolStripMenuItem";
            this.removeFromListToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.removeFromListToolStripMenuItem.Text = "Remove from list";
            // 
            // FilteredResultsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 289);
            this.Controls.Add(this.buttonFilter);
            this.Controls.Add(this.comboBoxFilterType);
            this.Controls.Add(this.textBoxFilter);
            this.Controls.Add(this.listViewResultsFilter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FilteredResultsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Filtered results";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FiltedResultsForm_KeyDown);
            this.contextMenuStripListView.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewResultsFilter;
        private System.Windows.Forms.TextBox textBoxFilter;
        private System.Windows.Forms.ComboBox comboBoxFilterType;
        private System.Windows.Forms.Button buttonFilter;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripListView;
        private System.Windows.Forms.ToolStripMenuItem openWithToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openDirectoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeFromListToolStripMenuItem;
    }
}