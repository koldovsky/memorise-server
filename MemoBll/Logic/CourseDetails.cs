using MemoDAL;
using MemoDAL.EF;
using MemoDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using MemoBll.Interfaces;

namespace MemoBll
{
    public class CourseDetails : ICourseDetails
    {
        IUnitOfWork unitOfWork;

        public CourseDetails()
        {
            unitOfWork = new UnitOfWork(new MemoContext());
        }

        public CourseDetails(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Deck> GetAllPaidDecks()
        {
            return unitOfWork.Decks.GetAll().Where(x => x.Price > 0);
        }

        public IEnumerable<Deck> GetAllFreeDecks(DateTime fromDate)
        {
            throw new NotImplementedException();
        }

        public double GetDeckPrice(int deckId)
        {
            Deck deck = unitOfWork.Decks.Get(deckId);
            return deck?.Price ?? throw new ArgumentNullException();
        }

        public IEnumerable<Deck> GetAllNewDecks(DateTime fromDate)
        {
            throw new NotImplementedException();
        }

        public Course GetCourseByName(string name)
        {
            return unitOfWork.Courses.GetAll().FirstOrDefault(x => x.Name == name);
        }

        public Course GetCourseById(int id)
        {
            return unitOfWork.Courses.Get(id);
        }
    }
}
