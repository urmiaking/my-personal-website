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

        #region Blog

        public async Task<string> EditAboutMeImageAsync(IFormFile imageFile, string oldImageName)
        {
            if (imageFile.Length > 500000)
            {
                return null;
            }

            var oldImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", oldImageName);

            if (File.Exists(oldImagePath))
            {
                File.Delete(oldImagePath);
            }

            var newImagePath = Guid.NewGuid() + Path.GetExtension(imageFile.FileName);
            var savePath = Path.Combine(
                Directory.GetCurrentDirectory(), "wwwroot/images",
                newImagePath
            );
            await using var stream = new FileStream(savePath, FileMode.Create);
            await imageFile.CopyToAsync(stream);

            return newImagePath;
        }

        public async Task<string> EditBlogImageAsync(string oldImageUrl, int blogId, IFormFile newImage)
        {
            if (string.IsNullOrEmpty(oldImageUrl))
            {
                return null;
            }

            var result = await SaveBlogImageAsync(newImage);

            if (result.SavedSuccessfully)
            {
                RemoveBlogImage(oldImageUrl, blogId);
                return result.ImageName;
            }

            return null;
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
            catch (Exception)
            {
                blogPictureResult.SavedSuccessfully = false;
                return blogPictureResult;
                //_logger.LogError($"Image Upload incomplete. error = {ex.Message}");
            }

            blogPictureResult.SavedSuccessfully = true;
            return blogPictureResult;
        }

        #endregion

        #region Portfolio

        public async Task<WorkSampleImageViewModel> SaveWorkSampleImageAsync(IFormFile imageFile)
        {
            var result = new WorkSampleImageViewModel();
            if (imageFile == null)
            {
                return result;
            }

            if (imageFile.Length > 500000)
            {
                result.SizeLimitReached = true;
                result.ImageName = "dummy string";
                return result;
            }

            result.ImageName = Guid.NewGuid() + Path.GetExtension(imageFile.FileName);

            try
            {
                result.ImageName = Guid.NewGuid() + Path.GetExtension(imageFile.FileName);
                var savePath = Path.Combine(
                    Directory.GetCurrentDirectory(), "wwwroot/images/portfolio",
                    result.ImageName
                );
                await using var stream = new FileStream(savePath, FileMode.Create);
                await imageFile.CopyToAsync(stream);
            }
            catch (Exception)
            {
                result.SavedSuccessfully = false;
                return result;
                //_logger.LogError($"Image Upload incomplete. error = {ex.Message}");
            }

            result.SavedSuccessfully = true;
            return result;
        }

        public bool RemovePortfolioImage(string imageUrl)
        {
            if (string.IsNullOrEmpty(imageUrl))
            {
                return false;
            }

            var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/portfolio", imageUrl);

            if (File.Exists(imagePath))
            {
                File.Delete(imagePath);
                return true;
            }

            return false;
        }

        #endregion
    }
}
