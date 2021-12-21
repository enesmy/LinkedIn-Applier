using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedIn_Applier.Entities
{
    [Table("tblSettings")]
    public class Setting : BaseEntity
    {
        [Key]
        public int SettingID { get; set; }
        public bool? HideEverythingWhileSearching { get; set; }
        public bool? AutomaticSendMail { get; set; }
        public bool? SendAllProfile { get; set; }
        public int? CurrentProfileRef { get; set; }
    }
}
