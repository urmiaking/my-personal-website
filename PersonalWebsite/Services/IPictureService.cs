using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using PersonalWebsite.Areas.Admin.DTOs;

namespace PersonalWebsite.Services
{
    public interface IPictureService
    {
        Task<BlogPictureViewModel> SaveBlogImageAsync(IFormFile imageFile);

        bool RemoveBlogImage(string imageUrl);
    }
}
