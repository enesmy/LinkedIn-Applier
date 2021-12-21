
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;


namespace LinkedIn_Applier.UI
{
    internal class AppSetting
    {
        static string FileName = "LinkedInProperties.Settings";
        static string GetFileName => Environment.CurrentDirectory + "\\" + FileName;

        internal static CredentialInformations ReadSetting()
        {

            var emptyCredential = new CredentialInformations()
            {
                RequireSSL = false,
                SmtpPort = 587,
                SmtpServer = "",
                MailAdress = "",
                DisplayName = "",
                CredentialPassword = ""
            };

            if (!File.Exists(GetFileName)) return emptyCredential;
            File.Decrypt(GetFileName);
            string filecontent = File.ReadAllText(GetFileName);
            if (filecontent == null)
            {
                File.Encrypt(GetFileName);
                return emptyCredential;
            }

            var credential = JsonSerializer.Deserialize<CredentialInformations>(filecontent);
            if (credential == null)
            {
                File.Encrypt(GetFileName);
                return emptyCredential;
            }
            else
            {
                File.Encrypt(GetFileName);
                return credential;
            }
        }

        internal static void SaveSettings(CredentialInformations informations)
        {
            if (!File.Exists(GetFileName)) File.Delete(GetFileName);
            string json = JsonSerializer.Serialize(informations);
            File.WriteAllText(GetFileName, json);
            File.Encrypt(GetFileName);
        }

        internal static bool CheckFileHealth()
        {
            if (!File.Exists(GetFileName)) return false;
            File.Decrypt(GetFileName);
            string filecontent = File.ReadAllText(GetFileName);
            if (filecontent == null)
            {
                File.Encrypt(GetFileName);
                return false;
            }

            var credential = JsonSerializer.Deserialize<CredentialInformations>(filecontent);
            if (credential == null)
            {
                File.Encrypt(GetFileName);
                return false;
            }
            else
            {
                File.Encrypt(GetFileName);
                return true;
            }
        }
    }
}
