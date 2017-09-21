using MemoDAL;
using MemoDAL.Entities;
using MemoDAL.EF;

namespace MemoBll
{
    class CardEditor
    {
        IUnitOfWork unitOfWork;

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

        public void RemoveCard(Card card)
        {
            unitOfWork.Cards.Delete(card);
        }
    }
}
