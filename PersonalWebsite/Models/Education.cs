using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalWebsite.Models
{
    public class Education
    {
        public int Id { get; set; }

        public string DegreeTitle { get; set; }

        public string CollegeName { get; set; }

        public string Duration { get; set; }

        public string Description { get; set; }
    }
}
