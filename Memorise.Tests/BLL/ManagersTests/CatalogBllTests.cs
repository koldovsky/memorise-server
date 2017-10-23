using System.Collections.Generic;
using System.Linq;
using MemoBll.Interfaces;
using MemoBll.Managers;
using MemoDAL.Entities;
using MemoDTO;
using Moq;
using NUnit.Framework;

namespace Memorise.Tests.BLL.ManagersTests
{
    [TestFixture]
    public class CatalogBllTests
    {
        private static IList<Category> categories = new List<Category>();
        private static IList<Course> courses = new List<Course>();
        private static IList<Deck> decks = new List<Deck>();
        private Mock<ICatalog> catalog = new Mock<ICatalog>(MockBehavior.Strict);
        private Mock<IConverterToDto> converter = new Mock<IConverterToDto>(MockBehavior.Strict);

        public CatalogBllTests()
        {
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

            this.catalog.Setup(cat => cat.GetAllCategories()).Returns(categories);
            this.catalog.Setup(cat => cat.GetAllDecks()).Returns(decks);
            this.catalog
                .Setup(cat => cat.GetAllDecksByCourse(It.IsIn(courses.Select(c => c.Name))))
                .Returns(decks);
            this.catalog
                .Setup(cat => cat.GetAllDecksByCategory(It.IsIn(categories.Select(c => c.Name))))
                .Returns(decks);
            this.catalog.Setup(cat => cat.GetAllCourses()).Returns(courses);
            this.catalog
                .Setup(cat => cat.GetAllCoursesByCategory(It.IsIn(categories.Select(c => c.Name))))
                .Returns(courses);
            this.catalog
                .Setup(cat => cat.GetCourse(It.IsIn(courses.Select(c => c.Name))))
                .Returns(courses[0]);

            this.converter
                .Setup(c => c.ConvertToCategoryDto(It.IsIn<Category>(categories)))
                .Returns(new CategoryDTO());
            this.converter
                .Setup(c => c.ConvertToDeckDto(It.IsIn<Deck>(decks)))
                .Returns(new DeckDTO());
            this.converter
                .Setup(c => c.ConvertToCourseDto(It.IsIn<Course>(courses)))
                .Returns(new CourseDTO());
            this.converter
                .Setup(c => c.ConvertToCourseWithDecksDto(It.IsIn<Course>(courses)))
                .Returns(new CourseWithDecksDTO());
        }

        [Test]
        public void GetAllCategoriesTest()
        {
            var sut = new CatalogBll(this.catalog.Object, this.converter.Object);

            var actual = sut.GetAllCategories();

            this.catalog.Verify(
                cat => cat.GetAllCategories(),
                Times.Exactly(1));

            Assert.That(actual, Is.All.InstanceOf(typeof(CategoryDTO)));
            Assert.AreEqual(categories.Count, actual.Count());
        }

        [Test]
        public void GetAllDecksTest()
        {
            var sut = new CatalogBll(this.catalog.Object, this.converter.Object);

            var actual = sut.GetAllDecks();

            this.catalog.Verify(
                cat => cat.GetAllDecks(),
                Times.Exactly(1));
            Assert.That(actual, Is.All.InstanceOf(typeof(DeckDTO)));
            Assert.AreEqual(decks.Count, actual.Count());
        }

        [Test]
        public void GetAllCoursesTest()
        {
            var sut = new CatalogBll(this.catalog.Object, this.converter.Object);

            var actual = sut.GetAllCourses();

            this.catalog.Verify(
                cat => cat.GetAllCourses(),
                Times.AtLeastOnce());
            Assert.That(actual, Is.All.InstanceOf(typeof(CourseDTO)));
            Assert.AreEqual(courses.Count, actual.Count());
        }

        [Test]
        public void GetAllDecksByCourseTest()
        {
            var sut = new CatalogBll(this.catalog.Object, this.converter.Object);

            foreach (var course in courses)
            {
                var actual = sut.GetAllDecksByCourse(course.Name);
                this.catalog.Verify(
                    cat => cat.GetAllDecksByCourse(course.Name),
                    Times.AtLeastOnce());
                Assert.That(actual, Is.All.InstanceOf(typeof(DeckDTO)));
            }
        }

        [Test]
        public void GetAllDecksByCategoryTest()
        {
            var sut = new CatalogBll(this.catalog.Object, this.converter.Object);

            foreach (var category in categories)
            {
                var actual = sut.GetAllDecksByCategory(category.Name);

                this.catalog.Verify(
                    cat => cat.GetAllDecksByCategory(category.Name),
                    Times.AtLeastOnce());

                Assert.That(actual, Is.All.InstanceOf(typeof(DeckDTO)));
            }
        }

        [Test]
        public void GetAllCoursesByCategoryTest()
        {
            var sut = new CatalogBll(this.catalog.Object, this.converter.Object);

            foreach (var category in categories)
            {
                var actual = sut.GetAllCoursesByCategory(category.Name);

                this.catalog.Verify(
                    cat => cat.GetAllCoursesByCategory(category.Name),
                    Times.AtLeastOnce());
                Assert.That(actual, Is.All.InstanceOf(typeof(CourseDTO)));
            }
        }

        [Test]
        public void GetCourseWithDecksDTOTest()
        {
            var sut = new CatalogBll(this.catalog.Object, this.converter.Object);
            foreach (var course in courses)
            {
                var actual = sut.GetCourseWithDecksDTO(course.Name);

                this.catalog.Verify(cat => cat.GetCourse(course.Name), Times.AtLeastOnce());
                this.converter.Verify(
                    conv => conv.ConvertToCourseWithDecksDto(It.IsAny<Course>()),
                    Times.AtLeastOnce());
                Assert.That(actual, Is.InstanceOf(typeof(CourseWithDecksDTO)));
            }
        }
    }
}
