using System;
using System.Collections.Generic;
using System.Linq;
using MemoDAL;
using MemoDAL.Entities;
using MemoDAL.EF;
using MemoDTO;
using MemoBll.Logic;

namespace MemoBll
{
    public class DeckDetailsBll
    {
        UnitOfWork unitOfWork = new UnitOfWork(new MemoContext());
        ConverterToDTO converterToDto = new ConverterToDTO();

        public DeckWithDetailsDTO GetDeckWithDetails(string deckLinking)
        {
            Deck deck = unitOfWork.Decks.GetAll().FirstOrDefault(x => x.Linking == deckLinking);
            if (deck == null)
            {
                throw new ArgumentNullException();
            }
            DeckWithDetailsDTO deckWithDetailsDTO = converterToDto.ConvertToDeckWithDetailsDTO(deck);
            return deckWithDetailsDTO;
        }
    }
}