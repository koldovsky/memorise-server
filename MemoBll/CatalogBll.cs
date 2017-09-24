using System.Collections.Generic;
using System.Linq;
using System;
using MemoDAL;
using MemoDAL.Entities;
using MemoDAL.EF;
using MemoDTO;

namespace MemoBll
{
    public class CatalogBll
    {
        IUnitOfWork unitOfWork;
        IConverterToDTO converterToDto;

        public CatalogBll()
        {
            unitOfWork = new UnitOfWork(new MemoContext());
            converterToDto = new ConverterToDTO();
        }

        public CatalogBll(IUnitOfWork uow, IConverterToDTO converter)
        {
            unitOfWork = uow;
            converterToDto = converter;
        }

        public List<CategoryDTO> GetAllCategories()
        {
            List<CategoryDTO> categoryDtos = new List<CategoryDTO>();
            IEnumerable<Category> categories = unitOfWork.Categories.GetAll();
            if (categories != null && categories.ToList().Count > 0)
            {
                foreach (Category category in categories)
                {
                    categoryDtos.Add(converterToDto.ConvertToCategoryDTO(category));
                }
            }
            else
            {
                throw new ArgumentNullException();
            }

            return categoryDtos;
        }

        public List<CourseDTO> GetAllCourses()
        {
            List<CourseDTO> categoryDtos = new List<CourseDTO>();
            IEnumerable<Course> courses = unitOfWork.Courses.GetAll();
            if (courses != null && courses.ToList().Count > 0)
            {
                foreach (Course course in courses)
                {
                    categoryDtos.Add(converterToDto.ConvertToCourseDTO(course));
                }
            }
            else
            {
                throw new ArgumentNullException();
            }

            return categoryDtos;
        }

        public List<DeckDTO> GetAllDecks()
        {
            List<DeckDTO> deckDTOs = new List<DeckDTO>();
            IEnumerable<Deck> decks = unitOfWork.Decks.GetAll();
            if (decks != null && decks.ToList().Count > 0)
            {
                foreach (Deck deck in decks)
                {
                    deckDTOs.Add(converterToDto.ConvertToDeckDTO(deck));
                }
            }
            else
            {
                throw new ArgumentNullException();
            }

            return deckDTOs;
        }

        public List<DeckDTO> GetAllDecksByCourse(string courseName)
        {
            List<DeckDTO> decks = new List<DeckDTO>();
            Course course = unitOfWork.Courses
				.GetAll()
                .Where(x => x.Name == courseName)
				.First();

            if (course != null && course.Decks.Count > 0)
            {
                foreach (Deck deck in course.Decks)
                {
                    decks.Add(converterToDto.ConvertToDeckDTO(deck));
                }
            }
            else
            {
                throw new ArgumentNullException();
            }

            return decks;
        }

        public List<DeckDTO> GetAllDecksByCategory(string categoryName)
        {
            List<DeckDTO> decks = new List<DeckDTO>();
            Category category = unitOfWork.Categories
                .GetAll()
				.First(x => x.Name == categoryName);
            if (category != null)
            {
                foreach (Deck deck in category.Decks)
                {
                    decks.Add(converterToDto.ConvertToDeckDTO(deck));
                }
            }
            else
            {
                throw new ArgumentNullException();
            }

            return decks;
        }

        public List<CourseDTO> GetAllCoursesByCategory(string categoryName)
        {
            List<CourseDTO> courses = new List<CourseDTO>();
            Category category = unitOfWork.Categories
                .GetAll()
				.First(x => x.Name == categoryName);
            if (category != null)
            {
                foreach (Course course in category.Courses)
                {
                    courses.Add(converterToDto.ConvertToCourseDTO(course));
                }
            }
            else
            {
                throw new ArgumentNullException();
            }

            return courses;
        }

        public CourseWithDecksDTO GetCourseWithDecksDTO(string courseName)
        {
            Course course = unitOfWork.Courses
				.GetAll()
                .Where(x => x.Name == courseName)
				.First();

            CourseWithDecksDTO courseWithDeckDto = 
				course != null
                ? converterToDto.ConvertToCourseWithDecksDTO(course)
                : throw new ArgumentNullException();

            return courseWithDeckDto;
        }
    }
}
