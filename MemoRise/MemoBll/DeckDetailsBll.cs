using System;
using System.Collections.Generic;
using System.Linq;
using MemoDAL;
using MemoDAL.Entities;
using MemoDAL.EF;
using MemoDTO;

namespace MemoBll
{
    public class DeckDetailsBll
    {
        UnitOfWork unitOfWork = new UnitOfWork(new MemoContext());
        ConverterToDto converterToDto = new ConverterToDto();

        public DeckWithDetailsDTO GetDeckWithDetails(string deckName)
        {
            Deck deck = unitOfWork.Decks.GetOneElementOrDefault(x => x.Name == deckName);
            if(deck == null)
            {
                throw new ArgumentNullException();
            }
            DeckWithDetailsDTO deckWithDetailsDTO = converterToDto.ConvertToDeckWithDetailsDTO(deck);
            return deckWithDetailsDTO;
        }
    }
}
