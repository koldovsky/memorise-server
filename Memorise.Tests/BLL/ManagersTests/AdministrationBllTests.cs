//using MemoBll.Interfaces;
//using MemoBll.Managers;
//using MemoDAL.Entities;
//using MemoDTO;
//using Moq;
//using NUnit.Framework;
//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace Memorise.Tests
//{
//	[TestFixture]
//	class AdministrationBllTests
//	{
//		public static IList<Category> categories = new List<Category>();
//		public static IList<Course> courses = new List<Course>();
//		public static IList<Role> roles = new List<Role>();
//		public static IList<Deck> decks = new List<Deck>();
//		public static IList<Card> cards = new List<Card>();
//		public static IList<Statistics> statistics = new List<Statistics>();
//		public static IList<User> users = new List<User>();
//		public static IList<Answer> answers = new List<Answer>();
//		Mock<IAdministration> administration = new Mock<IAdministration>(MockBehavior.Strict);
//		Mock<IConverterToDTO> converter = new Mock<IConverterToDTO>(MockBehavior.Strict);

//		public AdministrationBllTests()
//		{
//			#region Entity Initialization and Binding

//			for (int i = 0; i < 3; i++)
//			{
//				categories.Add(new Category { Id = i, Name = $"Category{i}" });
//				courses.Add(new Course { Id = i, Name = $"Course{i}" });
//				decks.Add(new Deck { Id = i, Name = $"Decks{i}" });
//				roles.Add(new Role { Id = i, Name = $"Role{i}" });
//				statistics.Add(new Statistics { Id = i, SuccessPercent = i });
//				users.Add(new User
//				{
//					Id = i, Login = $"User{i}",
//					IsBlocked = i % 2 == 0 ? false : true
//				});
//				answers.Add(new Answer { Id = i, Text = $"Answer{i}"});
//				cards.Add(new Card { Id = i });
//			}

//			courses[0].Decks.Add(decks[0]);
//			courses[1].Decks.Add(decks[2]);
//			courses[2].Decks.Add(decks[0]);
//			courses[0].Decks.Add(decks[1]);

//			categories[1].Decks.Add(decks[0]);
//			categories[1].Decks.Add(decks[2]);
//			categories[0].Decks.Add(decks[0]);
//			categories[2].Decks.Add(decks[1]);

//			categories[1].Courses.Add(courses[0]);
//			categories[1].Courses.Add(courses[2]);
//			categories[0].Courses.Add(courses[0]);
//			categories[2].Courses.Add(courses[1]);
			
//			statistics[0].Deck = decks[0];
//			statistics[0].User = users[0];

//			statistics[1].Deck = decks[0];
//			statistics[1].User = users[2];

//			statistics[2].Deck = decks[1];
//			statistics[2].User = users[0];
//			#endregion

//			#region Mock Initialization and Setup

//			//administration
//			//	.Setup(adm => adm.GetAllRoles())
//			//	.Returns(roles);
//			//administration
//			//	.Setup(adm => adm.GetRoles(users[0].Id))
//			//	.Returns(users[0].Roles);
//			//administration
//			//	.Setup(adm => adm.CreateRole(It.IsAny<Role>()));
//			//administration
//			//	.Setup(adm => adm.UpdateRole(It.IsAny<Role>()));
//			//administration
//			//	.Setup(adm => adm.DeleteRole(It.IsAny<Role>()));

//			administration
//				.Setup(adm => adm.GetDeckStatistics(decks[0].Id))
//				.Returns(statistics.Where(s => s.Deck.Id == decks[0].Id).ToList());
//			administration
//				.Setup(adm => adm.GetCourse(courses[0].Id))
//				.Returns(courses[0]);
//			administration
//				.Setup(adm => adm.GetStatistics(decks[0].Id, users[0].Id))
//				.Returns(statistics.Where(x => x.Deck.Id == decks[0].Id && x.User.Id == users[0].Id).ToList());
//			administration
//				.Setup(adm => adm.DeleteStatistics(It.IsAny<Statistics>()));
//			administration
//				.Setup(adm => adm.GetAllUsersOnRole(roles[0].Name))
//				.Returns(roles[0].Users);
//			administration
//				.Setup(adm => adm.GetUser(users[0].Id))
//				.Returns(users[0]);
//			administration
//				.Setup(adm => adm.GetAllBlockedUsers())
//				.Returns(users.Where(u => u.IsBlocked == true).ToList());
//			administration
//				.Setup(adm => adm.BlockUser(users[0].Id));
//			administration
//				.Setup(adm => adm.UnblockUser(users[0].Id));
//			administration
//				.Setup(adm => adm.DeleteUser(users[0]));
//			administration
//				.Setup(adm => adm.CreateAnswer(It.IsAny<Answer>()));
//			administration
//				.Setup(adm => adm.UpdateAnswer(It.IsAny<Answer>()));
//			administration
//				.Setup(adm => adm.RemoveAnswer(It.IsAny<Answer>()));
//			administration
//				.Setup(adm => adm.GetAllCorrectAnswersInCard(cards[0].Id))
//				.Returns(cards[0].Answers.Where(a => a.IsCorrect).ToList());
//			administration
//				.Setup(adm => adm.AddCategory(It.IsAny<Category>()));
//			administration
//				.Setup(adm => adm.UpdateCategory(It.IsAny<Category>()));
//			administration
//				.Setup(adm => adm.RemoveCategory(It.IsAny<Category>()));
//			administration
//				.Setup(adm => adm.CreateCourse(It.IsAny<Course>()));
//			administration
//				.Setup(adm => adm.UpdateCourse(It.IsAny<Course>()));
//			administration
//				.Setup(adm => adm.RemoveCourse(It.IsAny<Course>()));

//			converter
//				.Setup(c => c.ConvertToCategoryDTO(It.IsIn<Category>(categories)))
//				.Returns(new CategoryDTO());
//			converter
//				.Setup(c => c.ConvertToDeckDTO(It.IsIn<Deck>(decks)))
//				.Returns(new DeckDTO());
//			converter
//				.Setup(c => c.ConvertToCourseDTO(It.IsIn<Course>(courses)))
//				.Returns(new CourseDTO());
//			converter
//				.Setup(c => c.ConvertToCourseWithDecksDTO(It.IsIn<Course>(courses)))
//				.Returns(new CourseWithDecksDTO());

//			#endregion
//		}

//		[Test]
//		public void GetDeckStatisticsTest()
//		{
//			var sut = new AdministrationBll(
//				administration.Object, 
//				converter.Object);

//			var expected =
//				statistics
//				.Where(s => s.Deck.Id == decks[0].Id)
//				.Select(s => s.SuccessPercent)
//				.Average();
//			var actual = sut.GetDeckStatistics(decks[0].Id);

//			Assert.AreEqual(Math.Round(expected), actual);
//			this.administration.Verify(
//				adm => adm.GetDeckStatistics(decks[0].Id), 
//				Times.Once());
//		}

//		//[Test]
//		public void GetCourseStatisticsTest()
//		{
//			var sut = new AdministrationBll(
//				administration.Object,
//				converter.Object);

//			//var expected =
//			//	courses[0].Decks
//			//	.Where(s => s.Course.Id == courses[0].Id)
//			//	.Select(s => s.SuccessPercent)
//			//	.Average();
//			var actual = sut.GetCourseStatistics(courses[0].Id);

//			//Assert.AreEqual(Math.Round(expected), actual);
//			this.administration.Verify(
//				adm => adm.GetDeckStatistics(decks[0].Id),
//				Times.Once());
//		}

//		// TODO: There is a mistake in the manager, where Count of
//		// decks list is invoked.
//		[Test]
//		public void GetStatisticsTest()
//		{
//			var sut = new AdministrationBll(
//				administration.Object,
//				converter.Object);

//			var expected =
//				statistics
//				.First(s => s.Deck.Id == decks[0].Id && s.User.Id == users[0].Id)
//				.SuccessPercent;
//			var actual = sut.GetStatistics(decks[0].Id, users[0].Id);

//			Assert.AreEqual(expected, actual);
//			this.administration.Verify(
//				adm => adm.GetDeckStatistics(decks[0].Id),
//				Times.Once());
//		}

//		[Test]
//		public void DeleteStatisticsTest()
//		{
//			var sut = new AdministrationBll(
//				administration.Object,
//				converter.Object);
			
//			sut.DeleteStatistics(statistics[0]);

//			this.administration.Verify(
//				adm => adm.DeleteStatistics(statistics[0]),
//				Times.Once());
//		}

//		[Test]
//		public void GetUserTest()
//		{
//			var sut = new AdministrationBll(
//				administration.Object,
//				converter.Object);

//			var expected = users[0];
//			var actual = sut.GetUser(users[0].Id);

//			Assert.AreEqual(expected, actual);
//			this.administration.Verify(
//				adm => adm.GetUser(users[0].Id),
//				Times.Once());
//		}

//		[Test]
//		public void GetAllBlockedUsersTest()
//		{
//			var sut = new AdministrationBll(
//				administration.Object,
//				converter.Object);

//			var expected = users.Where(u => u.IsBlocked).ToList();
//			var actual = sut.GetAllBlockedUsers();

//			Assert.AreEqual(expected, actual);
//			this.administration.Verify(
//				adm => adm.GetAllBlockedUsers(),
//				Times.Once());
//		}

//		[Test]
//		public void BlockUserTest()
//		{
//			var sut = new AdministrationBll(
//				administration.Object,
//				converter.Object);
			
//			sut.BlockUser(users[0].Id);

//			this.administration.Verify(
//				adm => adm.BlockUser(users[0].Id),
//				Times.Once());
//		}

//		[Test]
//		public void UnblockUserTest()
//		{
//			var sut = new AdministrationBll(
//				administration.Object,
//				converter.Object);

//			sut.UnblockUser(users[0].Id);

//			this.administration.Verify(
//				adm => adm.UnblockUser(users[0].Id),
//				Times.Once());
//		}

//		[Test]
//		public void DeleteUserTest()
//		{
//			var sut = new AdministrationBll(
//				administration.Object,
//				converter.Object);

//			sut.DeleteUser(users[0]);

//			this.administration.Verify(
//				adm => adm.DeleteUser(users[0]),
//				Times.Once());
//		}

//		[Test]
//		public void CreateAnswerTest()
//		{
//			var sut = new AdministrationBll(
//				administration.Object,
//				converter.Object);

//			sut.CreateAnswer(answers[0]);

//			this.administration.Verify(
//				adm => adm.CreateAnswer(answers[0]),
//				Times.Once());
//		}

//		[Test]
//		public void UpdateAnswerTest()
//		{
//			var sut = new AdministrationBll(
//				administration.Object,
//				converter.Object);

//			sut.UpdateAnswer(answers[0]);

//			this.administration.Verify(
//				adm => adm.UpdateAnswer(answers[0]),
//				Times.Once());
//		}

//		[Test]
//		public void RemoveAnswerTest()
//		{
//			var sut = new AdministrationBll(
//				administration.Object,
//				converter.Object);

//			sut.RemoveAnswer(answers[0]);

//			this.administration.Verify(
//				adm => adm.RemoveAnswer(answers[0]),
//				Times.Once());
//		}

//		[Test]
//		public void GetAllCorrectAnswersInCard()
//		{
//			var sut = new AdministrationBll(
//				administration.Object,
//				converter.Object);

//			var expected = cards[0].Answers.Select(a => a.IsCorrect).ToList();
//			var actual = sut.GetAllCorrectAnswersInCard(cards[0].Id).ToList();

//			Assert.AreEqual(expected, actual);
//			this.administration.Verify(
//				adm => adm.GetAllCorrectAnswersInCard(cards[0].Id),
//				Times.Once());
//		}

//		[Test]
//		public void AddCategoryTest()
//		{
//			var sut = new AdministrationBll(
//				administration.Object,
//				converter.Object);

//			sut.AddCategory(categories[0]);

//			this.administration.Verify(
//				adm => adm.AddCategory(categories[0]),
//				Times.Once());
//		}

//		[Test]
//		public void UpdateCategoryTest()
//		{
//			var sut = new AdministrationBll(
//				administration.Object,
//				converter.Object);

//			sut.UpdateCategory(categories[0]);

//			this.administration.Verify(
//				adm => adm.UpdateCategory(categories[0]),
//				Times.Once());
//		}

//		[Test]
//		public void RemoveCategoryTest()
//		{
//			var sut = new AdministrationBll(
//				administration.Object,
//				converter.Object);

//			sut.RemoveCategory(categories[0]);

//			this.administration.Verify(
//				adm => adm.RemoveCategory(categories[0]),
//				Times.Once());
//		}
		
//		[Test]
//		public void CreateCourseTest()
//		{
//			var sut = new AdministrationBll(
//				administration.Object,
//				converter.Object);

//			sut.CreateCourse(courses[0]);

//			this.administration.Verify(
//				adm => adm.CreateCourse(courses[0]),
//				Times.Once());
//		}

//		[Test]
//		public void UpdateCourseTest()
//		{
//			var sut = new AdministrationBll(
//				administration.Object,
//				converter.Object);

//			sut.UpdateCourse(courses[0]);

//			this.administration.Verify(
//				adm => adm.UpdateCourse(courses[0]),
//				Times.Once());
//		}

//		[Test]
//		public void RemoveCourseTest()
//		{
//			var sut = new AdministrationBll(
//				administration.Object,
//				converter.Object);

//			sut.RemoveCourse(courses[0]);

//			this.administration.Verify(
//				adm => adm.RemoveCourse(courses[0]),
//				Times.Once());
//		}
//	}
//}
