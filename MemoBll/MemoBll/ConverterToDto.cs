using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemoDAL;
using MemoDAL.Entities;
using MemoDAL.EF;
using MemoDTO;

namespace MemoBll
{
    class ConverterToDto
    {
        public DeckDTO GetDeckDTO(DeckCourse deckCourse)
        {
            return new DeckDTO()
            {
                Name = deckCourse.Deck.Name,
                Price = deckCourse.Deck.Price
            };
        }

        public DeckDTO GetDeckDTO(Deck deck)
        {
            return new DeckDTO() { Name = deck.Name, Price = deck.Price };
        }

        public CourseDTO GetCourseDTO(Course course)
        {
            return new CourseDTO()
            {
                Name = course.Name,
                Price = course.Price,
                Description = course.Description
            };
        }

        public CategoryDTO GetCategoryDTO(Category category)
        {
            return new CategoryDTO() { Name = category.Name };
        }

        public CardTypeDTO ConvertToCardTypeDTO(CardType cardtype)
        {
            return new CardTypeDTO { Id = cardtype.Id, Name = cardtype.Name };
        }
        public AnswerDTO ConvertToAnswerDTO(Answer answer)
        {
            return new AnswerDTO { Id = answer.Id, IsCorrect = answer.IsCorrect, Text = answer.Text };
        }
    }
}
