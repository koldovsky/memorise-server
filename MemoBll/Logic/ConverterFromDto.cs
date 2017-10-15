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
        public Answer ConvertToAnswer(AnswerDTO answerDTO)
        {
            return new Answer
            {
                Id = answerDTO.Id,
                Text = answerDTO.Text,
                IsCorrect = answerDTO.IsCorrect
            };
        }

        public List<Answer> ConvertToAnswerList(IEnumerable<AnswerDTO> answerDTOs)
        {
            List<Answer> answers = new List<Answer>();
            answerDTOs.ToList().ForEach(a => answers.Add(ConvertToAnswer(a)));
            return answers;
        }

        public Card ConvertToCard(CardDTO cardDTO)
        {
            return new Card()
            {
                Id = cardDTO.Id,
                Question = cardDTO.Question == null ? "" : cardDTO.Question,
                CardType = ConvertToCardType(cardDTO.CardType == null ? new CardTypeDTO() : cardDTO.CardType),
                Deck = ConvertToDeck(cardDTO.Deck == null ? new DeckDTO() : cardDTO.Deck),
                Answers = ConvertToAnswerList(cardDTO.Answers == null ? new List<AnswerDTO>() : cardDTO.Answers),
                Comments = ConvertToCommentList(cardDTO.Comments == null ? new List<CommentDTO>() : cardDTO.Comments)
            };
        }

        public List<Card> ConvertToCardList(IEnumerable<CardDTO> cards)
        {
            throw new NotImplementedException();
        }

        public CardType ConvertToCardType(CardTypeDTO cardtypeDTO)
        {
            return new CardType
            {
                Id = cardtypeDTO.Id,
                Name = cardtypeDTO.Name
            };
        }

        public Category ConvertToCategory(CategoryDTO categoryDTO)
        {
            return new Category
            {
                Id = categoryDTO.Id,
                Name = categoryDTO.Name,
                Linking = categoryDTO.Linking
            };
        }

        public Comment ConvertToComment(CommentDTO commentDTO)
        {
            return new Comment
            {
                Id = commentDTO.Id,
                Message = commentDTO.Message,
                Course = ConvertToCourse(commentDTO.Course == null ? new CourseDTO() : commentDTO.Course),
                User = ConvertToUser(commentDTO.User == null ? new UserDTO() : commentDTO.User)
            };
        }

        public List<Comment> ConvertToCommentList(IEnumerable<CommentDTO> commentDTOs)
        {
            List<Comment> comments = new List<Comment>();
            commentDTOs.ToList().ForEach(c => comments.Add(ConvertToComment(c)));
            return comments;
        }

        public Course ConvertToCourse(CourseDTO courseDTO)
        {
            return new Course
            {
                Id = courseDTO.Id,
                Name = courseDTO.Name,
                Description = courseDTO.Description,
                Linking = courseDTO.Linking,
                Price = courseDTO.Price
            };
        }

        public Course ConvertToCourse(CourseWithDecksDTO courseWithDecksDTO)
        {
            return new Course
            {
                Id = courseWithDecksDTO.Id,
                Name = courseWithDecksDTO.Name,
                Description = courseWithDecksDTO.Description,
                Linking = courseWithDecksDTO.Linking,
                Price = courseWithDecksDTO.Price,
                Photo = courseWithDecksDTO.Photo
            };
        }

        public List<Course> ConvertToCourseList(IEnumerable<CourseDTO> courses)
        {
            throw new NotImplementedException();
        }

        public Deck ConvertToDeck(DeckDTO deckDTO)
        {
            return new Deck
            {
                  Id = deckDTO.Id,
                  Name = deckDTO.Name,
                  Linking = deckDTO.Linking,
                  Price = deckDTO.Price
            };
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

        /// <summary>
        /// It is EmptyUser
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns></returns>
        public User ConvertToUser(UserDTO userDTO)
        {
            User user = new User();
            return user;
        }

        public List<User> ConvertToUserList(IEnumerable<UserDTO> users)
        {
            throw new NotImplementedException();
        }
    }
}
