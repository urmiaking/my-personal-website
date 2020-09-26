using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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

    public class BlogPictureViewModel
    {
        public BlogPictureViewModel(string imageName, bool sizeLimitReached, bool savedSuccessfully)
        {
            ImageName = imageName;
            SizeLimitReached = sizeLimitReached;
            SavedSuccessfully = savedSuccessfully;
        }

        public BlogPictureViewModel()
        {
            ImageName = null;
            SizeLimitReached = false;
            SavedSuccessfully = false;
        }
        
        public string ImageName { get; set; }
        public bool SizeLimitReached { get; set; }
        public bool SavedSuccessfully { get; set; }
    }
}
