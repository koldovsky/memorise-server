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
    public class QuizLogicTests
    {
        private Mock<IUnitOfWork> unitOfWork;
        private List<Deck> decks = new List<Deck>();
        private List<Card> cards = new List<Card>();
        private List<Answer> answers = new List<Answer>();
        private Quiz quiz;

        public QuizLogicTests()
        {
            this.answers.Add(new Answer { Id = 1, Text = "a", IsCorrect = true });
            this.answers.Add(new Answer { Id = 2, Text = "b", IsCorrect = false });
            this.answers.Add(new Answer { Id = 3, Text = "c", IsCorrect = false });
            this.answers.Add(new Answer { Id = 4, Text = "d", IsCorrect = true });

            this.cards.Add(new Card { Id = 1, Answers = this.answers });

            this.decks.Add(new Deck { Id = 1, Cards = this.cards });
        }

        [Test]
        public void GetAllAnswersInCardTest()
        {
            // Arrange
            var cardId = this.cards[0].Id;
            var expected = this.answers;
            this.unitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
            this.unitOfWork.Setup(uow => uow.Cards.Get(cardId)).Returns(this.cards[0]);
            this.quiz = new Quiz(this.unitOfWork.Object);

            // Act
            var actual = this.quiz.GetAllAnswersInCard(cardId);

            // Assert
            Assert.AreEqual(expected, actual);
            this.unitOfWork.Verify(uow => uow.Cards.Get(cardId), Times.Once);
        }

        // [Test]
        public void GetAllAnswersInCardNullTest()
        {
            // Arrange
            int cardId = 0;
            Card nullCard = null;
            this.unitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
            this.unitOfWork.Setup(uow => uow.Cards.Get(cardId)).Returns(nullCard);
            this.quiz = new Quiz(this.unitOfWork.Object);

            // Act

            // Assert
            Assert.IsNull(this.quiz.GetAllAnswersInCard(cardId));
        }

        [Test]
        public void GetCardsByDeckTest()
        {
            // Arrange
            string deckName = this.decks[0].Name;
            var expected = this.cards;
            this.unitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
            this.unitOfWork.Setup(uow => uow.Decks.GetAll()).Returns(this.decks);
            this.quiz = new Quiz(this.unitOfWork.Object);

            // Act
            var actual = this.quiz.GetCardsByDeck(deckName);

            // Assert
            Assert.AreEqual(expected, actual);
            this.unitOfWork.Verify(uow => uow.Decks.GetAll(), Times.Once);
        }

        [Test]
        public void GetCardsByDeckNullTest()
        {
            // Arrange
            string deckName = "unknown";
            this.unitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
            this.unitOfWork.Setup(uow => uow.Decks.GetAll()).Returns(this.decks);
            this.quiz = new Quiz(this.unitOfWork.Object);

            // Act

            // Assert
            Assert.IsNull(this.quiz.GetCardsByDeck(deckName));
        }
    }
}
