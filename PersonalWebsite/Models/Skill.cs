using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalWebsite.Models
{
    public class TechnicalSkill
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Progress { get; set; }
    }

    public class PersonalSkill
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Progress { get; set; }
    }
}
