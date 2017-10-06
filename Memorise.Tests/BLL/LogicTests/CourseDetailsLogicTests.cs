using System;
using System.Collections.Generic;
using MemoBll;
using MemoBll.Logic;
using MemoDAL;
using MemoDAL.Entities;
using Moq;
using NUnit.Framework;

namespace Memorise.Tests.BLL.LogicTests
{
    [TestFixture]
    public class CourseDetailsLogicTests
    {
        private readonly Mock<IUnitOfWork> unitOfWork;
        private readonly List<Deck> freeDecks = new List<Deck>();
        private readonly List<Deck> paidDecks = new List<Deck>();
        private readonly List<Deck> allDecks = new List<Deck>();
        private readonly List<Course> courses = new List<Course>();
        private CourseDetails courseDetails;

        public CourseDetailsLogicTests()
        {
            this.unitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);

            this.freeDecks.Add(new Deck { Id = 1, Name = "Deck1", Price = 0 });
            this.freeDecks.Add(new Deck { Id = 2, Name = "Deck2", Price = 0 });

            this.paidDecks.Add(new Deck { Id = 3, Name = "Deck3", Price = 1 });
            this.paidDecks.Add(new Deck { Id = 4, Name = "Deck4", Price = 2 });

            this.allDecks.AddRange(this.freeDecks);
            this.allDecks.AddRange(this.paidDecks);

            this.courses.Add(new Course { Id = 1, Name = "Course1", Decks = this.freeDecks });
            this.courses.Add(new Course { Id = 2, Name = "Course2", Decks = this.freeDecks });
        }
        
        [Test]
        public void GetAllPaidDecksTest()
        {
            // Arrange
            var expected = this.paidDecks;
            this.unitOfWork.Setup(uow => uow.Decks.GetAll()).Returns(this.allDecks);
            this.courseDetails = new CourseDetails(this.unitOfWork.Object);

            // Act
            var actual = this.courseDetails.GetAllPaidDecks();

            // Assert
            Assert.AreEqual(expected, actual);
            this.unitOfWork.Verify(uow => uow.Decks.GetAll(), Times.Once);
        }

        [Test]
        public void GetAllFreeDecksTest()
        {
            // Arrange
            this.courseDetails = new CourseDetails(this.unitOfWork.Object);

            // Act

            // Assert
            Assert.Throws<NotImplementedException>(
                () => this.courseDetails.GetAllFreeDecks(DateTime.Now));
        }

        [TestCase(1)]
        [TestCase(3)]
        public void GetDeckPriceTest(int deckId)
        {
            // Arrange
            var expected = this.allDecks[deckId].Price;
            this.unitOfWork.Setup(uow => uow.Decks.Get(deckId))
                .Returns(this.allDecks[deckId]);
            this.courseDetails = new CourseDetails(this.unitOfWork.Object);

            // Act
            var actual = this.courseDetails.GetDeckPrice(deckId);

            // Assert
            Assert.AreEqual(expected, actual);
            this.unitOfWork.Verify(uow => uow.Decks.Get(deckId), Times.Once);
        }

        [Test]
        public void GetDeckPriceExceptionTest()
        {
            // Arrange
            int deckId = 0;
            Deck deck = null;
            this.unitOfWork.Setup(uow => uow.Decks.Get(deckId)).Returns(deck);
            this.courseDetails = new CourseDetails(this.unitOfWork.Object);

            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(
                () => this.courseDetails.GetDeckPrice(deckId));
        }

        [Test]
        public void GetAllNewDecksTest()
        {
            // Arrange
            this.courseDetails = new CourseDetails(this.unitOfWork.Object);

            // Act

            // Assert
            Assert.Throws<NotImplementedException>(
                () => this.courseDetails.GetAllNewDecks(DateTime.Now));
        }

        [Test]
        public void GetCourseByNameTest()
        {
            // Arrange
            var expected = this.courses[0];
            this.unitOfWork.Setup(uow => uow.Courses.GetAll()).Returns(this.courses);
            this.courseDetails = new CourseDetails(this.unitOfWork.Object);

            // Act
            var actual = this.courseDetails.GetCourseByName(this.courses[0].Name);

            // Assert
            Assert.AreEqual(expected, actual);
            this.unitOfWork.Verify(uow => uow.Courses.GetAll(), Times.Once);
        }

        [Test]
        public void GetCourseByIdTest()
        {
            // Arrange
            int id = this.courses[0].Id;
            var expected = this.courses[0];
            this.unitOfWork.Setup(uow => uow.Courses.Get(id)).Returns(this.courses[0]);
            this.courseDetails = new CourseDetails(this.unitOfWork.Object);

            // Act
            var actual = this.courseDetails.GetCourseById(id);

            // Assert
            Assert.AreEqual(expected, actual);
            this.unitOfWork.Verify(uow => uow.Courses.Get(id), Times.Once);
        }
    }
}
