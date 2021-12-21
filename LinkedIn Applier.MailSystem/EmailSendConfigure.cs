using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mime;

namespace LinkedIn_Applier.MailSystem
{
    public class EmailSendConfigure
    {
        public string[] TOs { get; set; }
        public string[] CCs { get; set; }
        public string From { get; set; }
        public string FromDisplayName { get; set; }
        public string Subject { get; set; }
        public MailPriority Priority { get; set; }
        public string ClientCredentialUserName { get; set; }
        public string ClientCredentialPassword { get; set; }
        public bool EnableSSL { get; set; }
        public string SMTPServer { get; set; }
        public int Port { get; set; }
        public EmailSendConfigure()
        {
        }

    }
}
