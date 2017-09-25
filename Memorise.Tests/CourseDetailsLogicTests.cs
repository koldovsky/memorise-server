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
        private List<Deck> decks = new List<Deck>();
        private List<Course> courses = new List<Course>();

        public CourseDetailsLogicTests()
        {
            unitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);

            decks.Add(new Deck { Id = 1, Name = "Deck1", Price = 0 });
            decks.Add(new Deck { Id = 2, Name = "Deck2", Price = 0 });
            decks.Add(new Deck { Id = 3, Name = "Deck3", Price = 1 });
            decks.Add(new Deck { Id = 4, Name = "Deck4", Price = 2 });

            courses.Add(new Course { Id = 1, Name = "Course1", Decks = decks });
            courses.Add(new Course { Id = 2, Name = "Course2", Decks = decks });
        }

        [Test]
        public void GetAllPaidDecksTest()
        {
            // Arrange
            List<Deck> expected = new List<Deck>();
            expected.Add(decks[2]);
            expected.Add(decks[3]);
            unitOfWork.Setup(uow => uow.Decks.GetAll()).Returns(decks);
            CourseDetails courseDetails = new CourseDetails(unitOfWork.Object);

            // Act
            var actual = courseDetails.GetAllPaidDecks();

            // Assert
            Assert.AreEqual(expected, actual);
            unitOfWork.Verify(uow => uow.Decks.GetAll(), Times.Once);
        }

        [Test]
        public void GetAllFreeDecks()
        {
            
        }
    }
}
