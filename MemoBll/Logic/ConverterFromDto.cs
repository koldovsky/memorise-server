using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemoBll.Interfaces;
using MemoDAL.Entities;
using MemoDTO;

namespace MemoBll.Logic
{
    public class ConverterFromDto : IConverterFromDto
    {
        public Answer ConvertToAnswer(AnswerDTO answer)
        {
            throw new NotImplementedException();
        }

        public List<Answer> ConvertToAnswerList(IEnumerable<AnswerDTO> answers)
        {
            throw new NotImplementedException();
        }

        public Card ConvertToCard(CardDTO card)
        {
            throw new NotImplementedException();
        }

        public List<Card> ConvertToCardList(IEnumerable<CardDTO> cards)
        {
            throw new NotImplementedException();
        }

        public CardType ConvertToCardType(CardTypeDTO cardtype)
        {
            throw new NotImplementedException();
        }

        public Category ConvertToCategory(CategoryDTO category)
        {
            throw new NotImplementedException();
        }

        public Comment ConvertToComment(CommentDTO comment)
        {
            throw new NotImplementedException();
        }

        public List<Comment> ConvertToCommentList(IEnumerable<CommentDTO> comments)
        {
            throw new NotImplementedException();
        }

        public Course ConvertToCourse(CourseDTO course)
        {
            return new Course
            {
                Name = course.Name,
                Description = course.Description,
                Linking = course.Linking,
                Price = course.Price
            };
        }

        public List<Course> ConvertToCourseList(IEnumerable<CourseDTO> courses)
        {
            throw new NotImplementedException();
        }

        public Deck ConvertToDeck(DeckDTO deck)
        {
            throw new NotImplementedException();
        }

        public List<Deck> ConvertToDeckList(IEnumerable<DeckDTO> decks)
        {
            throw new NotImplementedException();
        }

        public Report ConvertToReport(ReportDTO report)
        {
            throw new NotImplementedException();
        }

        public Role ConvertToRole(RoleDTO role)
        {
            throw new NotImplementedException();
        }

        public Statistics ConvertToStatistic(StatisticDTO statistic)
        {
            throw new NotImplementedException();
        }

        public UserCourse ConvertToUserCourse(UserCourseDTO userCourse)
        {
            throw new NotImplementedException();
        }

        public User ConvertToUser(UserDTO user)
        {
            throw new NotImplementedException();
        }

        public List<User> ConvertToUserList(IEnumerable<UserDTO> users)
        {
            throw new NotImplementedException();
        }
    }
}
