using Imgur.API.Endpoints.Impl;
using Imgur.API.Models;
using MemoBll.Logic;
using MemoBll.Managers;
using MemoDAL;
using MemoRise.Helpers;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace MemoRise.Controllers
{
    /// <summary>
    /// Controller responsible for uploading photos to the remote hosting.
    /// </summary>
    public class ImageController : ApiController
    {
        private ImageEndpoint uploader;
        Moderation moderation = new Moderation();

        public ImageController()
        {
            this.uploader = UploadManager.GetInstance();
            this.moderation = new Moderation();
        }

        [HttpPost]
        [Route("Image/UploadPhotoForCourse/{linking}")]
        public IHttpActionResult UploadPhotoForCourse(string linking)
        {
            try
            {
                var photoLink = UploadPhoto(SaveFile(), linking);
                var updatedCourse = moderation.FindCourseByLinking(linking);
                updatedCourse.Photo = photoLink;
                moderation.UpdateCourse(updatedCourse);

                return this.Ok(photoLink);
            }
            catch (ArgumentNullException ex)
            {
                var message = $"Photo not found. {ex.Message}";
                return this.BadRequest(message);
            }
        }

        [HttpPost]
        [Route("Image/UploadPhotoForDeck/{linking}")]
        public IHttpActionResult UploadPhotoForDeck(string linking)
        {
            try
            {
                var photoLink = UploadPhoto(SaveFile(), linking);
                var updatedDeck = moderation.FindDeckByLinking(linking);
                updatedDeck.Photo = photoLink;
                moderation.UpdateDeck(updatedDeck);

                return this.Ok(photoLink);
            }
            catch (ArgumentNullException ex)
            {
                var message = $"Photo not found. {ex.Message}";
                return this.BadRequest(message);
            }
        }

        [HttpPost]
        [Route("Image/UploadPhotoForCategory/{linking}")]
        public IHttpActionResult UploadPhotoForCategory(string linking)
        {
            try
            {
                var photoLink = UploadPhoto(SaveFile(), linking);
                return this.Ok(photoLink);
            }
            catch (ArgumentNullException ex)
            {
                var message = $"Photo not found. {ex.Message}";
                return this.BadRequest(message);
            }
        }

        public string SaveFile()
        {
            var file =
                HttpContext.Current.Request.Files?[0]
                ?? throw new ArgumentNullException();

            var savePath = HttpContext.Current.Server.MapPath("~/uploads");

            if (file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);

                var path = Path.Combine(
                    savePath,
                    fileName
                );
                
                if (!Directory.Exists(savePath))
                {
                    DirectoryInfo di = Directory.CreateDirectory(savePath);
                }
                file.SaveAs(path);
            }

            return Path.Combine(savePath, file.FileName);
        }

        public string UploadPhoto(string localPath, string title)
        {
            IImage image;
            using (var fileStream = new FileStream(localPath, FileMode.Open))
            {
                image = uploader.UploadImageStreamAsync(fileStream).GetAwaiter().GetResult();
            }
            return image.Link;
        }
    }
}
