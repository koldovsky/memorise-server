using System.Collections.Generic;
using MemoBll.Logic;
using MemoDAL;
using MemoDAL.Entities;
using Moq;
using NUnit.Framework;

namespace Memorise.Tests.BLL.LogicTests
{
    [TestFixture]
    public class CatalogTests
    {
        private static readonly IList<Category> Categories = new List<Category>();
        private static readonly IList<Course> Courses = new List<Course>();
        private static readonly IList<Deck> Decks = new List<Deck>();

        public CatalogTests()
        {
            for (int i = 0; i < 3; i++)
            {
                Categories.Add(new Category { Id = i, Name = $"Category{i}" });
                Courses.Add(new Course { Id = i, Name = $"Course{i}" });
                Decks.Add(new Deck { Id = i, Name = $"Decks{i}" });
            }

            Courses[0].Decks.Add(Decks[0]);
            Courses[1].Decks.Add(Decks[2]);
            Courses[2].Decks.Add(Decks[0]);
            Courses[0].Decks.Add(Decks[1]);

            Categories[1].Decks.Add(Decks[0]);
            Categories[1].Decks.Add(Decks[2]);
            Categories[0].Decks.Add(Decks[0]);
            Categories[2].Decks.Add(Decks[1]);

            Categories[1].Courses.Add(Courses[0]);
            Categories[1].Courses.Add(Courses[2]);
            Categories[0].Courses.Add(Courses[0]);
            Categories[2].Courses.Add(Courses[1]);
        }

        [Test]
        public void GetAllCategoriesTest()
        {
            Mock<IUnitOfWork> unitOfWork
                = new Mock<IUnitOfWork>(MockBehavior.Strict);
            unitOfWork
                .Setup(uow => uow.Categories.GetAll())
                .Returns(Categories);
            var sut = new Catalog(unitOfWork.Object);

            var actual = sut.GetAllCategories();
            var expected = Categories;

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
                .Returns(Courses);
            var sut = new Catalog(unitOfWork.Object);

            var actual = sut.GetAllCourses();
            var expected = Courses;

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
                .Returns(Decks);
            var sut = new Catalog(unitOfWork.Object);

            var actual = sut.GetAllDecks();
            var expected = Decks;

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
                .Returns(Courses);
            var sut = new Catalog(unitOfWork.Object);

            var course = Courses[0];

            var actual = sut.GetAllDecksByCourse(course.Linking);
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
                .Returns(Categories);
            var sut = new Catalog(unitOfWork.Object);

            var category = Categories[0];

            var actual = sut.GetAllDecksByCategory(category.Linking);
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
                .Returns(Categories);
            var sut = new Catalog(unitOfWork.Object);

            var category = Categories[0];

            var actual = sut.GetAllCoursesByCategory(category.Linking);
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
                .Returns(Courses);
            var sut = new Catalog(unitOfWork.Object);

            var course = Courses[0];

            var actual = sut.GetCourse(course.Linking);
            var expected = course;

            Assert.AreEqual(expected, actual);
            unitOfWork.Verify(
                uow => uow.Courses.GetAll(), Times.Once);
        }
    }
}
