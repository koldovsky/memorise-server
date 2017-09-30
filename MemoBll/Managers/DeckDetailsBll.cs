using System;
using System.Linq;
using MemoBll.Logic;
using MemoDAL;
using MemoDAL.EF;
using MemoDAL.Entities;
using MemoDTO;

namespace MemoBll.Managers
{
	public class DeckDetailsBll
    {
        UnitOfWork unitOfWork = new UnitOfWork(new MemoContext());
        ConverterToDTO converterToDto = new ConverterToDTO();

        public DeckWithDetailsDTO GetDeckWithDetails(string deckName)
        {
            Deck deck = unitOfWork.Decks.GetAll().FirstOrDefault(x => x.Name == deckName);
            if (deck == null)
            {
                throw new ArgumentNullException();
            }
            DeckWithDetailsDTO deckWithDetailsDTO = converterToDto.ConvertToDeckWithDetailsDTO(deck);
            return deckWithDetailsDTO;
        }
    }
}