using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using PersonalWebsite.Areas.Admin.DTOs;
using PersonalWebsite.Data;

namespace PersonalWebsite.Services
{
    public class PictureService : IPictureService
    {
        private readonly AppDbContext _db;

        public PictureService(AppDbContext db)
        {
            _db = db;
        }

        public bool RemoveBlogImage(string imageUrl, int blogId)
        {
            if (string.IsNullOrEmpty(imageUrl))
            {
                return false;
            }

            var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/blog", imageUrl);

            var imageCantBeRemoved = _db.Blogs.Any(a => a.ImageUrl.Equals(imageUrl) && !a.Id.Equals(blogId));

            if (File.Exists(imagePath) && !imageCantBeRemoved)
            {
                File.Delete(imagePath);
                return true;
            }

            return false;
        }

        public async Task<BlogPictureViewModel> SaveBlogImageAsync(IFormFile imageFile)
        {
            var blogPictureResult = new BlogPictureViewModel();
            if (imageFile == null)
            {
                return blogPictureResult;
            }

            if (imageFile.Length > 500000)
            {
                blogPictureResult.SizeLimitReached = true;
                blogPictureResult.ImageName = "dummy string";
                return blogPictureResult;
            }

            blogPictureResult.ImageName = Guid.NewGuid() + Path.GetExtension(imageFile.FileName);

            try
            {
                blogPictureResult.ImageName = Guid.NewGuid() + Path.GetExtension(imageFile.FileName);
                var savePath = Path.Combine(
                    Directory.GetCurrentDirectory(), "wwwroot/images/blog",
                    blogPictureResult.ImageName
                );
                await using var stream = new FileStream(savePath, FileMode.Create);
                await imageFile.CopyToAsync(stream);
            }
            catch (Exception ex)
            {
                blogPictureResult.SavedSuccessfully = false;
                return blogPictureResult;
                //_logger.LogError($"Image Upload incomplete. error = {ex.Message}");
            }

            blogPictureResult.SavedSuccessfully = true;
            return blogPictureResult;
        }
    }
}
