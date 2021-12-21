using LinkedIn_Applier.Business.Abstract;
using LinkedIn_Applier.Business.Concrete;
using LinkedIn_Applier.DataAccess.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedIn_Applier.Business
{
    public class LinkedInDataFactory
    {
        DbContext context;
        /// <summary>
        /// Default constructor using Entity Framework
        /// </summary>
        public LinkedInDataFactory()
        {
            context = new LinkedInContext();
            InitObjects();
        }


        /// <summary>
        /// For release mode
        /// </summary>
        /// <param name="prmContext">Write your selected context</param>
        public LinkedInDataFactory(DbContext prmContext)
        {
            this.context = prmContext;
            InitObjects();
        }
        private void InitObjects()
        {
            Mails = new MailManager(context);
            Profiles = new ProfileManager(context);
            Locations = new LocationManager(context);
            Settings = new SettingManager(context);
        }

        public AbstractMailService Mails { get; set; }
        public AbstractProfileService Profiles { get; set; }
        public AbstractLocationService Locations { get; set; }
        public AbstractSettingService Settings { get; set; }
    }
}
