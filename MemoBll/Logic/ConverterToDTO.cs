using MemoBll.Interfaces;
using MemoDAL.Entities;
using MemoDTO;
using System.Collections.Generic;
using System.Linq;



namespace MemoBll.Logic
{
	public class ConverterToDTO : IConverterToDTO
    {
        public DeckDTO ConvertToDeckDTO(Deck deck)
        {
            List<string> cardIds = new List<string>();
            deck.Cards.ToList().ForEach(x => cardIds.Add(x.Id.ToString()));

            List<string> courseNames = new List<string>();
            deck.Courses.ToList().ForEach(x => courseNames.Add(x.Name));

            return new DeckDTO
            {
                Id = deck.Id,
                Name = deck.Name,
                Linking = deck.Linking,
				CardsNumber = deck.Cards.Count,
                Price = deck.Price,
                Photo = deck.Photo,
                CategoryName = deck.Category.Name,
                CardIds = cardIds,
                CourseNames = courseNames
            };
        }

        public List<DeckDTO> ConvertToDeckListDTO(IEnumerable<Deck> decks)
        {
            List<DeckDTO> deckDTOs = new List<DeckDTO>();
            foreach (Deck deck in decks)
            {
                deckDTOs.Add(ConvertToDeckDTO(deck));
            }

            return deckDTOs;
        }

        public CourseDTO ConvertToCourseDTO(Course course)
        {
            return new CourseDTO
            {
                Name = course.Name,
                Linking = course.Linking,
                Price = course.Price,
                Description = course.Description
            };
        }

        public List<CourseDTO> ConvertToCourseListDTO(IEnumerable<Course> courses)
        {
            List<CourseDTO> courseDTOs = new List<CourseDTO>();
            foreach (var course in courses)
            {
                courseDTOs.Add(ConvertToCourseDTO(course));
            }

            return courseDTOs;
        }
        
        public CourseWithDecksDTO ConvertToCourseWithDecksDTO(Course course)
        {
            return new CourseWithDecksDTO
            {
                Id = course.Id,
                Name = course.Name,
                Linking = course.Linking,
                Price = course.Price,
                Description = course.Description,
                Decks = ConvertToDeckListDTO(course.Decks),
                Category = ConvertToCategoryDTO(course.Category),
                Photo = course.Photo
            };
        }

        public CategoryDTO ConvertToCategoryDTO(Category category)
        {
            return new CategoryDTO { Name = category.Name, Linking = category.Linking };
        }

        public CardTypeDTO ConvertToCardTypeDTO(CardType cardtype)
        {
            return new CardTypeDTO { Name = cardtype.Name };
        }

        public AnswerDTO ConvertToAnswerDTO(Answer answer)
        {
            return new AnswerDTO
            {
                Id = answer.Id,
                IsCorrect = answer.IsCorrect,
                Text = answer.Text,
            };
        }

        public List<AnswerDTO> ConvertToAnswerListDTO(IEnumerable<Answer> answers)
        {
            List<AnswerDTO> answerDTOs = new List<AnswerDTO>();
            foreach (Answer answer in answers)
            {
                answerDTOs.Add(ConvertToAnswerDTO(answer));
            }

            return answerDTOs;
        }

        //public RoleDTO ConvertToRoleDTO(Role role)
        //{
        //    return new RoleDTO { Name = role.Name };
        //}

        //public UserDTO ConvertToUserDTO(User user)
        //{
        //    return new UserDTO
        //    {
        //        Email = user.Email,
        //        IsBlocked = user.IsBlocked,
        //        Login = user.Login,
        //        Photo = user.Photo
        //    };
        //}

        public List<UserDTO> ConvertToUserListDTO(IEnumerable<User> users)
        {
            List<UserDTO> userDTOs = new List<UserDTO>();
            foreach (User user in users)
            {
                userDTOs.Add(ConvertToUserDTO(user));
            }

            return userDTOs;
        }

        public CardDTO ConvertToCardDTO(Card card)
        {
            return new CardDTO
            {
                Id = card.Id,
                Question = card.Question,
                CardType = ConvertToCardTypeDTO(card.CardType),
                Deck = ConvertToDeckDTO(card.Deck),
                Answers = ConvertToAnswerListDTO(card.Answers),
                Comments = ConvertToCommentListDTO(card.Comments)
            };
        }

        public List<CardDTO> ConvertToCardListDTO(IEnumerable<Card> cards)
        {
            List<CardDTO> cardDTOs = new List<CardDTO>();
            foreach (var card in cards)
            {
                cardDTOs.Add(ConvertToCardDTO(card));
            }

            return cardDTOs;
        }

        public CommentDTO ConvertToCommentDTO(Comment comment)
        {
            return new CommentDTO
            {
                Message = comment.Message,
                Course = ConvertToCourseDTO(comment.Course),
                User = ConvertToUserDTO(comment.User)
            };
        }

        public List<CommentDTO> ConvertToCommentListDTO(IEnumerable<Comment> comments)
        {
            List<CommentDTO> commentDTOs = new List<CommentDTO>();
            foreach (Comment comment in comments)
            {
                commentDTOs.Add(ConvertToCommentDTO(comment));
            }

            return commentDTOs;
        }

        public ReportDTO ConvertToReportDTO(Report report)
        {
            return new ReportDTO
            {
                Date = report.Date,
                Description = report.Description,
                Reason = report.Reason,
                Sender = ConvertToUserDTO(report.Sender)
            };
        }

        public StatisticDTO ConvertToStatisticDTO(Statistics statistic)
        {
            return new StatisticDTO
            {
                SuccessPercent = statistic.SuccessPercent,
                Deck = ConvertToDeckDTO(statistic.Deck),
                User = ConvertToUserDTO(statistic.User)
            };
        }

        public UserCourseDTO ConvertToUserCourseDTO(UserCourse userCourse)
        {
            return new UserCourseDTO
            {
                Rating = userCourse.Rating,
                Course = ConvertToCourseDTO(userCourse.Course),
                User = ConvertToUserDTO(userCourse.User)
            };
        }

        public RoleDTO ConvertToRoleDTO(Role role)
        {
            throw new System.NotImplementedException();
        }

        public UserDTO ConvertToUserDTO(User user)
        {
            return new UserDTO
            {
                Login = user.UserName,
                Email = user.Email,
                IsBlocked = user.UserProfile.IsBlocked
            };
        }
    }
}
