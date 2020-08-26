using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalWebsite.Areas.Admin.Models
{
    public class MailServer
    {
        public int Id { get; set; }

        public string ServerAddress { get; set; }

        public string HostAddress { get; set; }

        public int Port { get; set; }

        public string Password { get; set; }

        public string Type { get; set; }
    }
}
