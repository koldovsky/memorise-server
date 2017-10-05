using MemoBll.Logic;
using MemoDAL;
using MemoDAL.Entities;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace Memorise.Tests.BLL.LogicTests
{
	[TestFixture]
	public class CardEditorTest
	{
		private static readonly IList<Card> Cards = new List<Card>();

		public CardEditorTest()
		{
			#region Entity Initialization and Binding

			for (int i = 0; i < 3; i++)
			{
				Cards.Add(new Card { Id = i });
			}

			#endregion
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

		//[Test]
		//public void RemoveCard()
		//{
		//	Mock<IUnitOfWork> unitOfWork
		//		= new Mock<IUnitOfWork>(MockBehavior.Strict);
		//	unitOfWork
		//		.Setup(uow => uow.Cards.Delete(It.IsAny<Card>()));

		//	var sut = new CardEditor(unitOfWork.Object);

		//	var card = Cards[0];
		//	sut.RemoveCard(card);

		//	unitOfWork.Verify(
		//		uow => uow.Cards.Delete(It.IsAny<Card>()), Times.Once);
		//}
	}
}
