using System.Collections.Generic;
using MemoBll.Logic;
using MemoDAL;
using MemoDAL.Entities;
using Moq;
using NUnit.Framework;

namespace Memorise.Tests.BLL.LogicTests
{
    [TestFixture]
    public class CardEditorTest
    {
        private static readonly IList<Card> Cards = new List<Card>();

        public CardEditorTest()
        {
            for (int i = 0; i < 3; i++)
            {
                Cards.Add(new Card { Id = i });
            }
        }

        [Test]
        public void CreateCard()
        {
            Mock<IUnitOfWork> unitOfWork
                = new Mock<IUnitOfWork>(MockBehavior.Strict);
            unitOfWork
                .Setup(uow => uow.Cards.Create(It.IsAny<Card>()));

            var sut = new CardEditor(unitOfWork.Object);

            var card = Cards[0];
            sut.CreateCard(card);

            unitOfWork.Verify(
                uow => uow.Cards.Create(It.IsAny<Card>()), Times.Once);
        }

        [Test]
        public void UpdateCard()
        {
            Mock<IUnitOfWork> unitOfWork
                = new Mock<IUnitOfWork>(MockBehavior.Strict);
            unitOfWork
                .Setup(uow => uow.Cards.Update(It.IsAny<Card>()));

            var sut = new CardEditor(unitOfWork.Object);

            var card = Cards[0];
            sut.UpdateCard(card);

            unitOfWork.Verify(
                uow => uow.Cards.Update(It.IsAny<Card>()), Times.Once);
        }
    }
}
