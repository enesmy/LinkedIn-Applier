using System.Net.Mail;
using LinkedIn_Applier.MailSystem;

namespace LinkedIn_Applier.UI
{
    public partial class frmCredentialInformations : Form
    {
        public frmCredentialInformations()
        {
            InitializeComponent();
            LoadValues();
        }

        private void LoadValues()
        {
            CredentialInformations informations = AppSetting.ReadSetting();
            txtCredentialPassword.Text = Cryptography.Decrypt(informations.CredentialPassword);
            txtDisplayName.Text = informations.DisplayName;
            txtMailAdress.Text = informations.MailAdress;
            txtSmtpServer.Text = informations.SmtpServer;
            nudSmtpPort.Value = informations.SmtpPort;
            cbRequireSSL.Checked = informations.RequireSSL;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (result.IsSuccess)
            {
                Save();
                Close();
            }
            else
            {
                Messages.Error("First you should pass Mail test!");
            }
        }

        private void Save()
        {
            CredentialInformations informations = new CredentialInformations()
            {
                DisplayName = txtDisplayName.Text,
                MailAdress = txtMailAdress.Text,
                RequireSSL = cbRequireSSL.Checked,
                SmtpPort = (int)nudSmtpPort.Value,
                SmtpServer = txtSmtpServer.Text,
                CredentialPassword = Cryptography.Encrypt(txtCredentialPassword.Text)
            };
            AppSetting.SaveSettings(informations);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void nudSmtpPort_ValueChanged(object sender, EventArgs e)
        {
            CheckIsChanged();
        }

        private void cbRequireSSL_CheckedChanged(object sender, EventArgs e)
        {
            CheckIsChanged();
        }

        private async void btnTest_Click(object sender, EventArgs e)
        {
            EmailSendConfigure emailSendConfigure = new EmailSendConfigure();
            emailSendConfigure.Subject = "TEST MESSAGE HEADER";
            emailSendConfigure.From = txtMailAdress.Text;
            emailSendConfigure.TOs = new string[] { txtMailAdress.Text };
            emailSendConfigure.CCs = new string[] { };
            emailSendConfigure.FromDisplayName = txtDisplayName.Text;
            emailSendConfigure.Priority = MailPriority.Normal;
            emailSendConfigure.ClientCredentialPassword = txtCredentialPassword.Text;
            emailSendConfigure.ClientCredentialUserName = txtMailAdress.Text;
            emailSendConfigure.SMTPServer = txtSmtpServer.Text;
            emailSendConfigure.Port = (int)nudSmtpPort.Value;
            emailSendConfigure.EnableSSL = cbRequireSSL.Checked;


            EmailContent content = new EmailContent();
            content.Content = "TEST MAIL CONTENT";
            content.IsHtml = true;
            EmailManager manager = new EmailManager();
            result = await manager.SendMail(emailSendConfigure, content);
            SetTestButtonColor();
        }

        private void SetTestButtonColor(bool IsDefault = false)
        {
            if (!IsDefault)
                btnTest.BackColor = result.IsSuccess ? btnSave.BackColor : btnCancel.BackColor;
            else
            {
                btnTest.BackColor = Color.FromArgb(192, 192, 0);
            }
        }

        (bool IsSuccess, string Message) result = new();

        private void txtObjects_KeyUp(object sender, KeyEventArgs e)
        {
            CheckIsChanged();
        }

        private void CheckIsChanged()
        {
            SetTestButtonColor(true);
        }
    }
}
