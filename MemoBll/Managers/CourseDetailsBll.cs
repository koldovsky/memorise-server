using MemoBll.Interfaces;
using MemoBll.Logic;
using MemoDAL;
using MemoDAL.EF;
using MemoDAL.Entities;
using MemoDTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MemoBll
{
	public class CourseDetailsBll
    {
        IUnitOfWork unitOfWork;
        IConverterToDTO converterToDto;

        public CourseDetailsBll()
        {
            this.unitOfWork = new UnitOfWork(new MemoContext());
            this.converterToDto = new ConverterToDTO();
        }

        public CourseDetailsBll(IUnitOfWork unitOfWork, IConverterToDTO converterToDto)
        {
            this.unitOfWork = unitOfWork;
            this.converterToDto = converterToDto;
        }

        public List<DeckDTO> GetAllPaidDecks()
        {
            List<Deck> decks = unitOfWork.Decks
                .GetAll().Where(x => x.Price > 0).ToList();
            return decks.Count > 0
                ? converterToDto.ConvertToDeckListDTO(decks)
                : throw new ArgumentNullException();
        }

        public List<DeckDTO> GetAllFreeDecks(DateTime fromDate)
        {
            throw new NotImplementedException();
        }

        public double GetDeckPrice(int deckId)
        {
            Deck deck = unitOfWork.Decks
                .GetAll().FirstOrDefault(x => x.Id == deckId);
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
            Course course = unitOfWork.Courses
                .GetAll().FirstOrDefault(x => x.Name == name);
            courseDTO = course != null
                ? converterToDto.ConvertToCourseDTO(course)
                : throw new ArgumentNullException();

            return courseDTO;
        }

        public CourseDTO GetCourseById(int id)
        {
            CourseDTO courseDTO = new CourseDTO();
            Course course = unitOfWork.Courses
                .GetAll().FirstOrDefault(x => x.Id == id);
            courseDTO = course != null
                ? converterToDto.ConvertToCourseDTO(course)
                : throw new ArgumentNullException();

            return courseDTO;
        }
    }
}
