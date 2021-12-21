using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedIn_Applier.Entities
{
    [Table("tblLocations")]
    public class Location : BaseEntity
    {
        [Key]
        public int LocationID { get; set; }
        public string Place { get; set; }
        public int ProfileID { get; set; }

        [ForeignKey("ProfileID")] public virtual Profile Profile { get; set; }
    }
}
