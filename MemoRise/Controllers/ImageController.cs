﻿using FlickrNet;
using MemoRise.Helpers;
using System;
using System.Configuration;
using System.Linq;
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
			flickr = FlickrManager.GetInstance();
		}

		[HttpGet]
		[Route("memo/images/course/{name}")]
		public IHttpActionResult GetPhotoForCourseByName(string name)
		{
			try
			{
				var photo = flickr.PhotosetsGetPhotos(
				ConfigurationManager.AppSettings["flickrGalleryId"],
				PhotoSearchExtras.OriginalUrl)
				.First(ph => ph.Title == name);

				return Ok(photo.OriginalUrl);
			}
			catch (ArgumentNullException ex)
			{
				var message = $"Photo not found. {ex.Message}";
				return BadRequest(message);
			}
		}

		[HttpPost]
		[Authorize(Roles = "Moderator")]
		[Route("memo/images/upload")]
		public IHttpActionResult UploadPhoto()
		{
			try
			{
				// To implement upload with FlickrNet library you'll need to use syntax:

				// OAuthAccessToken accessToken = new OAuthAccessToken();
				// accessToken.FullName = "your app name"; -> here "Memorise"
				// accessToken.Token = "get it from Flickr Website for your login";
				// accessToken.TokenSecret = "get it from Flickr Website for your login";
				// accessToken.UserId = "get it from Flickr Website for your login";
				// accessToken.Username = "get it from Flickr Website for your login";
				// FlickrManager.OAuthToken = accessToken;
				// Flickr flickr = FlickrManager.GetAuthInstance();
				// string FileuploadedID = flickr.UploadPicture(@url, title, description, tags, true, false, false);
				// PhotoInfo oPhotoInfo = flickr.PhotosGetInfo(FileuploadedID);

				return Ok();
			}
			catch (ArgumentNullException ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}