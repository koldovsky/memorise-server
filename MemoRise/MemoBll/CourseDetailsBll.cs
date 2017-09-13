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

        public CourseDTO GetCourseByName(string name)
        {
            Course course = unitOfWork.Course.GetOneElementOrDefault(x => x.Name == name);
            if (course != null)
            {
                CourseDTO courseDTO = converterToDto.ConvertToCourseDTO(course);
                return courseDTO;
            }
            else
            {
                throw new ArgumentNullException();
            }
        }
        public CourseDTO GetCourseById(int id)
        {
            Course course = unitOfWork.Course.GetOneElementOrDefault(x => x.Id == id);
            if (course != null)
            {
                CourseDTO courseDTO = converterToDto.ConvertToCourseDTO(course);
                return courseDTO;
            }
            else
            {
                throw new ArgumentNullException();
            }
        }
    }
}
