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

        public List<MemoDTO.CategoryDTO> GetAllCategories()
        {
            List<MemoDTO.CategoryDTO> categoryDtos = new List<MemoDTO.CategoryDTO>();
            List<Category> categories = unitOfWork.Categories.GetAll().ToList();
            foreach (Category category in categories)
            {
                categoryDtos.Add(GetCategoryDTO(category));
            }
            return categoryDtos;
        }

        private MemoDTO.CategoryDTO GetCategoryDTO(Category category)
        {
            return new MemoDTO.CategoryDTO() { Name = category.Name };
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
                deckDTOs.Add(GetDeckDTO(deck));
            }
            return deckDTOs;
        }

        private MemoDTO.DeckDTO GetDeckDTO(Deck deck)
        {
            return new MemoDTO.DeckDTO() { Name = deck.Name, Price = deck.Price };
        }






        public List<MemoDTO.DeckDTO> GetAllDecksByCourse(string courseName)
        {
            List<MemoDTO.DeckDTO> decks = new List<MemoDTO.DeckDTO>();
            IEnumerable<DeckCourse> deckCourses = unitOfWork.DeckCourses.Find(x => x.Course.Id == courseId);
                
            return decks;
        }

        public List<Deck> GetAllPaidDecks()
        {
            return unitOfWork.Decks.Find(x => x.Price > 0).ToList();
        }

        public List<Deck> GetAllFreeDecks()
        {
            return unitOfWork.Decks.Find(x => x.Price == 0).ToList();
        }
    }
    
}
