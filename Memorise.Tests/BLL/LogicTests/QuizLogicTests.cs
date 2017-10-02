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
    class QuizLogicTests
    {
        Mock<IUnitOfWork> unitOfWork;
        List<Deck> decks = new List<Deck>();
        List<Card> cards = new List<Card>();
        List<Answer> answers = new List<Answer>();
        Quiz quiz;

        public QuizLogicTests()
        {
            answers.Add(new Answer { Id = 1, Text = "a", IsCorrect = true});
            answers.Add(new Answer { Id = 2, Text = "b", IsCorrect = false});
            answers.Add(new Answer { Id = 3, Text = "c", IsCorrect = false });
            answers.Add(new Answer { Id = 4, Text = "d", IsCorrect = true });

            cards.Add(new Card { Id = 1, Answers = answers});

            decks.Add(new Deck { Id = 1, Cards = cards });
        }

        [Test]
        public void CheckAnswerTest()
        {
            // Arrange
            unitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
            quiz = new Quiz(unitOfWork.Object);

            // Act

            // Assert
            Assert.Throws<NotImplementedException>(
                () => quiz.CheckAnswer(answers[0], cards[0].Id));
        }

        [Test]
        public void GetAllAnswersInCardTest()
        {
            // Arrange
            var cardId = cards[0].Id;
            var expected = answers;
            unitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
            unitOfWork.Setup(uow => uow.Cards.Get(cardId)).Returns(cards[0]);
            quiz = new Quiz(unitOfWork.Object);

            // Act
            var actual = quiz.GetAllAnswersInCard(cardId);

            // Assert
            Assert.AreEqual(expected, actual);
            unitOfWork.Verify(uow => uow.Cards.Get(cardId), Times.Once);
        }

        [Test]
        public void GetAllAnswersInCardNullTest()
        {
            // Arrange
            int cardId = 0;
            Card nullCard = null;
            unitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
            unitOfWork.Setup(uow => uow.Cards.Get(cardId)).Returns(nullCard);
            quiz = new Quiz(unitOfWork.Object);

            // Act

            // Assert
            Assert.IsNull(quiz.GetAllAnswersInCard(cardId));
        }

        [Test]
        public void GetCardsByDeckTest()
        {
            // Arrange
            string deckName = decks[0].Name;
            var expected = cards;
            unitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
            unitOfWork.Setup(uow => uow.Decks.GetAll()).Returns(decks);
            quiz = new Quiz(unitOfWork.Object);

            // Act
            var actual = quiz.GetCardsByDeck(deckName);

            // Assert
            Assert.AreEqual(expected, actual);
            unitOfWork.Verify(uow => uow.Decks.GetAll(), Times.Once);
        }

        [Test]
        public void GetCardsByDeckNullTest()
        {
            // Arrange
            string deckName = "unknown";
            unitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
            unitOfWork.Setup(uow => uow.Decks.GetAll()).Returns(decks);
            quiz = new Quiz(unitOfWork.Object);

            // Act

            // Assert
            Assert.IsNull(quiz.GetCardsByDeck(deckName));
        }
    }
}
