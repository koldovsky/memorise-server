using MemoDAL;
using MemoDAL.EF;
using MemoDAL.Entities;

namespace MemoBll.Logic
{
	public class CardEditor
    {
        private IUnitOfWork unitOfWork;

        public CardEditor()
        {
            this.unitOfWork = new UnitOfWork(new MemoContext());
        }

        public CardEditor(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void CreateCard(Card card)
        {
            unitOfWork.Cards.Create(card);
        }

        public void UpdateCard(Card card)
        {
            unitOfWork.Cards.Update(card);
        }

        public void RemoveCard(int cardId)
        {
            unitOfWork.Cards.Delete(cardId);
        }
    }
}
