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
    class ConverterToDto
    {
        public MemoDTO.DeckDTO GetDeckDTO(DeckCourse deckCourse)
        {
            return new MemoDTO.DeckDTO()
            {
                Name = deckCourse.Deck.Name,
                Price = deckCourse.Deck.Price
            };
        }

        public MemoDTO.DeckDTO GetDeckDTO(Deck deck)
        {
            return new MemoDTO.DeckDTO() { Name = deck.Name, Price = deck.Price };
        }

        public MemoDTO.CourseDTO GetCourseDTO(Course course)
        {
            return new MemoDTO.CourseDTO()
            {
                Name = course.Name,
                Price = course.Price,
                Description = course.Description
            };
        }

        public MemoDTO.CategoryDTO GetCategoryDTO(Category category)
        {
            return new MemoDTO.CategoryDTO() { Name = category.Name };
        }
    }
}
