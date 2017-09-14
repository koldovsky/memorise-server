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
        UnitOfWork unitOfWork = new UnitOfWork(new MemoContext());
        ConverterToDto converterToDto = new ConverterToDto();

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
            else throw new NullReferenceException();
            return categoryDtos;
        }

        public List<CourseDTO> GetAllCourses()
        {
            List<CourseDTO> categoryDtos = new List<CourseDTO>();
            IEnumerable<Course> courses = unitOfWork.Course.GetAll();
            if (courses != null && courses.ToList().Count > 0)
            {
                foreach (Course course in courses)
                {
                    categoryDtos.Add(converterToDto.ConvertToCourseDTO(course));
                }
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
            return deckDTOs;
        }
               
        public List<DeckDTO> GetAllDecksByCourse(string courseName)
        {
            List<DeckDTO> decks = new List<DeckDTO>();
            Course course = unitOfWork.Course.GetCourseWithDecks(x => x.Name == courseName);

            if (course != null && course.Decks.Count>0)
            {
                foreach (Deck deck in course.Decks)
                {
                    decks.Add(converterToDto.ConvertToDeckDTO(deck));
                }
            }
            return decks;
        }

        public List<DeckDTO> GetAllDecksByCategory(string categoryName)
        {
            List<DeckDTO> decks = new List<DeckDTO>();
            Category category = unitOfWork.Categories.GetOneElementOrDefault(x => x.Name == categoryName);
            if (category != null)
            {
                foreach (Deck deck in category.Decks)
                {
                    decks.Add(converterToDto.ConvertToDeckDTO(deck));
                }
            }
            return decks;
        }

        public List<CourseDTO> GetAllCourseByCategory(string categoryName)
        {
            List<CourseDTO> courses = new List<CourseDTO>();
            Category category = unitOfWork.Categories.GetOneElementOrDefault(x => x.Name == categoryName);
            if (category != null)
            {
                foreach (Course course in category.Courses)
                {
                    courses.Add(converterToDto.ConvertToCourseDTO(course));
                }
            }
            return courses;
        }
    }
    
}
