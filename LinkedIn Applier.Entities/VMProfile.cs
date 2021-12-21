using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedIn_Applier.Entities
{
    public class VMProfile:Profile
    {
        public List<Location> Locations { get; set; }
    }
}
