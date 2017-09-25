using MemoBll.Interfaces;
using MemoBll.Logic;
using MemoDAL;
using MemoDAL.Entities;
using MemoDTO;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memorise.Tests.BLL.LogicTests
{
	[TestFixture]
	public class AdministrationTests
	{
		public static IList<Category> categories = new List<Category>();
		public static IList<Course> courses = new List<Course>();
		public static IList<Role> roles = new List<Role>();
		public static IList<Deck> decks = new List<Deck>();
		public static IList<Card> cards = new List<Card>();
		public static IList<Statistics> statistics = new List<Statistics>();
		public static IList<User> users = new List<User>();
		public static IList<Answer> answers = new List<Answer>();

		public AdministrationTests()
		{
			#region Entity Initialization and Binding

			for (int i = 0; i < 3; i++)
			{
				categories.Add(new Category { Id = i, Name = $"Category{i}" });
				courses.Add(new Course { Id = i, Name = $"Course{i}" });
				decks.Add(new Deck { Id = i, Name = $"Decks{i}" });
				roles.Add(new Role { Id = i, Name = $"Role{i}" });
				statistics.Add(new Statistics { Id = i, SuccessPercent = i });
				users.Add(new User
				{
					Id = i,
					Login = $"User{i}",
					IsBlocked = i % 2 == 0 ? false : true
				});
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

			#region Mock Initialization and Setup

			//uowinistration
			//	.Setup(uow => uow.GetAllRoles())
			//	.Returns(roles);
			//uowinistration
			//	.Setup(uow => uow.GetRoles(users[0].Id))
			//	.Returns(users[0].Roles);
			//uowinistration
			//	.Setup(uow => uow.CreateRole(It.IsAny<Role>()));
			//uowinistration
			//	.Setup(uow => uow.UpdateRole(It.IsAny<Role>()));
			//uowinistration
			//	.Setup(uow => uow.DeleteRole(It.IsAny<Role>()));

			#endregion
		}

		[Test]
		public void GetDeckStatisticsTest()
		{
			Mock<IUnitOfWork> unitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
			unitOfWork
				.Setup(uow => uow.Statistics.GetAll())
				.Returns(statistics);
			var sut = new Administration(unitOfWork.Object);

			var expected = statistics.Where(s => s.Deck.Id == decks[0].Id);
			var actual = sut.GetDeckStatistics(decks[0].Id).ToList();

			Assert.AreEqual(expected, actual);
			unitOfWork.Verify(
				uow => uow.Statistics.GetAll(),
				Times.Once);
		}

		[Test]
		public void GetCourseTest()
		{
			Mock<IUnitOfWork> unitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
			unitOfWork
				.Setup(uow => uow.Courses.Get(courses[0].Id))
				.Returns(courses[0]);
			var sut = new Administration(unitOfWork.Object);

			var expected = courses[0];
			var actual = sut.GetCourse(courses[0].Id);

			Assert.AreEqual(expected, actual);
			unitOfWork.Verify(
				uow => uow.Courses.Get(courses[0].Id),
				Times.Once);
		}

		[Test]
		public void GetStatisticsTest()
		{
			Mock<IUnitOfWork> unitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
			unitOfWork
				   .Setup(uow => uow.Statistics.GetAll())
				   .Returns(statistics);
			var sut = new Administration(unitOfWork.Object);

			var expected = statistics
				.Where(s => s.Deck.Id == decks[0].Id && s.User.Id == users[0].Id);
			var actual = sut.GetStatistics(decks[0].Id, users[0].Id).ToList();

			Assert.AreEqual(expected, actual);
			unitOfWork.Verify(
				uow => uow.Statistics.GetAll(),
				Times.Once);
		}

		[Test]
		public void DeleteStatisticsTest()
		{
			Mock<IUnitOfWork> unitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
			unitOfWork
				   .Setup(uow => uow.Statistics.Delete(It.IsIn<Statistics>(statistics)));
			unitOfWork
				.Setup(uow => uow.Save());
			var sut = new Administration(unitOfWork.Object);

			sut.DeleteStatistics(statistics[0]);

			unitOfWork.Verify(
				uow => uow.Statistics.Delete(statistics[0]),
				Times.Once);
			unitOfWork.Verify(
				uow => uow.Save(),
				Times.Once);
		}

		[Test]
		public void GetUserTest()
		{
			Mock<IUnitOfWork> unitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
			unitOfWork
				   .Setup(uow => uow.Users.Get(users[0].Id))
				   .Returns(users[0]);
			var sut = new Administration(unitOfWork.Object);

			var expected = users[0];
			var actual = sut.GetUser(users[0].Id);

			Assert.AreEqual(expected, actual);
			unitOfWork.Verify(
				uow => uow.Users.Get(users[0].Id),
				Times.Once);
		}

		[Test]
		public void GetAllBlockedUsersTest()
		{
			Mock<IUnitOfWork> unitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
			unitOfWork
				   .Setup(uow => uow.Users.GetAll())
				   .Returns(users);
			var sut = new Administration(unitOfWork.Object);

			var expected = users.Where(u => u.IsBlocked).ToList();
			var actual = sut.GetAllBlockedUsers().ToList();

			Assert.AreEqual(expected, actual);
			unitOfWork.Verify(
				uow => uow.Users.GetAll(),
				Times.Once);
		}

		[Test]
		public void BlockUserTest()
		{
			Mock<IUnitOfWork> unitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
			unitOfWork
					  .Setup(uow => uow.Users.Get(users[0].Id))
					  .Returns(users[0]);
			unitOfWork
				.Setup(uow => uow.Save());
			var sut = new Administration(unitOfWork.Object);

			sut.BlockUser(users[0].Id);

			Assert.IsTrue(users[0].IsBlocked);
			unitOfWork.Verify(
				uow => uow.Users.Get(users[0].Id),
				Times.Once);
			unitOfWork.Verify(
				uow => uow.Save(),
				Times.Once);
		}

		[Test]
		public void UnblockUserTest()
		{
			Mock<IUnitOfWork> unitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
			unitOfWork
						 .Setup(uow => uow.Users.Get(users[0].Id))
						 .Returns(users[0]);
			unitOfWork
				.Setup(uow => uow.Save());
			var sut = new Administration(unitOfWork.Object);

			sut.UnblockUser(users[0].Id);

			Assert.IsFalse(users[0].IsBlocked);
			unitOfWork.Verify(
				uow => uow.Users.Get(users[0].Id),
				Times.Once);
			unitOfWork.Verify(
				uow => uow.Save(),
				Times.Once);
		}

		[Test]
		public void DeleteUserTest()
		{
			Mock<IUnitOfWork> unitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
			unitOfWork
				   .Setup(uow => uow.Users.Delete(users[0]));
			unitOfWork
				.Setup(uow => uow.Save());
			var sut = new Administration(unitOfWork.Object);

			sut.DeleteUser(users[0]);

			unitOfWork.Verify(
				uow => uow.Users.Delete(users[0]),
				Times.Once);
			unitOfWork.Verify(
				uow => uow.Save(),
				Times.Once);
		}

		[Test]
		public void CreateAnswerTest()
		{
			Mock<IUnitOfWork> unitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
			unitOfWork
				   .Setup(uow => uow.Answers.Create(answers[0]));

			var sut = new Administration(unitOfWork.Object);

			sut.CreateAnswer(answers[0]);

			unitOfWork.Verify(
				uow => uow.Answers.Create(answers[0]),
				Times.Once);
		}

		[Test]
		public void UpdateAnswerTest()
		{
			Mock<IUnitOfWork> unitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
			unitOfWork
				   .Setup(uow => uow.Answers.Update(answers[0]));

			var sut = new Administration(unitOfWork.Object);

			sut.UpdateAnswer(answers[0]);

			unitOfWork.Verify(
				uow => uow.Answers.Update(answers[0]),
				Times.Once);
		}

		[Test]
		public void RemoveAnswerTest()
		{
			Mock<IUnitOfWork> unitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
			unitOfWork
				   .Setup(uow => uow.Answers.Delete(answers[0]));
			var sut = new Administration(unitOfWork.Object);

			sut.RemoveAnswer(answers[0]);

			unitOfWork.Verify(
				uow => uow.Answers.Delete(answers[0]),
				Times.Once);
		}

		[Test]
		public void GetAllCorrectAnswersInCardTest()
		{
			Mock<IUnitOfWork> unitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
			unitOfWork
				   .Setup(uow => uow.Answers.GetAll())
				   .Returns(answers);
			var sut = new Administration(unitOfWork.Object);

			var expected = answers
				.Where(a => a.Card.Id == cards[0].Id && a.IsCorrect);
			var actual = sut.GetAllCorrectAnswersInCard(cards[0].Id);

			Assert.AreEqual(expected, actual);
			unitOfWork.Verify(
				uow => uow.Answers.GetAll(),
				Times.Once);
		}

		[Test]
		public void AddCategoryTest()
		{
			Mock<IUnitOfWork> unitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
			unitOfWork
				   .Setup(uow => uow.Categories.Create(categories[0]));

			var sut = new Administration(unitOfWork.Object);

			sut.AddCategory(categories[0]);

			unitOfWork.Verify(
				uow => uow.Categories.Create(categories[0]),
				Times.Once);
		}

		[Test]
		public void UpdateCategoryTest()
		{
			Mock<IUnitOfWork> unitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
			unitOfWork
				.Setup(uow => uow.Categories.Update(categories[0]));

			var sut = new Administration(unitOfWork.Object);

			sut.UpdateCategory(categories[0]);

			unitOfWork.Verify(
				uow => uow.Categories.Update(categories[0]),
				Times.Once);
		}

		[Test]
		public void RemoveCategoryTest()
		{
			Mock<IUnitOfWork> unitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
			unitOfWork
				   .Setup(uow => uow.Categories.Delete(categories[0]));
			var sut = new Administration(unitOfWork.Object);

			sut.RemoveCategory(categories[0]);

			unitOfWork.Verify(
				uow => uow.Categories.Delete(categories[0]),
				Times.Once);
		}

		[Test]
		public void AddCourseTest()
		{
			Mock<IUnitOfWork> unitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
			unitOfWork
				   .Setup(uow => uow.Courses.Create(courses[0]));
			var sut = new Administration(unitOfWork.Object);

			sut.CreateCourse(courses[0]);

			unitOfWork.Verify(
				uow => uow.Courses.Create(courses[0]),
				Times.Once);
		}

		[Test]
		public void UpdateCourseTest()
		{
			Mock<IUnitOfWork> unitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
			unitOfWork
				.Setup(uow => uow.Courses.Update(courses[0]));
			var sut = new Administration(unitOfWork.Object);

			sut.UpdateCourse(courses[0]);

			unitOfWork.Verify(
				uow => uow.Courses.Update(courses[0]),
				Times.Once);
		}

		[Test]
		public void RemoveCourseTest()
		{
			Mock<IUnitOfWork> unitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
			unitOfWork
				.Setup(uow => uow.Courses.Delete(courses[0]));
			var sut = new Administration(unitOfWork.Object);

			sut.RemoveCourse(courses[0]);

			unitOfWork.Verify(
				uow => uow.Courses.Delete(courses[0]),
				Times.Once);
		}
	}
}
