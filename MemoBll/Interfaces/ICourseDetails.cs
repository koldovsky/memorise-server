using MemoDAL.Entities;
using System;
using System.Collections.Generic;

namespace MemoBll.Interfaces
{
	public interface ICourseDetails
    {
        IEnumerable<Deck> GetAllPaidDecks();

        IEnumerable<Deck> GetAllFreeDecks(DateTime fromDate);

        double GetDeckPrice(int deckId);

        IEnumerable<Deck> GetAllNewDecks(DateTime fromDate);

        Course GetCourseByName(string name);

        Course GetCourseByLinking(string linking);

        Course GetCourseById(int id);
    }
}
