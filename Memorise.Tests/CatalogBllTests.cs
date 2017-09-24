using MemoBll;
using MemoDAL;
using MemoDAL.Entities;
using MemoDTO;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Memorise.Tests
{
	[TestFixture]
	class CatalogBllTests
	{
		public static IList<Category> categories = new List<Category>();
		public static IList<Course> courses = new List<Course>();
		public static IList<Deck> decks = new List<Deck>();
		Mock<IUnitOfWork> unitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
		Mock<IConverterToDTO> converter = new Mock<IConverterToDTO>(MockBehavior.Strict);

		public CatalogBllTests()
		{
			for (int i = 0; i < 3; i++)
			{
				categories.Add(new Category { Id = i, Name = $"Category{i}" });
				courses.Add(new Course { Id = i, Name = $"Decks{i}" });
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

			unitOfWork.Setup(uow => uow.Categories.GetAll()).Returns(categories);
			unitOfWork.Setup(uow => uow.Decks.GetAll()).Returns(decks);
			unitOfWork.Setup(uow => uow.Courses.GetAll()).Returns(courses);

			converter
				.Setup(c => c.ConvertToCategoryDTO(It.IsIn<Category>(categories)))
				.Returns(new CategoryDTO());
			converter
				.Setup(c => c.ConvertToDeckDTO(It.IsIn<Deck>(decks)))
				.Returns(new DeckDTO());
			converter
				.Setup(c => c.ConvertToCourseDTO(It.IsIn<Course>(courses)))
				.Returns(new CourseDTO());
			converter
				.Setup(c => c.ConvertToCourseWithDecksDTO(It.IsIn<Course>(courses)))
				.Returns(new CourseWithDecksDTO());
		}

		[SetUp]
		public void Init()
		{
			unitOfWork.ResetCalls();
			converter.ResetCalls();
		}

		[Test]
		public void GetAllCategoriesTest()
		{
			var catalog = new CatalogBll(unitOfWork.Object, converter.Object);

			var actual = catalog.GetAllCategories();

			unitOfWork.Verify(uow => uow.Categories.GetAll(), Times.Exactly(1));
			Assert.That(actual, Is.All.InstanceOf(typeof(CategoryDTO)));
			Assert.AreEqual(categories.Count, actual.Count);
		}

		[Test]
		public void GetAllDecksTest()
		{
			var catalog = new CatalogBll(unitOfWork.Object, converter.Object);

			var actual = catalog.GetAllDecks();

			unitOfWork.Verify(uow => uow.Decks.GetAll(), Times.Exactly(1));
			Assert.That(actual, Is.All.InstanceOf(typeof(DeckDTO)));
			Assert.AreEqual(decks.Count, actual.Count);
		}

		[Test]
		public void GetAllCoursesTest()
		{
			var catalog = new CatalogBll(unitOfWork.Object, converter.Object);

			var actual = catalog.GetAllCourses();

			unitOfWork.Verify(uow => uow.Courses.GetAll(), Times.Exactly(1));
			Assert.That(actual, Is.All.InstanceOf(typeof(CourseDTO)));
			Assert.AreEqual(courses.Count, actual.Count);
		}

		[Test]
		public void GetAllDecksByCourseTest()
		{
			var catalog = new CatalogBll(unitOfWork.Object, converter.Object);

			foreach (var course in courses)
			{
				unitOfWork.ResetCalls();
				converter.ResetCalls();
				var actual = catalog.GetAllDecksByCourse(course.Name);

				unitOfWork.Verify(uow => uow.Courses.GetAll(), Times.Exactly(1));
				Assert.That(actual, Is.All.InstanceOf(typeof(DeckDTO)));
				Assert.AreEqual(course.Decks.Count, actual.Count);

			}
		}

		[Test]
		public void GetAllDecksByCategoryTest()
		{
			var catalog = new CatalogBll(unitOfWork.Object, converter.Object);

			foreach (var category in categories)
			{
				unitOfWork.ResetCalls();
				converter.ResetCalls();
				var actual = catalog.GetAllDecksByCategory(category.Name);

				unitOfWork.Verify(uow => uow.Categories.GetAll(), Times.Exactly(1));
				Assert.That(actual, Is.All.InstanceOf(typeof(DeckDTO)));
				Assert.AreEqual(category.Decks.Count, actual.Count);
				
			}
		}

		[Test]
		public void GetAllCoursesByCategoryTest()
		{
			var catalog = new CatalogBll(unitOfWork.Object, converter.Object);

			foreach (var category in categories)
			{
				unitOfWork.ResetCalls();
				converter.ResetCalls();

				var actual = catalog.GetAllCoursesByCategory(category.Name);

				unitOfWork.Verify(uow => uow.Categories.GetAll(), Times.Exactly(1));
				Assert.That(actual, Is.All.InstanceOf(typeof(CourseDTO)));
				Assert.AreEqual(category.Courses.Count, actual.Count);
			}
		}

		[Test]
		public void GetCourseWithDecksDTOTest()
		{
			var catalog = new CatalogBll(unitOfWork.Object, converter.Object);

			foreach (var course in courses)
			{
				unitOfWork.ResetCalls();
				converter.ResetCalls();
				var actual = catalog.GetCourseWithDecksDTO(course.Name);

				unitOfWork.Verify(uow => uow.Categories.GetAll(), Times.Exactly(1));
				Assert.That(actual, Is.All.InstanceOf(typeof(CourseWithDecksDTO)));
				//Assert.AreEqual(course.Decks.Count, actual.Decks.Count());

			}
		}
	}
}
