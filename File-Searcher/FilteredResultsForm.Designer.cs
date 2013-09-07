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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FilteredResultsForm));
            this.listViewResultsFilter = new System.Windows.Forms.ListView();
            this.textBoxFilter = new System.Windows.Forms.TextBox();
            this.comboBoxFilterType = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(675, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 20);
            this.button1.TabIndex = 3;
            this.button1.Text = "Filter";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FilteredResultsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 289);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBoxFilterType);
            this.Controls.Add(this.textBoxFilter);
            this.Controls.Add(this.listViewResultsFilter);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FilteredResultsForm";
            this.Text = "Filtered results";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewResultsFilter;
        private System.Windows.Forms.TextBox textBoxFilter;
        private System.Windows.Forms.ComboBox comboBoxFilterType;
        private System.Windows.Forms.Button button1;
    }
}