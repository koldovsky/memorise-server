using System.Collections.Generic;
using System.Linq;
using MemoBll.Interfaces;
using MemoDAL;
using MemoDAL.EF;
using MemoDAL.Entities;
using Microsoft.AspNet.Identity;

namespace MemoBll.Logic
{
    class CustomerStatistics: ICustomerStatistics
    {
        IUnitOfWork unitOfWork;

        public CustomerStatistics()
        {
            unitOfWork = new UnitOfWork(new MemoContext());
        }

        public CustomerStatistics(IUnitOfWork uow)
        {
            unitOfWork = uow;
        }

        public IEnumerable<Statistics> GetStatistics(string userId, int deckId)
        {
            List<Statistics> result = new List<Statistics>();
            var cards = unitOfWork.Decks.Get(deckId).Cards;
            foreach (var card in cards)
            {
                result.Add(unitOfWork.Statistics.GetAll()
                    .FirstOrDefault(s => s.User.Id == userId && s.Card.Id == card.Id));
            }

            return result;
        }

        public void SaveStatistics(Statistics statisticsToSave)
        {
            var statistics = unitOfWork.Statistics.Get(statisticsToSave.Id);
            if (statistics == null)
            {
                unitOfWork.Statistics.Create(statisticsToSave);
            }
            else
            {
                unitOfWork.Statistics.Update(statisticsToSave);
            }
        }
    }
}
