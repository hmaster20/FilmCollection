using System;
using System.Windows.Forms;

namespace FC.Wizard
{
    public partial class Wizard97 : Form
    {
        public Wizard97()
        {
            InitializeComponent();

            // Локализация
            backButton.Text = "Назад";
            nextButton.Text = "Вперед";
            cancelButton.Text = "Отмена";

            wizardPage1.Text = "Добро пожаловать!";
        }

        private void wizardPageContainer1_Finished(object sender, EventArgs e)
        {
            IsExit = true;
            Close();
        }

        private void wizardPageContainer1_SelectedPageChanged(object sender, EventArgs e)
        {
            string[] headers = new string[] { "" };
            if (wizardPageContainer1.SelectedPage.Text != null)
                headers = wizardPageContainer1.SelectedPage.Text.Split('|');
            headerLabel.Text = headers[0];
            if (headers.Length == 2)
                subHeaderLabel.Text = headers[1];
        }

        private void wizardPage1_Initialize(object sender, AeroWizard.WizardPageInitEventArgs e)
        {
            headerPanel.Visible = topDivider.Visible = false;
            startEndPicture.Visible = true;
        }

        private void wizardPage2_Initialize(object sender, AeroWizard.WizardPageInitEventArgs e)
        {
            headerPanel.Visible = topDivider.Visible = true;
            startEndPicture.Visible = false;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        public bool IsExit { get; set; } = false;

        private void Wizard97_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!IsExit)
            {
                DialogResult dialog = MessageBox.Show("Вы уверены что хотите выйти из программы?",
                                          "Завершение работы", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (dialog == DialogResult.OK) Application.ExitThread();
                else if (dialog == DialogResult.Cancel) e.Cancel = true;
            }
        }
    }
}
