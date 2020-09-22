using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalWebsite.Models.Weblog
{
    public class Blog
    {
        public Blog()
        {

        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string ImageUrl { get; set; }
        public DateTime DateTime { get; set; }
        public string Tags { get; set; }

        public int CategoryId { get; set; }
        public virtual BlogCategory Category { get; set; }
    }
}
