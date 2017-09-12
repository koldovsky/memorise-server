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
    class CatalogBll
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
            return new MemoDTO.CategoryDTO { Name = category.Name };
        }

        public List<string> GetAllCourses()
        {
            List<string> names = new List<string>();
            foreach (Course course in unitOfWork.Course.GetAll())
            {
                names.Add(course.Name);
            }
            return names;
        }

        public List<Deck> GetAllDecks()
        {
            return unitOfWork.Decks.GetAll().ToList();
        }

        public List<Deck> GetAllDecksByCourse(string id)
        {
            int courseId;
            int.TryParse(id, out courseId);
            List<Deck> decks = new List<Deck>();
            unitOfWork.DeckCourses.Find(x => x.Course.Id == courseId).ToList()
                .ForEach(x => decks.Add(x.Deck));
            return decks;
        }

        public List<Deck> GetAllPaidDecks()
        {
            return unitOfWork.Decks.Find(x => x.Price > 0).ToList();
        }

        public List<Deck> GetAllFreeDecks(DateTime fromDate)
        {
            throw new Exception();
        }
    }
    
}
