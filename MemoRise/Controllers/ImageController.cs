using FlickrNet;
using MemoRise.Helpers;
using System;
using System.Configuration;
using System.IO;
using System.Web;
using System.Web.Http;

namespace MemoRise.Controllers
{
    /// <summary>
    /// Controller responsible for uploading photos to the remote hosting.
    /// </summary>
    public class ImageController : ApiController
    {
        private Flickr flickr;

        public ImageController()
        {
            this.flickr = FlickrManager.GetInstance();
        }

        [HttpPost]
        [Route("memo/images/course/{linking}")]
        public IHttpActionResult UploadPhotoForCourse(string linking)
        {
            try
            {
                var photo = UploadPhoto(SaveFile(), linking);

                this.flickr.PhotosetsAddPhoto(
                    ConfigurationManager.AppSettings["flickrCourseGalleryId"],
                    photo.PhotoId);

                return this.Ok(photo.OriginalUrl);
            }
            catch (ArgumentNullException ex)
            {
                var message = $"Photo not found. {ex.Message}";
                return this.BadRequest(message);
            }
        }

        [HttpPost]
        [Route("memo/images/deck/{linking}")]
        public IHttpActionResult UploadPhotoForDeck(string linking)
        {
            try
            {
                var photo = UploadPhoto("", linking);

                this.flickr.PhotosetsAddPhoto(
                    ConfigurationManager.AppSettings["flickrDeckGalleryId"],
                    photo.PhotoId);

                return this.Ok(photo.OriginalUrl);
            }
            catch (ArgumentNullException ex)
            {
                var message = $"Photo not found. {ex.Message}";
                return this.BadRequest(message);
            }
        }

        [HttpPost]
        [Route("memo/images/category/{linking}")]
        public IHttpActionResult UploadPhotoForCategory(string linking)
        {
            try
            {
                var photo = UploadPhoto("", linking);

                this.flickr.PhotosetsAddPhoto(
                    ConfigurationManager.AppSettings["flickrCategoryGalleryId"],
                    photo.PhotoId);

                return this.Ok(photo.OriginalUrl);
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
                HttpContext.Current.Request.Files[0]
                ?? throw new ArgumentNullException();

            if (file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);

                var path = Path.Combine(
                    HttpContext.Current.Server.MapPath("~/uploads"),
                    fileName
                );

                file.SaveAs(path);
            }

            return Path.Combine("/uploads", file.FileName);
        }

        public PhotoInfo UploadPhoto(string localPath, string title)
        {
            Flickr flickr = FlickrManager.GetAuthInstance();
            string FileuploadedID = flickr.UploadPicture(
                @localPath,
                title);
            return flickr.PhotosGetInfo(FileuploadedID);
        }
    }
}
