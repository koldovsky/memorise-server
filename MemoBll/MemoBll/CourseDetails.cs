using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemoDAL;
using MemoDAL.Entities;
using MemoDAL.EF;

namespace MemoBll
{
    class CourseDetails
    {
        UnitOfWork unitOfWork = new UnitOfWork(new MemoContext());

        public List<Deck> GetAllDecksByCourse(string id)
        {
            int courseId;
            int.TryParse(id, out courseId);
            List<Deck> decks = new List<Deck>();
            unitOfWork.DeckCourses.Find(x => x.Course.Id == courseId).ToList()
                .ForEach(x => decks.Add(x.Deck));
            return decks;
        }

        public List<Deck> GetAllPaidDecks()
        {
            return unitOfWork.Decks.Find(x => x.Price > 0).ToList();
        }

        public List<Deck> GetAllFreeDecks(DateTime fromDate)
        {
            throw new Exception();
        }

        public decimal GetDeskPrice(int deckId)
        {
            return unitOfWork.Decks.Get(deckId).Price;
        }

        public List<Deck> GetAllNewDecks(DateTime fromDate)
        {
            throw new Exception();
        }
    }
}
