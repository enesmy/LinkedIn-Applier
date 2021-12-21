using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedIn_Applier.Entities
{
    [Table("tblMails")]
    public class Mail
    {
        [Key]
        public int MailID { get; set; }
        public string EMailAdress { get; set; }
        public string LinkedInURL { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public bool? EmailSent { get; set; }
        public int ProfileID { get; set; }
        [ForeignKey("ProfileID")] public virtual Profile Profile { get; set; }
    }
}
