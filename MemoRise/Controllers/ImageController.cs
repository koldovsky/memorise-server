using Imgur.API.Endpoints.Impl;
using Imgur.API.Models;
using MemoBll.Logic;
using MemoBll.Managers;
using MemoDAL;
using MemoRise.Helpers;
using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace MemoRise.Controllers
{
    // TODO: Implement exception handling for saving.
    /// <summary>
    /// Controller responsible for uploading photos to the remote hosting.
    /// </summary>
    public class ImageController : ApiController
    {
        private ImageEndpoint uploader;
        private Moderation moderation;

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
                var path = SaveFile();
                var photoLink = UploadPhoto(path, linking);
                return this.Ok(photoLink);
            }
            catch (ArgumentNullException ex)
            {
                var message = $"Photo not found. {ex.Message}";
                return this.BadRequest(message);
            }
        }

        [NonAction]
        public string SaveFile()
        {
            var file =
                HttpContext.Current.Request.Files[0];

            var savePath = HttpContext.Current.Server.MapPath("~/uploads");

            if (file.ContentLength <= 0 || !CheckImageDimensions(file))
            {
                return string.Empty;
            }

            var fileName = Path.GetFileName(file.FileName);

            var path = Path.Combine(
                savePath,
                fileName);

            if (!Directory.Exists(savePath))
            {
                Directory.CreateDirectory(savePath);
            }

            file.SaveAs(path);

            return Path.Combine(savePath, file.FileName);
        }

        /// <summary>
        /// Checks uploaded image dimensions. 
        /// Default behaviour: check if image is square.
        /// </summary>
        /// <param name="image">Uploaded image of type <typeparamref>
        ///         <name>HttpPostedFile</name>
        ///     </typeparamref>
        /// which dimensions are to be checked.
        /// </param>
        /// <param name="width">Needed width.</param>
        /// <param name="height">Needed height.</param>
        /// <returns>True if image has the requested dimesions, false if not.</returns>
        [NonAction]
        public bool CheckImageDimensions(
            HttpPostedFile image, 
            int width = 0, 
            int height = 0)
        {
            var img = Image.FromStream(image.InputStream);

            if (width <= 0 || height <= 0)
            {
                return img.Height == img.Width;
            }

            return img.Height == height
                   && img.Width == width;
        }

        [NonAction]
        public string UploadPhoto(string localPath, string title)
        {
            IImage image;
            using (var fileStream = new FileStream(localPath, FileMode.Open))
            {
                image = uploader
                    .UploadImageStreamAsync(fileStream)
                    .GetAwaiter()
                    .GetResult();
            }

            return image.Link;
        }
    }
}
