using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalWebsite.Models.Weblog
{
    public class BlogCategory
    {
        public BlogCategory()
        {
            
        }

        public int Id { get; set; }

        [DisplayName("دسته بندی")]
        public string Name { get; set; }

        public virtual List<Blog> Blogs { get; set; }
    }
}
