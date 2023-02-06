using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandrasBookingSystem.Models
{
    public class Agency : User
    {
        public string AgencyName { get; set; }
        public string CVR_nr { get; set; }
    }
}
