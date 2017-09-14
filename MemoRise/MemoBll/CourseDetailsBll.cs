using System;
using System.Collections.Generic;
using System.Linq;
using MemoDAL;
using MemoDAL.Entities;
using MemoDAL.EF;
using MemoDTO;

namespace MemoBll
{
    class CourseDetailsBll
    {
        UnitOfWork unitOfWork = new UnitOfWork(new MemoContext());
        ConverterToDto converterToDto = new ConverterToDto();

        public List<DeckDTO> GetAllPaidDecks()
        {
            List<Deck> decks = unitOfWork.Decks.GetCollectionByPredicate(x => x.Price > 0).ToList();
            if(decks.Count > 0)
            {
                List<DeckDTO> deckDTOs = converterToDto.ConvertToDeckListDTO(decks);
                return deckDTOs;
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public List<DeckDTO> GetAllFreeDecks(DateTime fromDate)
        {
            throw new NotImplementedException();
        }

        public double GetDeckPrice(int deckId)
        {
            Deck deck = unitOfWork.Decks.GetOneElementOrDefault(x => x.Id == deckId);
            if (deck != null)
            {
                return deck.Price;
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public List<DeckDTO> GetAllNewDecks(DateTime fromDate)
        {
            throw new NotImplementedException();
        }

        public CourseDTO GetCourseByName(string name)
        {
            CourseDTO courseDTO = new CourseDTO();
            Course course = unitOfWork.Course.GetOneElementOrDefault(x => x.Name == name);
            if (course != null)
            {
                courseDTO = converterToDto.ConvertToCourseDTO(course);                
            }
            else
            {
                throw new ArgumentNullException();
            }
            return courseDTO;
        }

        public CourseDTO GetCourseById(int id)
        {
            CourseDTO courseDTO = new CourseDTO();
            Course course = unitOfWork.Course.GetOneElementOrDefault(x => x.Id == id);
            if (course != null)
            {
                courseDTO = converterToDto.ConvertToCourseDTO(course);                
            }
            else
            {
                throw new ArgumentNullException();
            }
            return courseDTO;
        }
    }
}
