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
    public class CourseDetailsBllTests
    {
        private static IList<Category> categories = new List<Category>();
        private static IList<Course> courses = new List<Course>();
        private static IList<Deck> decks = new List<Deck>();

        public CourseDetailsBllTests()
        {
            for (int i = 0; i < 3; i++)
            {
                categories.Add(new Category { Id = i, Name = $"Category{i}" });
                courses.Add(new Course { Id = i, Name = $"Course{i}" });
                decks.Add(new Deck { Id = i, Name = $"Decks{i}", Price = i });
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
        }

        [Test]
        public void GetAllPaidDecksTest()
        {
            Mock<ICourseDetails> courseDetails = new Mock<ICourseDetails>(MockBehavior.Strict);
            Mock<IConverterToDTO> converter = new Mock<IConverterToDTO>(MockBehavior.Strict);
            courseDetails
                .Setup(cd => cd.GetAllPaidDecks())
                .Returns(decks.Where(d => d.Price > 0).ToList());
            converter
                .Setup(c => c.ConvertToDeckListDTO(It.IsAny<IEnumerable<Deck>>()))
                .Returns(new List<DeckDTO>());

            var sut = new CourseDetailsBll(
                courseDetails.Object,
                converter.Object);

            var expected = decks.Where(d => d.Price > 0);
            var actual = sut.GetAllPaidDecks();

            courseDetails.Verify(
                cd => cd.GetAllPaidDecks(), Times.Once);
            converter.Verify(
                c => c.ConvertToDeckListDTO(
                    It.IsAny<IEnumerable<Deck>>()),
                Times.Once);
        }

        [Test]
        public void GetDeckPriceTest()
        {
            Mock<ICourseDetails> courseDetails = new Mock<ICourseDetails>(MockBehavior.Strict);
            courseDetails
                .Setup(cd => cd.GetDeckPrice(decks[0].Id))
                .Returns(decks[0].Price);
            var sut = new CourseDetailsBll(
                courseDetails.Object,
                null);

            var deck = decks[0];
            var expected = deck.Price;
            var actual = sut.GetDeckPrice(deck.Id);

            Assert.AreEqual(expected, actual);
            courseDetails.Verify(
                cd => cd.GetDeckPrice(deck.Id), Times.Once);
        }

        [Test]
        public void GetCourseByNameTest()
        {
            Mock<ICourseDetails> courseDetails = new Mock<ICourseDetails>(MockBehavior.Strict);
            Mock<IConverterToDTO> converter = new Mock<IConverterToDTO>(MockBehavior.Strict);

            courseDetails
                .Setup(cd => cd.GetCourseByName(courses[0].Name))
                .Returns(courses[0]);

            converter
                .Setup(c => c.ConvertToCourseDTO(It.IsIn<Course>(courses)))
                .Returns(new CourseDTO());

            var sut = new CourseDetailsBll(
                courseDetails.Object,
                converter.Object);

            var course = courses[0];
            var actual = sut.GetCourseByName(course.Name);

            courseDetails.Verify(
                cd => cd.GetCourseByName(course.Name), Times.Once);
            converter.Verify(
                c => c.ConvertToCourseDTO(
                    It.IsAny<Course>()),
                Times.Once);
        }

        [Test]
        public void GetCourseByIdTest()
        {
            Mock<ICourseDetails> courseDetails = new Mock<ICourseDetails>(MockBehavior.Strict);
            Mock<IConverterToDTO> converter = new Mock<IConverterToDTO>(MockBehavior.Strict);

            courseDetails
                .Setup(cd => cd.GetCourseById(courses[0].Id))
                .Returns(courses[0]);

            converter
                .Setup(c => c.ConvertToCourseDTO(It.IsIn<Course>(courses)))
                .Returns(new CourseDTO());
            var sut = new CourseDetailsBll(
                courseDetails.Object,
                converter.Object);

            var course = courses[0];
            var actual = sut.GetCourseById(course.Id);

            courseDetails.Verify(
                cd => cd.GetCourseById(course.Id), Times.Once);
            converter.Verify(
                c => c.ConvertToCourseDTO(
                    It.IsAny<Course>()),
                Times.Once);
        }
    }
}
