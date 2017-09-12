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
    class Quiz
    {
        UnitOfWork unitOfWork = new UnitOfWork(new MemoContext());

        //public void SetStatistics(Deck deck, User user, int successPercent)
        //{
        //    if (deck != null && user != null)
        //    {
        //        List<Statistic> statistics = unitOfWork.Statistics.Find(x => x.Deck.Id == deck.Id && x.User.Id == user.Id).ToList();
        //        if (statistics.Count > 1)
        //        {
        //            //UpdateStatistics(deck, user, successPercent);
        //        }
        //        else
        //        {
        //            Statistic statistic = new Statistic();
        //            statistic.Deck = deck;
        //            statistic.User = user;
        //            statistic.SuccessPercent = successPercent;
        //            unitOfWork.Statistics.Create(statistic);
        //            unitOfWork.Save();
        //        }
        //    }
        //}

        //public List<Card> GetAllCardsInDeck(int deckId)
        //{
        //    return unitOfWork.Cards.GetAll().Where(x => x.Deck.Id == deckId).ToList();
        //}

        //public Card GetCard(int cardId)
        //{
        //    return unitOfWork.Cards.Get(cardId);
        //}

        //public List<Answer> GetAllAnswersInCard(int cardId)
        //{
        //    return unitOfWork.Cards.Get(cardId).Answers.ToList();
        //}
        private MemoDTO.CardDTO ConvertToCardDTO(Card card)
        {
            MemoDTO.CardDTO cardDto = null;       

                //MemoDTO.CardTypeDTO = new MemoDTO.CardTypeDTO
                //{
                //    Id = card.CardType.Id,
                //    Answers = new List<AnswerDT>()
                //}
        
            return cardDto;
        }

        public List<MemoDTO.CardDTO> GetCardsByDeck(string deckName)   
        {
            List<MemoDTO.CardDTO> cards = new List<MemoDTO.CardDTO>();
            Deck deck = unitOfWork.Decks.GetAll().FirstOrDefault(x => x.Name == deckName);
            foreach (Card card in deck.Cards)   
            {
                //cards.Add(GetCardDTO(card));
            }
            return cards;
        }
    }
}
