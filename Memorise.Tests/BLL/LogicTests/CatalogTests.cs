using MemoBll.Logic;
using MemoDAL;
using MemoDAL.Entities;
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
	public class CatalogTests
	{
		public static IList<Category> categories = new List<Category>();
		public static IList<Course> courses = new List<Course>();
		public static IList<Deck> decks = new List<Deck>();

		public CatalogTests()
		{
			#region Entity Initialization and Binding

			for (int i = 0; i < 3; i++)
			{
				categories.Add(new Category { Id = i, Name = $"Category{i}" });
				courses.Add(new Course { Id = i, Name = $"Course{i}" });
				decks.Add(new Deck { Id = i, Name = $"Decks{i}" });
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

			#endregion
		}

		[Test]
		public void GetAllCategoriesTest()
		{
			Mock<IUnitOfWork> unitOfWork 
				= new Mock<IUnitOfWork>(MockBehavior.Strict);
			unitOfWork
				.Setup(uow => uow.Categories.GetAll())
				.Returns(categories);
			var sut = new Catalog(unitOfWork.Object);

			var actual = sut.GetAllCategories();
			var expected = categories;

			Assert.AreEqual(expected, actual);
			unitOfWork.Verify(
				uow => uow.Categories.GetAll(), Times.Once);
		}

		[Test]
		public void GetAllCoursesTest()
		{
			Mock<IUnitOfWork> unitOfWork
				= new Mock<IUnitOfWork>(MockBehavior.Strict);
			unitOfWork
				.Setup(uow => uow.Courses.GetAll())
				.Returns(courses);
			var sut = new Catalog(unitOfWork.Object);

			var actual = sut.GetAllCourses();
			var expected = courses;

			Assert.AreEqual(expected, actual);
			unitOfWork.Verify(
				uow => uow.Courses.GetAll(), Times.Once);
		}

		[Test]
		public void GetAllDecksTest()
		{
			Mock<IUnitOfWork> unitOfWork
				= new Mock<IUnitOfWork>(MockBehavior.Strict);
			unitOfWork
				.Setup(uow => uow.Decks.GetAll())
				.Returns(decks);
			var sut = new Catalog(unitOfWork.Object);

			var actual = sut.GetAllDecks();
			var expected = decks;

			Assert.AreEqual(expected, actual);
			unitOfWork.Verify(
				uow => uow.Decks.GetAll(), Times.Once);
		}

		[Test]
		public void GetAllDecksByCourseTest()
		{
			Mock<IUnitOfWork> unitOfWork
				= new Mock<IUnitOfWork>(MockBehavior.Strict);
			unitOfWork
				.Setup(uow => uow.Courses.GetAll())
				.Returns(courses);
			var sut = new Catalog(unitOfWork.Object);

			var course = courses[0];

			var actual = sut.GetAllDecksByCourse(course.Name);
			var expected = course.Decks;

			Assert.AreEqual(expected, actual);
			unitOfWork.Verify(
				uow => uow.Courses.GetAll(), Times.Once);
		}

		[Test]
		public void GetAllDecksByCategoryTest()
		{
			Mock<IUnitOfWork> unitOfWork
				= new Mock<IUnitOfWork>(MockBehavior.Strict);
			unitOfWork
				.Setup(uow => uow.Categories.GetAll())
				.Returns(categories);
			var sut = new Catalog(unitOfWork.Object);

			var category = categories[0];

			var actual = sut.GetAllDecksByCategory(category.Name);
			var expected = category.Decks;

			Assert.AreEqual(expected, actual);
			unitOfWork.Verify(
				uow => uow.Categories.GetAll(), Times.Once);
		}

		[Test]
		public void GetAllCoursesByCategoryTest()
		{
			Mock<IUnitOfWork> unitOfWork
				= new Mock<IUnitOfWork>(MockBehavior.Strict);
			unitOfWork
				.Setup(uow => uow.Categories.GetAll())
				.Returns(categories);
			var sut = new Catalog(unitOfWork.Object);

			var category = categories[0];

			var actual = sut.GetAllCoursesByCategory(category.Name);
			var expected = category.Courses;

			Assert.AreEqual(expected, actual);
			unitOfWork.Verify(
				uow => uow.Categories.GetAll(), Times.Once);
		}

		[Test]
		public void GetCourseTest()
		{
			Mock<IUnitOfWork> unitOfWork
				= new Mock<IUnitOfWork>(MockBehavior.Strict);
			unitOfWork
				.Setup(uow => uow.Courses.GetAll())
				.Returns(courses);
			var sut = new Catalog(unitOfWork.Object);

			var course = courses[0];

			var actual = sut.GetCourse(course.Name);
			var expected = course;

			Assert.AreEqual(expected, actual);
			unitOfWork.Verify(
				uow => uow.Courses.GetAll(), Times.Once);
		}
	}
}
