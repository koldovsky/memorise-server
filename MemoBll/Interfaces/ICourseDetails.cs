using System;
using System.Collections.Generic;
using MemoDAL.Entities;

namespace MemoBll.Interfaces
{
    public interface ICourseDetails
    {
        IEnumerable<Deck> GetAllPaidDecks();
        IEnumerable<Deck> GetAllFreeDecks(DateTime fromDate);
        double GetDeckPrice(int deckId);
        IEnumerable<Deck> GetAllNewDecks(DateTime fromDate);
        Course GetCourseByName(string name);
        Course GetCourseById(int id);
    }
}
