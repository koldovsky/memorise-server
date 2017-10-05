using System.Collections.Generic;
using System.Linq;
using MemoBll.Interfaces;
using MemoBll.Managers;
using MemoDAL.Entities;
using MemoDTO;
using Moq;
using NUnit.Framework;
using MemoDAL;
using MemoBll.Logic;
using System;

namespace Memorise.Tests.BLL.ManagersTests
{
    [TestFixture]
    class QuizBllTests
    {
        Mock<IQuiz> mockQuiz = new Mock<IQuiz>(MockBehavior.Strict);
        Mock<IConverterToDTO> mockConverter = new Mock<IConverterToDTO>(MockBehavior.Strict);
        List<Deck> decks = new List<Deck>();
        List<Card> cards = new List<Card>();
        List<Answer> answers = new List<Answer>();
        List<AnswerDTO> answerDTOs = new List<AnswerDTO>();
        List<CardDTO> cardDTOs = new List<CardDTO>();
        QuizBll quiz;

        public QuizBllTests()
        {
            answers.Add(new Answer { Id = 1, Text = "a", IsCorrect = true });
            answers.Add(new Answer { Id = 2, Text = "b", IsCorrect = false });
            answers.Add(new Answer { Id = 3, Text = "c", IsCorrect = false });
            answers.Add(new Answer { Id = 4, Text = "d", IsCorrect = true });

            answerDTOs.Add(new AnswerDTO { Id = 1, Text = "a", IsCorrect = true });
            answerDTOs.Add(new AnswerDTO { Id = 2, Text = "b", IsCorrect = false });
            answerDTOs.Add(new AnswerDTO { Id = 3, Text = "c", IsCorrect = false });
            answerDTOs.Add(new AnswerDTO { Id = 4, Text = "d", IsCorrect = true });

            cards.Add(new Card { Id = 1, Answers = answers });
            cards.Add(new Card { Id = 2, Answers = answers });

            cardDTOs.Add(new CardDTO { Id = 1, Answers = answerDTOs });
            cardDTOs.Add(new CardDTO { Id = 2, Answers = answerDTOs });

            decks.Add(new Deck { Id = 1, Cards = cards, Name = "Dodo" });
        }

        [Test]
        public void GetAllAnswersInCardBllTest()
        {
            // Arrange
            int cardId = cards[0].Id;
            mockQuiz.Setup(m => m.GetAllAnswersInCard(It.IsInRange<int>(1, 4,
                Range.Inclusive))).Returns(answers);
            mockConverter.Setup(m => m.ConvertToAnswerListDTO(answers)).Returns(answerDTOs);
            quiz = new QuizBll(mockQuiz.Object, mockConverter.Object);
            int expectedLength = answers.Count;
            int expectedfirstId = answers[0].Id;
            int expectedLastId = answers[3].Id;

            // Act
            int actualLength = quiz.GetAllAnswersInCard(cardId).ToList().Count();
            int actualfirstId = quiz.GetAllAnswersInCard(cardId).ToList()[0].Id;
            int actualLastId = quiz.GetAllAnswersInCard(cardId).ToList()[3].Id;

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
            mockQuiz.Setup(m => m.GetAllAnswersInCard(cargId)).Returns(nullAnswers);
            mockConverter.Setup(m => m.ConvertToAnswerListDTO(answers)).Returns(answerDTOs);
            quiz = new QuizBll(mockQuiz.Object, mockConverter.Object);

            //act, accert
            Assert.Throws<ArgumentNullException>(
                () => quiz.GetAllAnswersInCard(cargId));
        }
        

        [Test]
        public void GetCardsByDeckBllTest()
        {
            // Arrange
            string deckName = decks[0].Name;
            List<Card> expected = cards;
            mockQuiz.Setup(m => m.GetCardsByDeck(deckName)).Returns(cards);
            mockConverter.Setup(m => m.ConvertToCardListDTO(cards)).Returns(cardDTOs);
            quiz = new QuizBll(mockQuiz.Object, mockConverter.Object);
            int expectedLength = cards.Count;
            int expectedfirstId = cards[0].Id;
            int expectedLastId = cards[1].Id;

            // Act
            int actualLength = quiz.GetCardsByDeck(deckName).ToList().Count();
            int actualfirstId = quiz.GetCardsByDeck(deckName).ToList()[0].Id;
            int actualLastId = quiz.GetCardsByDeck(deckName).ToList()[1].Id;

            // Assert
            Assert.AreEqual(expectedLength, actualLength);
            Assert.AreEqual(expectedfirstId, actualfirstId);
            Assert.AreEqual(expectedLastId, actualLastId);
        }
    }
}
