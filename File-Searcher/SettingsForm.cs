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
    public partial class SettingsForm : Form
    {
        private Settings settings = null;
        private bool closedFormByHand = false;

        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            MinimizeBox = true;
            FormBorderStyle = FormBorderStyle.Fixed3D;

            FormClosed += SettingsForm_FormClosed; //! To save settings

            KeyPreview = true;
            KeyDown += SettingsForm_KeyDown;

            settings = ((MainForm)Owner).settings;
            checkBoxPromptOpenFile.Checked = settings.GetSetting("PromptOpenFile", "yes") == "yes";
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveSettings();
            closedFormByHand = true;
            Close();
        }

        private void SaveSettings()
        {
            settings.PutSetting("PromptOpenFile", (checkBoxPromptOpenFile.Checked ? "yes" : "no"));
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            PromptSaveSettingsOnClose();
            closedFormByHand = true;
            Close();
        }

        private void SettingsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && !closedFormByHand)
                PromptSaveSettingsOnClose();
        }

        private void PromptSaveSettingsOnClose()
        {
            if (checkBoxPromptOpenFile.Checked == (settings.GetSetting("PromptOpenFile", "yes") == "yes"))
                return;

            if (MessageBox.Show("Do you wish to save the edited settings?", "Save settings?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                SaveSettings();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            checkBoxPromptOpenFile.Checked = false;
        }

        private void SettingsForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    PromptSaveSettingsOnClose();
                    closedFormByHand = true;
                    Close();
                    break;
            }
        }
    }
}
