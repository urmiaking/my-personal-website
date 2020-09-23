using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonalWebsite.Models.Weblog;

namespace PersonalWebsite.Areas.Admin.DTOs
{
    public class DashboardViewModel
    {
        public DashboardViewModel()
        {
            Blogs = new List<Blog>();
        }
        public DashboardViewModel(List<Blog> blogs)
        {
            Blogs = blogs ?? new List<Blog>();
        }

        public List<Blog> Blogs { get; set; }
    }
}
