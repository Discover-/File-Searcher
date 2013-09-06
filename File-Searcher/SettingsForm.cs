using System;
using System.Windows.Forms;

namespace File_Searcher
{
    public partial class SettingsForm : Form
    {
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

            checkBoxPromptOpenFile.Checked = Properties.Settings.Default.PromptOpenFile;
            checkBoxPromptShowProgressbar.Checked = Properties.Settings.Default.PromptShowProgressBar;
            checkBoxPromptToQuit.Checked = Properties.Settings.Default.PromptToQuit;
            checkBoxAutoSaveSettings.Checked = Properties.Settings.Default.AutoSaveSettings;
            checkBoxAlwaysShowDetailedRestrictions.Checked = Properties.Settings.Default.AlwaysShowDetailedRestrictions;
            textBoxShortcutAbout.Text = Properties.Settings.Default.KeyShortcutAbout;
            textBoxShortcutSettings.Text = Properties.Settings.Default.KeyShortcutSettings;
            textBoxShortcutExit.Text = Properties.Settings.Default.KeyShortcutExit;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveSettings();
            closedFormByHand = true;
            Close();
        }

        private void SaveSettings()
        {
            Properties.Settings.Default.PromptOpenFile = checkBoxPromptOpenFile.Checked;
            Properties.Settings.Default.PromptShowProgressBar = checkBoxPromptShowProgressbar.Checked;
            Properties.Settings.Default.PromptToQuit = checkBoxPromptToQuit.Checked;
            Properties.Settings.Default.AutoSaveSettings = checkBoxAutoSaveSettings.Checked;
            Properties.Settings.Default.AlwaysShowDetailedRestrictions = checkBoxAlwaysShowDetailedRestrictions.Checked;
            Properties.Settings.Default.KeyShortcutAbout = textBoxShortcutAbout.Text = Properties.Settings.Default.KeyShortcutAbout;
            Properties.Settings.Default.KeyShortcutSettings = textBoxShortcutSettings.Text;
            Properties.Settings.Default.KeyShortcutExit = textBoxShortcutExit.Text;
            Properties.Settings.Default.Save();

            if (!((MainForm)Owner).checkBoxShowDetailedRestrictions.Checked && checkBoxAlwaysShowDetailedRestrictions.Checked)
            {
                ((MainForm)Owner).timerMoveForDetailedRestrictions.Enabled = true;
                ((MainForm)Owner).checkBoxShowDetailedRestrictions.Checked = true;
            }
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
            if (checkBoxAutoSaveSettings.Checked)
            {
                SaveSettings();
                return;
            }

            if (checkBoxPromptOpenFile.Checked == Properties.Settings.Default.PromptOpenFile && checkBoxPromptShowProgressbar.Checked == Properties.Settings.Default.PromptShowProgressBar &&
                checkBoxPromptToQuit.Checked == Properties.Settings.Default.PromptToQuit && checkBoxAutoSaveSettings.Checked == Properties.Settings.Default.AutoSaveSettings &&
                checkBoxAlwaysShowDetailedRestrictions.Checked == Properties.Settings.Default.AlwaysShowDetailedRestrictions)
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

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //if (keyData == (Keys.Control | Keys.F))
            {
                MessageBox.Show(keyData.ToString());
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
