using MemoBll.Interfaces;
using MemoBll.Logic;
using MemoDAL;
using MemoDAL.EF;
using MemoDAL.Entities;
using MemoDTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MemoBll.Managers
{
	public class CourseDetailsBll
    {
        ICourseDetails courseDetails;
        IConverterToDTO converterToDto;

        public CourseDetailsBll()
        {
            courseDetails = new CourseDetails(new UnitOfWork(new MemoContext()));
            converterToDto = new ConverterToDTO();
        }

        public CourseDetailsBll(
            ICourseDetails courseDetails,
            IConverterToDTO converterToDto)
        {
            this.courseDetails = courseDetails;
            this.converterToDto = converterToDto;
        }

        public IEnumerable<DeckDTO> GetAllPaidDecks()
        {
            List<Deck> decks = courseDetails.GetAllPaidDecks().ToList();
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
            return courseDetails.GetDeckPrice(deckId);
        }

        public List<DeckDTO> GetAllNewDecks(DateTime fromDate)
        {
            throw new NotImplementedException();
        }

        public CourseDTO GetCourseByName(string name)
        {
            Course course = courseDetails.GetCourseByName(name);
            var courseDto = course != null
                ? converterToDto.ConvertToCourseDTO(course)
                : throw new ArgumentNullException();

            return courseDto;
        }

        public CourseDTO GetCourseById(int id)
        {
            Course course = courseDetails.GetCourseById(id);
            var courseDto = course != null
                ? converterToDto.ConvertToCourseDTO(course)
                : throw new ArgumentNullException();

            return courseDto;
        }

        public CourseDTO GetCourseByLinking(string linking)
        {
            Course course = courseDetails.GetCourseByLinking(linking);
            var courseDto = course != null
                ? converterToDto.ConvertToCourseDTO(course)
                : throw new ArgumentNullException();

            return courseDto;
        }
    }
}
