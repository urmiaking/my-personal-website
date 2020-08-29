using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalWebsite.Models
{
    public class ClientVisit
    {
        public int Id { get; set; }

        public string IpAddress { get; set; }

        public DateTime DateTime { get; set; }
    }
}
