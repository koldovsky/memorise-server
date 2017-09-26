using MemoDAL.Entities;
using NUnit.Framework;
using System.Collections.Generic;

namespace Memorise.Tests.BLL.LogicTests
{
	[TestFixture]
	public class ConverterToDTOTests
	{
		public static IList<Category> categories = new List<Category>();
		public static IList<Course> courses = new List<Course>();
		public static IList<Role> roles = new List<Role>();
		public static IList<Deck> decks = new List<Deck>();
		public static IList<Card> cards = new List<Card>();
		public static IList<Statistics> statistics = new List<Statistics>();
		public static IList<User> users = new List<User>();
		public static IList<Answer> answers = new List<Answer>();

		public ConverterToDTOTests()
		{
			#region Entity Initialization and Binding

			for (int i = 0; i < 3; i++)
			{
				categories.Add(new Category { Id = i, Name = $"Category{i}" });
				courses.Add(new Course { Id = i, Name = $"Course{i}" });
				decks.Add(new Deck { Id = i, Name = $"Decks{i}" });
				//roles.Add(new Role { Id = i, Name = $"Role{i}" });
				statistics.Add(new Statistics { Id = i, SuccessPercent = i });
				//users.Add(new User
				//{
				//	Id = i,
				//	Login = $"User{i}",
				//	IsBlocked = i % 2 == 0 ? false : true
				//});
				answers.Add(new Answer
				{
					Id = i,
					Text = $"Answer{i}",
					IsCorrect = i % 2 == 0 ? false : true
				});
				cards.Add(new Card { Id = i });
				cards[0].Answers.Add(answers[i]);
				answers[i].Card = cards[0];
			}

			courses[0].Decks.Add(decks[0]);
			courses[1].Decks.Add(decks[2]);
			courses[2].Decks.Add(decks[0]);
			courses[0].Decks.Add(decks[1]);

			categories[1].Decks.Add(decks[0]);
			categories[1].Decks.Add(decks[2]);
			categories[0].Decks.Add(decks[0]);
			categories[2].Decks.Add(decks[1]);

			categories[1].Courses.Add(courses[0]);
			categories[1].Courses.Add(courses[2]);
			categories[0].Courses.Add(courses[0]);
			categories[2].Courses.Add(courses[1]);

			statistics[0].Deck = decks[0];
			statistics[0].User = users[0];

			statistics[1].Deck = decks[0];
			statistics[1].User = users[2];

			statistics[2].Deck = decks[1];
			statistics[2].User = users[0];

			#endregion
		}

		[Test]
		public void ConvertToDeckDTO()
		{

		}
	}
}
