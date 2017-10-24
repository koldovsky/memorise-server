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
        private ICourseDetails courseDetails;
        private IConverterToDTO converterToDTO;

        public CourseDetailsBll()
        {
            courseDetails = new CourseDetails(new UnitOfWork(new MemoContext()));
            converterToDTO = new ConverterToDTO();
        }

        public CourseDetailsBll(
            ICourseDetails courseDetails,
            IConverterToDTO converterToDTO)
        {
            this.courseDetails = courseDetails;
            this.converterToDTO = converterToDTO;
        }

        public IEnumerable<DeckDTO> GetAllPaidDecks()
        {
            List<Deck> decks = courseDetails.GetAllPaidDecks().ToList();
            return decks.Count > 0
                ? converterToDTO.ConvertToDeckListDTO(decks)
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
            var courseDTO = course != null
                ? converterToDTO.ConvertToCourseDTO(course)
                : throw new ArgumentNullException();

            return courseDTO;
        }

        public CourseDTO GetCourseById(int id)
        {
            Course course = courseDetails.GetCourseById(id);
            var courseDTO = course != null
                ? converterToDTO.ConvertToCourseDTO(course)
                : throw new ArgumentNullException();

            return courseDTO;
        }

        public CourseDTO GetCourseByLinking(string linking)
        {
            Course course = courseDetails.GetCourseByLinking(linking);
            var courseDTO = course != null
                ? converterToDTO.ConvertToCourseDTO(course)
                : throw new ArgumentNullException();

            return courseDTO;
        }
    }
}
