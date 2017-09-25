using System;
using System.Collections.Generic;
using MemoDAL;
using NUnit.Framework;
using MemoDAL.Entities;
using Moq;
using MemoBll;

namespace Memorise.Tests
{
    [TestFixture]
    class CourseDetailsLogicTests
    {
        private Mock<IUnitOfWork> unitOfWork;
        private CourseDetails courseDetails;
        private List<Deck> freeDecks = new List<Deck>();
        private List<Deck> paidDecks = new List<Deck>();
        private List<Deck> allDecks = new List<Deck>();
        private List<Course> courses = new List<Course>();

        public CourseDetailsLogicTests()
        {
            unitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);

            freeDecks.Add(new Deck { Id = 1, Name = "Deck1", Price = 0 });
            freeDecks.Add(new Deck { Id = 2, Name = "Deck2", Price = 0 });

            paidDecks.Add(new Deck { Id = 3, Name = "Deck3", Price = 1 });
            paidDecks.Add(new Deck { Id = 4, Name = "Deck4", Price = 2 });

            allDecks.AddRange(freeDecks);
            allDecks.AddRange(paidDecks);

            courses.Add(new Course { Id = 1, Name = "Course1", Decks = freeDecks });
            courses.Add(new Course { Id = 2, Name = "Course2", Decks = freeDecks });
        }
        
        public void GetAllPaidDecksTest()
        {
            // Arrange
            var expected = paidDecks;
            unitOfWork.Setup(uow => uow.Decks.GetAll()).Returns(allDecks);
            courseDetails = new CourseDetails(unitOfWork.Object);

            // Act
            var actual = courseDetails.GetAllPaidDecks();

            // Assert
            Assert.AreEqual(expected, actual);
            unitOfWork.Verify(uow => uow.Decks.GetAll(), Times.Once);
        }

        [Test]
        public void GetAllFreeDecksTest()
        {
            // Arrange
            courseDetails = new CourseDetails(unitOfWork.Object);

            // Act

            // Assert
            Assert.Throws<NotImplementedException>(
                () => courseDetails.GetAllFreeDecks(DateTime.Now));
        }

        [TestCase(1)]
        [TestCase(3)]
        public void GetDeckPriceTest(int deckId)
        {
            // Arrange
            var expected = allDecks[deckId].Price;
            unitOfWork.Setup(uow => uow.Decks.Get(deckId))
                .Returns(allDecks[deckId]);
            courseDetails = new CourseDetails(unitOfWork.Object);

            // Act
            var actual = courseDetails.GetDeckPrice(deckId);

            // Assert
            Assert.AreEqual(expected, actual);
            unitOfWork.Verify(uow => uow.Decks.Get(deckId), Times.Once);
        }

        [Test]
        public void GetDeckPriceExceptionTest()
        {
            // Arrange
            int deckId = 0;
            Deck deck = null;
            unitOfWork.Setup(uow => uow.Decks.Get(deckId)).Returns(deck);
            courseDetails = new CourseDetails(unitOfWork.Object);

            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(
                () => courseDetails.GetDeckPrice(deckId));
        }

        [Test]
        public void GetAllNewDecksTest()
        {
            // Arrange
            courseDetails = new CourseDetails(unitOfWork.Object);

            // Act

            // Assert
            Assert.Throws<NotImplementedException>(
                () => courseDetails.GetAllNewDecks(DateTime.Now));
        }

        [Test]
        public void GetCourseByNameTest()
        {
            // Arrange
            var expected = courses[0];
            unitOfWork.Setup(uow => uow.Courses.GetAll()).Returns(courses);
            courseDetails = new CourseDetails(unitOfWork.Object);

            // Act
            var actual = courseDetails.GetCourseByName(courses[0].Name);

            // Assert
            Assert.AreEqual(expected, actual);
            unitOfWork.Verify(uow => uow.Courses.GetAll(), Times.Once);
        }

        [Test]
        public void GetCourseByIdTest()
        {
            // Arrange
            int id = courses[0].Id;
            var expected = courses[0];
            unitOfWork.Setup(uow => uow.Courses.Get(id)).Returns(courses[0]);
            courseDetails = new CourseDetails(unitOfWork.Object);

            // Act
            var actual = courseDetails.GetCourseById(id);

            // Assert
            Assert.AreEqual(expected, actual);
            unitOfWork.Verify(uow => uow.Courses.Get(id), Times.Once);
        }
    }
}
