using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Diagnostics;
using LinkedIn_Applier.Entities;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium;
using Microsoft.Office.Interop.Outlook;
using LinkedIn_Applier.UI;
using LinkedIn_Applier.Business;
using OpenQA.Selenium.Chrome;
using LinkedIn_Applier.MailSystem;
using System.Net.Mail;
using System.Text;

namespace LinkedIn_Applier
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            factory = new LinkedInDataFactory();
        }
        LinkedInDataFactory factory;


        #region DEFINATIONS

        bool ProfileAnyThingChange = false;
        OperaDriver Browser;
        int LocationFounded = 0;
        string currentLocation = "";
        int totalLocationCount;
        Dictionary<string, string> Emails = new Dictionary<string, string>();
        int CurrentIndex = 0;
        int Counter = 0;
        Profile currentProfile = new Profile();

        #endregion

        #region EMAIL PROCESSES
        private bool LookNewEmail()
        {

            System.Threading.Thread.Sleep(250);
            var showmore = Browser.FindElement(by: By.ClassName("show-more-less-html__markup"));
            if (!showmore.Displayed) return false;
            showmore.Click();

            string RegexPattern = @"([\w\.\-_]+)?\w+@[\w-_]+(\.\w+){1,}";

            Regex reg = new Regex(RegexPattern);
            string htmls = showmore.GetAttribute("innerHTML");
            var Results = reg.Matches(htmls);
            foreach (Match Result in Results)
            {
                if (Result.Success)
                    AddEmail(Result.Value, Browser.Url);
            }
            return true;
        }

        private async void AddEmail(string EmailAdres, string WorkUrl)
        {
            string NewWorkUrl = GetWorkUrl(WorkUrl);
            if (!Emails.ContainsKey(EmailAdres))
            {

                if (!await factory.Mails.ExistMail(EmailAdres))
                {
                    await factory.Mails.AddMail(
                                     new Mail()
                                     {
                                         EMailAdress = EmailAdres,
                                         EmailSent = false,
                                         LinkedInURL = NewWorkUrl,
                                         Location = currentLocation,
                                         ProfileID = currentProfile.ProfileID
                                     });
                    Counter++;
                    LocationFounded++;
                    Logs.Write($"NEW E-Mail: { EmailAdres } and Url: { NewWorkUrl } This Area: {LocationFounded} - {currentLocation} { CurrentIndex} / {totalLocationCount}               --------- -- New Count: {Counter} -- ---------");
                }
                else
                {
                    Logs.Write($"OLD E-Mail: { EmailAdres } and Url: { NewWorkUrl } This Area: {LocationFounded} - {currentLocation} { CurrentIndex} / {totalLocationCount}               --------- -- New Count: {Counter} -- ---------");
                }
                Emails.Add(EmailAdres, WorkUrl);
            }
        }

        async void SendAllWaitingEmails()
        {
            if (AppSetting.CheckFileHealth())
            {
                var emails = await factory.Mails.GetAllWaitingMails();
                var profiles = await factory.Profiles.GetAllProfiles();
                var Result = (from email in emails
                              join profile in profiles on email.ProfileID equals profile.ProfileID
                              select new { email, profile }).ToList();
                List<Task> sentTaskList = new List<Task>();

                EmailSendConfigure emailSendConfigure = new EmailSendConfigure();

                CredentialInformations credentials = AppSetting.ReadSetting();

                emailSendConfigure.From = credentials.MailAdress;
                emailSendConfigure.TOs = new string[] { };
                emailSendConfigure.CCs = new string[] { };
                emailSendConfigure.FromDisplayName = credentials.DisplayName;
                emailSendConfigure.Priority = MailPriority.Normal;
                emailSendConfigure.ClientCredentialPassword = Cryptography.Decrypt(credentials.CredentialPassword);
                emailSendConfigure.ClientCredentialUserName = credentials.MailAdress;
                emailSendConfigure.SMTPServer = credentials.SmtpServer;
                emailSendConfigure.Port = credentials.SmtpPort;
                emailSendConfigure.EnableSSL = credentials.RequireSSL;

                List<Task> mails = new List<Task>();

                foreach (var mail in Result)
                {
                    if (File.Exists(mail.profile.ProfileName + "MailContent.rtf"))
                        rtbMessage.LoadFile(mail.profile.ProfileName + "MailContent.rtf");
                    else
                        rtbMessage.LoadFile(GetSignatureLocation());

                    emailSendConfigure.Subject = mail.profile.MailSubject;


                    mails.Add(SendEmail(mail.email.EMailAdress,
                         ApplyParameters(Rtf2Html(rtbMessage.Rtf), mail.email.LinkedInURL, mail.email.Location, mail.profile.ProfileName, mail.profile.ProfileShortName),
                        mail.profile.CVLocation, emailSendConfigure));
                    sentTaskList.Add(factory.Mails.SetMailSent(mail.email.MailID));
                }
                Task.WaitAll(mails.ToArray());
                Task.WaitAll(sentTaskList.ToArray());
            }
            else
            {
                frmCredentialInformations credentials = new frmCredentialInformations();
                credentials.ShowDialog();
            }
        }

        private async Task SendEmail(string eMailAdress, string mailContentHTML, string cvLocation, EmailSendConfigure configure)
        {
            configure.TOs = new string[] { eMailAdress };
            EmailContent content = new EmailContent();
            content.Content = mailContentHTML;
            content.AttachFileName = cvLocation;
            content.IsHtml = true;
            EmailManager manager = new EmailManager();
            var result = await manager.SendMail(configure, content);
            if (!result.IsSuccess) Logs.Write(result.Message);
        }

        private string Rtf2Html(string rtfString)
        {
            EncodingProvider ppp = CodePagesEncodingProvider.Instance;
            Encoding.RegisterProvider(ppp);
            return RtfPipe.Rtf.ToHtml(rtfString);
        }

        private string ApplyParameters(string MainString, string WorkUrl, string Location, string ProfileName, string ProfileCode) =>
         MainString
                .Replace("@WorkUrl", WorkUrl)
                .Replace("@Location", Location)
                .Replace("@ProfileName", ProfileName)
                .Replace("@ProfileCode", ProfileCode);

        private void BtnSend_Click(object sender, EventArgs e)
        {
            SendAllWaitingEmails();
        }
        #endregion

        #region BROWSER PROCESSES

        int notfoundcount = 0;
        private void ReviewAllPage()
        {
            int tried = 0;
            int maxTryCount = 10;
        countUL:
            try
            {


                System.Threading.Thread.Sleep(250);
                List<IWebElement> ULTags =
                    Browser.FindElements(By.ClassName("jobs-search__results-list"))
                    .First().FindElements(by: By.TagName("li")).ToList();
                int findeds = ULTags.Count;

                if (findeds == 0)
                {
                    if (notfoundcount == maxTryCount)
                        return;

                    notfoundcount++;
                    GoToNextPage();
                    goto countUL;
                }

                for (int i = 0; i < findeds; i++)
                {
                    try
                    {
                        IWebElement Work = ULTags.ToArray()[i];
                        Work.Click();
                        System.Threading.Thread.Sleep(1000);
                    lookmail:
                        if (!LookNewEmail())
                        {
                            Work = ULTags.ToArray()[i + 1];
                            Work.Click();
                            System.Threading.Thread.Sleep(1000);

                            Work = ULTags.ToArray()[i];
                            Work.Click();
                            System.Threading.Thread.Sleep(1000);
                            goto lookmail;
                        }
                    }
                    catch
                    {
                    }
                    RunScript("document.evaluate('//*[@id=\"main-content\"]/section[2]/ul/li[1]', document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue.remove();");
                    //jobIndex++;


                }
                GoToNextPage();
                goto countUL;
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex.Message);
                if (tried == maxTryCount)
                    return;
                tried++;
                System.Threading.Thread.Sleep(5000);
                goto countUL;
            }

        }

        void RunScript(string JsCode)
        {
            IJavaScriptExecutor js = Browser;
            js.ExecuteScript(JsCode);

        }

        private void RunChrome(string CookieLocation, string Location)
        {
            notfoundcount = 0;
            if (Browser != null) CloseBrowser();
            OperaOptions options = new OperaOptions();

            options.AddArguments("user-data-dir=" + CookieLocation);
            options.AddArgument("--start-maximized");
            options.AddArgument("--disable-plugins");
            options.AddArgument("no-sandbox");
            //chromeOptions.AddArgument("disable-gpu");
            if (cbHideEverything.Checked)
            {
                options.AddArgument("headless");
            }


            OperaDriverService service = OperaDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;
            //ChromeBrowser = new ChromeDriver(ChromeService, chromeOptions);

            Browser = new OperaDriver();

            Browser.Manage().Cookies.DeleteAllCookies();

            Browser.Url = "https://www.linkedin.com/jobs/";

            System.Threading.Thread.Sleep(2000);


            IWebElement SearchBox = Browser.FindElements(by: By.XPath("//*[@id=\"JOBS\"]/section[1]/input")).ToList().First();
            if (SearchBox == null)
                return;
            SearchBox.SendKeys(txtWorkType.Text);

            var clearLocation = Browser.FindElement(by: By.XPath("//*[@id=\"JOBS\"]/section[2]/button"));
            clearLocation.Click();

            IWebElement LocationBox = Browser.FindElements(by: By.Name("location")).ToList().First();
            if (LocationBox == null)
                return;
            LocationBox.SendKeys(Location);
            System.Threading.Thread.Sleep(500);


            LocationBox.Submit();
            System.Threading.Thread.Sleep(500);


        }

        private void CloseBrowser()
        {

            if (Browser != null)
            {
                try
                {
                    var tabs = Browser.WindowHandles;
                    tabs.ToList().ForEach(o => Browser.SwitchTo().Window(o).Close());
                    Browser.Quit();
                }
                catch (WebDriverException)
                {

                }
                catch (System.Exception)
                {

                }
                finally
                {
                    Browser.Dispose();
                }
            }
        }

        private string GetWorkUrl(string Url)
        {
            string MainUrl = Url.Substring(0, Url.IndexOf('?'));
            var result = Url.Substring(Url.IndexOf('?') + 1).Split('&').ToDictionary(s => s.Split('=')[0], s => s.Split('=')[1]);
            string currentJobId = result.First(o => o.Key == "currentJobId").Value;
            return $"https://www.linkedin.com/jobs/view/{currentJobId}";
        }


        public void GoToNextPage()
        {
            var elements = Browser.FindElements(By.ClassName("infinite-scroller__show-more-button"));
            foreach (var element in elements)
            {
                if (element.Displayed)
                {
                    element.Click();
                    Thread.Sleep(3000);
                    return;
                }
            }
            RunScript("window.scrollBy(0,1000)"); Thread.Sleep(300);
            RunScript("window.scrollBy(0,-1000)"); Thread.Sleep(300);
            RunScript("window.scrollBy(0,1000)"); Thread.Sleep(300);
            RunScript("window.scrollBy(0,-1000)"); Thread.Sleep(300);



            Thread.Sleep(3000);
        }

        #endregion

        #region FORM PROCESSES 
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadSettings();

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseBrowser();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            if (cbHideEverything.Checked) this.Hide();
            Logs.LogFolder = "Logs";
            Logs.LogFile = "logs_" + DateTime.Now.ToBinary().ToString() + ".xml";
            Counter = 0;
            CurrentIndex = 0;

            var profiles = await factory.Profiles.GetAllProfilesWithLocations();//.Include(o => o.tblLocation).ToList();
            totalLocationCount = 0;
            foreach (var profile in profiles)
            {
                totalLocationCount += profile.Locations.Count;
            }

            foreach (var profile in profiles)
            {
                currentProfile = profile;
                foreach (Location location in profile.Locations)
                {
                    try
                    {
                        CurrentIndex++;
                        Logs.Write("NOW PLACE: " + location.Place + " INDEX " + CurrentIndex.ToString() + "/" + totalLocationCount);
                        LocationFounded = 0;
                        currentLocation = location.Place;
                        try
                        {
                            string dr = "C:/NonTemp/";
                            if (Directory.Exists(dr))
                                Directory.Delete(dr);
                            Directory.CreateDirectory(dr);
                        }
                        catch (System.Exception)
                        {


                        }

                        RunChrome(@"C:/NonTemp/", location.Place);
                        ReviewAllPage();
                    }
                    catch (System.Exception ex)
                    {
                        Logs.Write($"Error Code:{ex.HResult.ToString() + Environment.NewLine} Message: { ex.Message + Environment.NewLine }Source:{ex.Source + ex.StackTrace}");
                    }

                    CloseBrowser();
                }
            }

            File.WriteAllText(DateTime.Now.ToBinary().ToString() + "Result.txt", Emails.ToDebugString());

            if (cbOutomaticSendEmail.Checked) SendAllWaitingEmails();
            if (cbHideEverything.Checked) this.Show();
        }

        #endregion

        #region SETTINGS PROCESSES
        private async void SaveSettings()
        {
            Setting setting = new Setting();
            SetSettingDetails(setting);
            await factory.Settings.SetSettings(setting);
            Messages.Info("Saved!");
        }

        private void SetSettingDetails(Setting setting)
        {
            setting.AutomaticSendMail = cbOutomaticSendEmail.Checked;
            setting.HideEverythingWhileSearching = cbHideEverything.Checked;
            setting.CurrentProfileRef = currentProfile.ProfileID;
            setting.SendAllProfile = rbSendAll.Checked;
        }

        private async void LoadSettings()
        {
            var setting = await factory.Settings.GetSettings();
            if (setting != null)
            {
                cbOutomaticSendEmail.Checked = (bool)setting.AutomaticSendMail;
                cbHideEverything.Checked = (bool)setting.HideEverythingWhileSearching;
                rbSendAll.Checked = (bool)setting.SendAllProfile;
                rbSendCurrent.Checked = !(bool)setting.SendAllProfile;
            }
            LoadProfiles();
        }

        private async void LoadProfiles()
        {
            cbProfiles.DataSource = await factory.Profiles.GetAllProfiles();
            cbProfiles.DisplayMember = "ProfileName";
            cbProfiles.ValueMember = "ProfileID";
        }
        #endregion

        #region Profile Processes
        private void ProfileChanged()
        {
            ProfileAnyThingChange = true;
        }
        private async void SaveProfile()
        {
            if (cbProfiles.SelectedItem == null || !ProfileAnyThingChange)
                return;
            rtbMessage.SaveFile(currentProfile.ProfileName + "MailContent.rtf");

            Profile prf = await factory.Profiles.GetProfileFromProfileID(currentProfile.ProfileID);
            prf.CVLocation = txtFileLocation.Text;
            prf.MailSubject = txtSubject.Text;
            prf.WorkType = txtWorkType.Text;
            await factory.Profiles.SaveProfile(prf);
            Messages.Info("Saved!");
            ProfileAnyThingChange = false;
        }

        void LoadProfile()
        {
            txtFileLocation.Text = currentProfile.CVLocation;
            txtWorkType.Text = currentProfile.WorkType;
            LoadProfileLocations();
            txtSubject.Text = currentProfile.MailSubject;
            LoadMailDetails(currentProfile.ProfileName);
            ProfileAnyThingChange = false;
        }

        private async void LoadProfileLocations()
        {
            int ID = currentProfile.ProfileID;
            var list = (await factory.Locations.GetAllLocationsFromProfileID(ID)).OrderBy(o => o.Place).ToList();
            lstLocations.DataSource = list;
            lstLocations.DisplayMember = "Place";
            lstLocations.ValueMember = "LocationID";
        }

        private void LoadMailDetails(string profileName)
        {
            if (File.Exists(profileName + "MailContent.rtf"))
                rtbMessage.LoadFile(profileName + "MailContent.rtf");
            else
                rtbMessage.LoadFile(GetSignatureLocation());
        }

        private string GetSignatureLocation()
        {
            string appDataDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Microsoft\\Signatures";
            string signatureLocation = string.Empty;
            DirectoryInfo diInfo = new DirectoryInfo(appDataDir);

            if (diInfo.Exists)
            {
                FileInfo[] fiSignature = diInfo.GetFiles("*.rtf");

                if (fiSignature.Length > 0)
                {
                    signatureLocation = fiSignature[0].FullName;
                }
            }
            return signatureLocation;
        }

        private void rtbMessage_TextChanged(object sender, EventArgs e)
        {
            ProfileChanged();
        }

        private void txtSubject_TextChanged(object sender, EventArgs e)
        {
            ProfileChanged();
        }

        private void txtWorkType_TextChanged(object sender, EventArgs e)
        {
            ProfileChanged();
        }

        private async void btnAddLocation_Click(object sender, EventArgs e)
        {
            if (currentProfile == null)
            {
                Messages.Error("Please Create/Select a Profile!");
                return;
            }

            int RowCount = (await factory.Locations.GetAllLocationsFromProfileID(currentProfile.ProfileID)).Count(o => o.Place == txtLocation.Text);
            if (RowCount == 0)
            {
                int ID = currentProfile.ProfileID;
                await factory.Locations.AddLocation(ID, txtLocation.Text);
                txtLocation.Text = "";
                txtLocation.Focus();
                ActiveControl = txtLocation;
                LoadProfileLocations();
            }
            else
            {
                Messages.Info(txtLocation.Text + " already exist!");
                txtLocation.Text = "";
                txtLocation.Focus();
            }

        }

        private async void BtnDeleteLocation_Click(object sender, EventArgs e)
        {
            if (lstLocations.SelectedIndex > -1)
            {
                await factory.Locations.RemoveLocation(((Location)lstLocations.SelectedItem).LocationID);
                LoadProfileLocations();
            }

        }

        #endregion

        #region RTF PROCESSES
        private void BtnUndo_Click(object sender, EventArgs e)
        {
            rtbMessage.Undo();
            UndoRedoSet();
            ProfileChanged();
        }

        private void UndoRedoSet()
        {
            btnUndo.Enabled = rtbMessage.CanUndo;
            btnRedo.Enabled = rtbMessage.CanRedo;
        }

        private void BtnRedo_Click(object sender, EventArgs e)
        {
            ProfileChanged();
            rtbMessage.Redo();
            UndoRedoSet();
        }

        private void RtbMessage_MouseDown(object sender, MouseEventArgs e)
        {
            UndoRedoSet();
        }

        private void BtnBold_Click(object sender, EventArgs e)
        {
            SetFontStyle(FontStyle.Bold);
        }

        private void BtmOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "PDF (.pdf)|*.pdf|Text File (.txt)|*.txt|Word File (.docx ,.doc)|*.docx;*.doc|Spreadsheet (.xls ,.xlsx)|  *.xls ;*.xlsx|Presentation (.pptx ,.ppt)|*.pptx;*.ppt";
            opf.Title = "Attachment!";
            opf.Multiselect = false;
            DialogResult dr = opf.ShowDialog();
            if (dr == DialogResult.OK && opf.CheckFileExists)
            {
                txtFileLocation.Text = opf.FileName;
            }
            ProfileChanged();
        }
        private void SetFontStyle(FontStyle fs)
        {
            Font fnt = rtbMessage.SelectionFont;
            if (fnt.Style.HasFlag(fs))
            {
                rtbMessage.SelectionFont = new Font(fnt.FontFamily, fnt.Size, fnt.Style & ~fs);
            }
            else
            {
                rtbMessage.SelectionFont = new Font(fnt.FontFamily, fnt.Size, fnt.Style | fs);
            }
            ProfileChanged();
        }

        private void BtnItalic_Click(object sender, EventArgs e)
        {
            SetFontStyle(FontStyle.Italic);
        }

        private void BtnUnderline_Click(object sender, EventArgs e)
        {
            SetFontStyle(FontStyle.Underline);
        }

        private void BtnSelectColor_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            DialogResult dr = cd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                rtbMessage.SelectionColor = cd.Color;
                ProfileChanged();
            }
        }

        private void BtnIndentRemove_Click(object sender, EventArgs e)
        {
            if (rtbMessage.SelectionIndent > 5)
            { rtbMessage.SelectionIndent -= 5; }
            else
            {
                rtbMessage.SelectionIndent = 0;
            }
            ProfileChanged();
        }

        private void BtnIndent_Click(object sender, EventArgs e)
        {
            rtbMessage.SelectionIndent += 5;
            ProfileChanged();
        }
        #endregion

        #region SAVE BUTTONS
        private void btnSaveProfile_Click(object sender, EventArgs e)
        {
            SaveProfile();
        }
        private void BtnSaveSettings_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }
        #endregion

        private async void cbProfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ProfileAnyThingChange)
            {
                DialogResult dr = Messages.AskInfo("Modified Profile! Do you want to save changes?");
                if (dr == DialogResult.Yes)
                {
                    SaveProfile();

                }
            }
            if (cbProfiles.SelectedItem == null)
                return;
            int ID = ((Profile)cbProfiles.SelectedItem).ProfileID;

            currentProfile = await factory.Profiles.GetProfileFromProfileID(ID);
            LoadProfile();
            ProfileAnyThingChange = false;
        }

        private async void btnAddProfile_Click(object sender, EventArgs e)
        {
            if (ProfileAnyThingChange)
            {
                DialogResult dr = Messages.AskInfo("Modified Profile! Do you want to save changes?");
                if (dr == DialogResult.Yes)
                {
                    SaveProfile();
                }
            }

            string ProfileName = "";
            string ProfileCode = "";

            frmNewProfile frmNew = new frmNewProfile();
        StepBeginning:
            frmNew.txtProfileName.Text = ProfileName;
            frmNew.txtProfileCode.Text = ProfileCode;

            if (frmNew.ShowDialog() == DialogResult.OK)
            {
                ProfileName = frmNew.txtProfileName.Text;
                ProfileCode = frmNew.txtProfileCode.Text;

                if ((await factory.Profiles.GetAllProfiles()).Count(o => o.ProfileName == ProfileName) > 0)
                {
                    Messages.Error("Please check profile name!");
                    frmNew = new frmNewProfile();
                    frmNew.txtProfileName.Focus();
                    goto StepBeginning;
                }
                else if ((await factory.Profiles.GetAllProfiles()).Count(o => o.ProfileShortName == ProfileCode) > 0)
                {
                    Messages.Error("Please check profile code!");
                    frmNew = new frmNewProfile();
                    frmNew.txtProfileCode.Focus();
                    goto StepBeginning;
                }
                else
                {
                    Profile newProfile = new Profile();
                    newProfile.ProfileName = ProfileName;
                    newProfile.ProfileShortName = ProfileCode;
                    newProfile.IsDeleted = false;
                    await factory.Profiles.SaveProfile(newProfile);
                    LoadProfiles();
                }
            }
        }

        private async void btnDeleteProfile_Click(object sender, EventArgs e)
        {
            if (cbProfiles.SelectedItem == null)
            {
                Messages.Error("You can not delete! Because you do not have any Profile!!");
                return;
            }
            DialogResult dr = Messages.AskInfo("Are you sure want to delete?");
            if (dr == DialogResult.Yes)
            {
                int ID = (int)cbProfiles.SelectedValue;
                var result = await factory.Profiles.DeleteProfile(ID);
                if (result.IsSuccess) Messages.Info(result.Message);
                else Messages.Error(result.Message);
                LoadProfiles();

            }
        }
    }
}
