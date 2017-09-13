using MemoDAL;
using MemoDAL.Entities;
using MemoDAL.EF;

namespace MemoBll
{
    class CardEditor
    {
        UnitOfWork unitOfWork = new UnitOfWork(new MemoContext());

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
