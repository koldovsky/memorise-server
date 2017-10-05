using FlickrNet;
using MemoDTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MemoRise.Helpers
{
	public class PhotoUrlLoader
	{
		public static void LoadCoursesPhotos(
			IEnumerable<CourseDTO> courses)
		{
			var photos = FlickrManager.GetInstance()
					.PhotosetsGetPhotos(
					ConfigurationManager.AppSettings["flickrCourseGalleryId"])
					.Where(ph => courses.Select(c => c.Linking).Contains(ph.Title));

			foreach (var course in courses)
			{
				course.Photo = photos.FirstOrDefault(ph => ph.Title == course.Linking)?.SmallUrl;
			}
		}

		public static void LoadCourseAndDecksPhotos(
			CourseWithDecksDTO course)
		{
			var photos = FlickrManager.GetInstance()
					.PhotosetsGetPhotos(
					ConfigurationManager.AppSettings["flickrCourseGalleryId"]);
			course.Photo = photos
							.FirstOrDefault(ph => ph.Title == course.Linking)
							?.MediumUrl;

			var photosFiltered =
                FlickrManager.GetInstance()
                    .PhotosetsGetPhotos(
                    ConfigurationManager.AppSettings["flickrDeckGalleryId"])
                    .Where( ph => course.Decks
					.Select(deck => deck.Linking)
					.Contains(ph.Title));

			foreach (var deck in course.Decks)
			{
				deck.Photo = photosFiltered.FirstOrDefault(ph => ph.Title == deck.Linking)?.SmallUrl;
			}
		}

		public static void LoadDecksPhotos(
			IEnumerable<DeckDTO> decks)
		{
			var photos = FlickrManager.GetInstance()
					.PhotosetsGetPhotos(
					ConfigurationManager.AppSettings["flickrDeckGalleryId"])
					.Where(ph => decks.Select(c => c.Linking).Contains(ph.Title));

			foreach (var deck in decks)
			{
				deck.Photo = photos.FirstOrDefault(ph => ph.Title == deck.Linking)?.SmallUrl;
			}
		}


	}
}