using System;
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
    public class QuizBllTests
    {
        private Mock<IQuiz> mockQuiz = new Mock<IQuiz>(MockBehavior.Strict);
        private Mock<IConverterToDto> mockConverter = new Mock<IConverterToDto>(MockBehavior.Strict);
        private List<Deck> decks = new List<Deck>();
        private List<Card> cards = new List<Card>();
        private List<Answer> answers = new List<Answer>();
        private List<AnswerDTO> answerDTOs = new List<AnswerDTO>();
        private List<CardDTO> cardDTOs = new List<CardDTO>();
        private QuizBll quiz;

        public QuizBllTests()
        {
            this.answers.Add(new Answer { Id = 1, Text = "a", IsCorrect = true });
            this.answers.Add(new Answer { Id = 2, Text = "b", IsCorrect = false });
            this.answers.Add(new Answer { Id = 3, Text = "c", IsCorrect = false });
            this.answers.Add(new Answer { Id = 4, Text = "d", IsCorrect = true });

            this.answerDTOs.Add(new AnswerDTO { Id = 1, Text = "a", IsCorrect = true });
            this.answerDTOs.Add(new AnswerDTO { Id = 2, Text = "b", IsCorrect = false });
            this.answerDTOs.Add(new AnswerDTO { Id = 3, Text = "c", IsCorrect = false });
            this.answerDTOs.Add(new AnswerDTO { Id = 4, Text = "d", IsCorrect = true });

            this.cards.Add(new Card { Id = 1, Answers = this.answers });
            this.cards.Add(new Card { Id = 2, Answers = this.answers });

            this.cardDTOs.Add(new CardDTO { Id = 1, Answers = this.answerDTOs });
            this.cardDTOs.Add(new CardDTO { Id = 2, Answers = this.answerDTOs });

            this.decks.Add(new Deck { Id = 1, Cards = this.cards, Name = "Dodo" });
        }

        [Test]
        public void GetAllAnswersInCardBllTest()
        {
            // Arrange
            int cardId = this.cards[0].Id;
            this.mockQuiz.Setup(
                m => m.GetAllAnswersInCard(It.IsInRange<int>(1, 4, Range.Inclusive)))
                .Returns(this.answers);
            this.mockConverter
                .Setup(m => m.ConvertToAnswerListDto(this.answers))
                .Returns(this.answerDTOs);
            this.quiz = new QuizBll(this.mockQuiz.Object, this.mockConverter.Object);
            int expectedLength = this.answers.Count;
            int expectedfirstId = this.answers[0].Id;
            int expectedLastId = this.answers[3].Id;

            // Act
            int actualLength = this.quiz.GetAllAnswersInCard(cardId).ToList().Count();
            int actualfirstId = this.quiz.GetAllAnswersInCard(cardId).ToList()[0].Id;
            int actualLastId = this.quiz.GetAllAnswersInCard(cardId).ToList()[3].Id;

            // Assert
            Assert.AreEqual(expectedLength, actualLength);
            Assert.AreEqual(expectedfirstId, actualfirstId);
            Assert.AreEqual(expectedLastId, actualLastId);
        }

        [Test]
        public void GetAllAnswersInCardBllArgumentNullExceptionTest()
        {
            // Arrange
            List<Answer> nullAnswers = null;
            int cargId = 0;
            this.mockQuiz.Setup(m => m.GetAllAnswersInCard(cargId)).Returns(nullAnswers);
            this.mockConverter.Setup(m => m.ConvertToAnswerListDto(this.answers)).Returns(this.answerDTOs);
            this.quiz = new QuizBll(this.mockQuiz.Object, this.mockConverter.Object);

            // act, accert
            Assert.Throws<ArgumentNullException>(
                () => this.quiz.GetAllAnswersInCard(cargId));
        }

        [Test]
        public void GetCardsByDeckBllTest()
        {
            // Arrange
            string deckName = this.decks[0].Name;
            List<Card> expected = this.cards;
            this.mockQuiz.Setup(m => m.GetCardsByDeck(deckName)).Returns(this.cards);
            this.mockConverter.Setup(m => m.ConvertToCardListDto(this.cards)).Returns(this.cardDTOs);
            this.quiz = new QuizBll(this.mockQuiz.Object, this.mockConverter.Object);
            int expectedLength = this.cards.Count;
            int expectedfirstId = this.cards[0].Id;
            int expectedLastId = this.cards[1].Id;

            // Act
            int actualLength = this.quiz.GetCardsByDeck(deckName).ToList().Count();
            int actualfirstId = this.quiz.GetCardsByDeck(deckName).ToList()[0].Id;
            int actualLastId = this.quiz.GetCardsByDeck(deckName).ToList()[1].Id;

            // Assert
            Assert.AreEqual(expectedLength, actualLength);
            Assert.AreEqual(expectedfirstId, actualfirstId);
            Assert.AreEqual(expectedLastId, actualLastId);
        }
    }
}
