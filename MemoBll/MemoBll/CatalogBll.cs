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
    public class CatalogBll
    {
        UnitOfWork unitOfWork = new UnitOfWork(new MemoContext());
        ConverterToDto converterToDto = new ConverterToDto();

        public List<MemoDTO.CategoryDTO> GetAllCategories()
        {
            List<MemoDTO.CategoryDTO> categoryDtos = new List<MemoDTO.CategoryDTO>();
            List<Category> categories = unitOfWork.Categories.GetAll().ToList();
            foreach (Category category in categories)
            {
                categoryDtos.Add(converterToDto.ConvertToCategoryDTO(category));
            }
            return categoryDtos;
        }

        public List<MemoDTO.CourseDTO> GetAllCourses()
        {
            List<MemoDTO.CourseDTO> categoryDtos = new List<MemoDTO.CourseDTO>();
            List<Course> curses = unitOfWork.Course.GetAll().ToList();
            foreach (Course course in curses)
            {
                categoryDtos.Add(GetCourseDTO(course));
            }
            return categoryDtos;
        }

        private MemoDTO.CourseDTO GetCourseDTO(Course course)
        {
            return new MemoDTO.CourseDTO()
            {
                Name = course.Name,
                Price = course.Price,
                Description = course.Description
            };
        }

        public List<MemoDTO.DeckDTO> GetAllDecks()
        {
            List<MemoDTO.DeckDTO> deckDTOs = new List<MemoDTO.DeckDTO>();
            List<Deck> decks = unitOfWork.Decks.GetAll().ToList();
            foreach (Deck deck in decks)
            {
                deckDTOs.Add(converterToDto.ConvertToDeckDTO(deck));
            }
            return deckDTOs;
        }

        public List<MemoDTO.DeckDTO> GetAllDecksByCourse(string courseName)
        {
            List<MemoDTO.DeckDTO> decks = new List<MemoDTO.DeckDTO>();
            IEnumerable<DeckCourse> deckCourses = unitOfWork.DeckCourses.Find(x => x.Course.Name == courseName);
            foreach(DeckCourse deckCourse in deckCourses)
            {
                decks.Add(converterToDto.ConvertToDeckDTO(deckCourse));
            }
            return decks;
        }

        public List<MemoDTO.DeckDTO> GetAllDecksByCategory(string categoryName)
        {
            List<MemoDTO.DeckDTO> decks = new List<MemoDTO.DeckDTO>();
            Category category = unitOfWork.Categories.GetAll().FirstOrDefault(x => x.Name == categoryName);
            foreach (Deck deck in category.Decks)
            {
                decks.Add(converterToDto.ConvertToDeckDTO(deck));
            }
            return decks;
        }

        public List<MemoDTO.CourseDTO> GetAllCourseByCategory(string categoryName)
        {
            List<MemoDTO.CourseDTO> courses = new List<MemoDTO.CourseDTO>();
            Category category = unitOfWork.Categories.GetAll().FirstOrDefault(x => x.Name == categoryName);
            foreach (Course course in category.Courses)
            {
                courses.Add(GetCourseDTO(course));
            }
            return courses;
        }
    }
    
}
