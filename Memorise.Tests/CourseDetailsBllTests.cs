using MemoBll;
using MemoDAL;
using MemoDAL.Entities;
using MemoDTO;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace Memorise.Tests
{
    [TestFixture]
    class CourseDetailsBllTests
    {
        Mock<IUnitOfWork> unitOfWork;
        Mock<IConverterToDTO> converter;
        List<Deck> decks = new List<Deck>();
        Course course;

        public CourseDetailsBllTests()
        {
            unitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
            converter = new Mock<IConverterToDTO>(MockBehavior.Strict);
            decks.Add(new Deck { Id = 1, Name = "Deck1", Price = 0 });
            decks.Add(new Deck { Id = 2, Name = "Deck2", Price = 1 });
            course = new Course { Id = 1, Name = "Course1", Decks = decks };
        }

        [Test]
        public void GetAllPaidDecksTest()
        {
            // Arrange
            unitOfWork.Setup(uow => uow.Decks.GetAll()).Returns(decks);
            converter
                .Setup(c => c.ConvertToDeckListDTO(It.IsIn<List<Deck>>(decks)))
                .Returns(new List<DeckDTO>());
        }
    }
}
