using System;
using System.Collections.Generic;
using System.Linq;
using MemoDAL;
using MemoDAL.Entities;
using MemoDAL.EF;

namespace MemoBll
{
    class CourseDetails
    {
        UnitOfWork unitOfWork = new UnitOfWork(new MemoContext());
                
        public List<Deck> GetAllPaidDecks()
        {
            return unitOfWork.Decks.GetCollectionByPredicate(x => x.Price > 0).ToList();
        }

        public List<Deck> GetAllFreeDecks(DateTime fromDate)
        {
            throw new NotImplementedException();
        }

        public decimal GetDeskPrice(int deckId)
        {
            return unitOfWork.Decks.Get(deckId).Price;
        }

        public List<Deck> GetAllNewDecks(DateTime fromDate)
        {
            throw new NotImplementedException();
        }

        public Course GetCourseByName(string name)
        {
            return unitOfWork.Course.GetAll().FirstOrDefault(x => x.Name == name);
        }
    }
}
