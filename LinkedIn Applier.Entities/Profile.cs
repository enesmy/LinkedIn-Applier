using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedIn_Applier.Entities
{
    [Table("tblProfiles")]
    public class Profile : BaseEntity
    {
        [Key]
        public int ProfileID { get; set; }
        public string ProfileName { get; set; }
        public string ProfileShortName { get; set; }
        public string CVLocation { get; set; }
        public string WorkType { get; set; }
        public string MailSubject { get; set; }
    }
}
