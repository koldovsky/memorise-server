using System;
using System.Collections.Generic;
using MemoBll.Logic;
using MemoDAL;
using MemoDAL.Entities;
using Moq;
using NUnit.Framework;

namespace Memorise.Tests.BLL.LogicTests
{
    [TestFixture]
    class CourseDetailsLogicTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWork;
        private CourseDetails _courseDetails;
        private readonly List<Deck> _freeDecks = new List<Deck>();
        private readonly List<Deck> _paidDecks = new List<Deck>();
        private readonly List<Deck> _allDecks = new List<Deck>();
        private readonly List<Course> _courses = new List<Course>();

        public CourseDetailsLogicTests()
        {
            _unitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);

            _freeDecks.Add(new Deck { Id = 1, Name = "Deck1", Price = 0 });
            _freeDecks.Add(new Deck { Id = 2, Name = "Deck2", Price = 0 });

            _paidDecks.Add(new Deck { Id = 3, Name = "Deck3", Price = 1 });
            _paidDecks.Add(new Deck { Id = 4, Name = "Deck4", Price = 2 });

            _allDecks.AddRange(_freeDecks);
            _allDecks.AddRange(_paidDecks);

            _courses.Add(new Course { Id = 1, Name = "Course1", Decks = _freeDecks });
            _courses.Add(new Course { Id = 2, Name = "Course2", Decks = _freeDecks });
        }
        
        [Test]
        public void GetAllPaidDecksTest()
        {
            // Arrange
            var expected = _paidDecks;
            _unitOfWork.Setup(uow => uow.Decks.GetAll()).Returns(_allDecks);
            _courseDetails = new CourseDetails(_unitOfWork.Object);

            // Act
            var actual = _courseDetails.GetAllPaidDecks();

            // Assert
            Assert.AreEqual(expected, actual);
            _unitOfWork.Verify(uow => uow.Decks.GetAll(), Times.Once);
        }

        [Test]
        public void GetAllFreeDecksTest()
        {
            // Arrange
            _courseDetails = new CourseDetails(_unitOfWork.Object);

            // Act

            // Assert
            Assert.Throws<NotImplementedException>(
                () => _courseDetails.GetAllFreeDecks(DateTime.Now));
        }

        [TestCase(1)]
        [TestCase(3)]
        public void GetDeckPriceTest(int deckId)
        {
            // Arrange
            var expected = _allDecks[deckId].Price;
            _unitOfWork.Setup(uow => uow.Decks.Get(deckId))
                .Returns(_allDecks[deckId]);
            _courseDetails = new CourseDetails(_unitOfWork.Object);

            // Act
            var actual = _courseDetails.GetDeckPrice(deckId);

            // Assert
            Assert.AreEqual(expected, actual);
            _unitOfWork.Verify(uow => uow.Decks.Get(deckId), Times.Once);
        }

        [Test]
        public void GetDeckPriceExceptionTest()
        {
            // Arrange
            int deckId = 0;
            Deck deck = null;
            _unitOfWork.Setup(uow => uow.Decks.Get(deckId)).Returns(deck);
            _courseDetails = new CourseDetails(_unitOfWork.Object);

            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(
                () => _courseDetails.GetDeckPrice(deckId));
        }

        [Test]
        public void GetAllNewDecksTest()
        {
            // Arrange
            _courseDetails = new CourseDetails(_unitOfWork.Object);

            // Act

            // Assert
            Assert.Throws<NotImplementedException>(
                () => _courseDetails.GetAllNewDecks(DateTime.Now));
        }

        [Test]
        public void GetCourseByNameTest()
        {
            // Arrange
            var expected = _courses[0];
            _unitOfWork.Setup(uow => uow.Courses.GetAll()).Returns(_courses);
            _courseDetails = new CourseDetails(_unitOfWork.Object);

            // Act
            var actual = _courseDetails.GetCourseByName(_courses[0].Name);

            // Assert
            Assert.AreEqual(expected, actual);
            _unitOfWork.Verify(uow => uow.Courses.GetAll(), Times.Once);
        }

        [Test]
        public void GetCourseByIdTest()
        {
            // Arrange
            int id = _courses[0].Id;
            var expected = _courses[0];
            _unitOfWork.Setup(uow => uow.Courses.Get(id)).Returns(_courses[0]);
            _courseDetails = new CourseDetails(_unitOfWork.Object);

            // Act
            var actual = _courseDetails.GetCourseById(id);

            // Assert
            Assert.AreEqual(expected, actual);
            _unitOfWork.Verify(uow => uow.Courses.Get(id), Times.Once);
        }
    }
}
