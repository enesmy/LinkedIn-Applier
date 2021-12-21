using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace LinkedIn_Applier.MailSystem
{
    public class EmailManager
    {

        public async Task<(bool IsSuccess, string Message)> SendMail(EmailSendConfigure emailConfig, EmailContent content)
        {
            MailMessage msg = ConstructEmailMessage(emailConfig, content);
            return await Send(msg, emailConfig);
        }


        private MailMessage ConstructEmailMessage(EmailSendConfigure emailConfig, EmailContent content)
        {
            MailMessage msg = new System.Net.Mail.MailMessage();
            foreach (string to in emailConfig.TOs)
            {
                if (!string.IsNullOrEmpty(to))
                {
                    msg.To.Add(to);
                }
            }

            foreach (string cc in emailConfig.CCs)
            {
                if (!string.IsNullOrEmpty(cc))
                {
                    msg.CC.Add(cc);
                }
            }

            msg.From = new MailAddress(emailConfig.From,
                                       emailConfig.FromDisplayName,
                                       System.Text.Encoding.UTF8);
            msg.IsBodyHtml = content.IsHtml;
            msg.Body = content.Content;
            msg.Priority = emailConfig.Priority;
            msg.Subject = emailConfig.Subject;
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            msg.SubjectEncoding = System.Text.Encoding.UTF8;

            if (content.AttachFileName != null)
            {
                Attachment data = new Attachment(content.AttachFileName);
                msg.Attachments.Add(data);
            }

            return msg;
        }

        private async Task<(bool IsSuccess, string Message)> Send(MailMessage message, EmailSendConfigure emailConfig)
        {
            SmtpClient client = new SmtpClient();
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(
                                  emailConfig.ClientCredentialUserName,
                                  emailConfig.ClientCredentialPassword);
            client.Host = emailConfig.SMTPServer;
            client.Port = emailConfig.Port;
            client.EnableSsl = emailConfig.EnableSSL;

            try
            {
                client.Send(message);
            }
            catch (Exception e)
            {
                return (false, $"Error in Send email: {e.Message}");

            }
            message.Dispose();
            return (true, "Success!");
        }

    }
}
