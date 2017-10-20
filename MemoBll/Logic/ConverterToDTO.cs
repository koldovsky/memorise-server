using MemoBll.Interfaces;
using MemoDAL.Entities;
using MemoDTO;
using System.Collections.Generic;
using System.Linq;

namespace MemoBll.Logic
{
	public class ConverterToDto : IConverterToDto
    {
        public DeckDTO ConvertToDeckDto(Deck deck)
        {
            List<string> cardIds = new List<string>();
            if (deck.Cards.Count > 0)
            {
                deck.Cards.ToList().ForEach(x => cardIds.Add(x.Id.ToString()));
            }

            List<string> courseNames = new List<string>();
            if (deck.Courses.Count > 0)
            { 
            deck.Courses.ToList().ForEach(x => courseNames.Add(x.Name));
            }

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
                CourseNames = courseNames,
                Description = deck.Description
            };
        }

        public List<DeckDTO> ConvertToDeckListDto(IEnumerable<Deck> decks)
        {
            List<DeckDTO> deckDTOs = new List<DeckDTO>();
            foreach (Deck deck in decks)
            {
                deckDTOs.Add(ConvertToDeckDto(deck));
            }

            return deckDTOs;
        }

        public CourseDTO ConvertToCourseDto(Course course)
        {
            return new CourseDTO
            {
                Id = course.Id,
                Name = course.Name,
                Linking = course.Linking,
                Price = course.Price,
                Photo = course.Photo,
                Description = course.Description,
                CategoryName = course.Category.Name
        };
        }

        public List<CourseDTO> ConvertToCourseListDto(IEnumerable<Course> courses)
        {
            List<CourseDTO> courseDTOs = new List<CourseDTO>();
            foreach (var course in courses)
            {
                courseDTOs.Add(ConvertToCourseDto(course));
            }

            return courseDTOs;
        }
        
        public CourseWithDecksDTO ConvertToCourseWithDecksDto(Course course)
        {
            return new CourseWithDecksDTO
            {
                Id = course.Id,
                Name = course.Name,
                Linking = course.Linking,
                Price = course.Price,
                Description = course.Description,
                Decks = ConvertToDeckListDto(course.Decks),
                Category = ConvertToCategoryDto(course.Category),
                Photo = course.Photo
            };
        }

        public CategoryDTO ConvertToCategoryDto(Category category)
        {
            return new CategoryDTO {
                Id =category.Id,
                Name = category.Name,
                Linking = category.Linking
            };
        }

        public CardTypeDTO ConvertToCardTypeDto(CardType cardtype)
        {
            return new CardTypeDTO { Name = cardtype.Name };
        }

        public List<CardTypeDTO> ConvertToCardTypeListDto(IEnumerable<CardType> cardTypes)
        {
            List<CardTypeDTO> cardTypeDTOs = new List<CardTypeDTO>();
            foreach (var cardType in cardTypes)
            {
                cardTypeDTOs.Add(ConvertToCardTypeDto(cardType));
            }

            return cardTypeDTOs;
        }

        public AnswerDTO ConvertToAnswerDto(Answer answer)
        {
            return new AnswerDTO
            {
                Id = answer.Id,
                IsCorrect = answer.IsCorrect,
                Text = answer.Text,
            };
        }

        public List<AnswerDTO> ConvertToAnswerListDto(IEnumerable<Answer> answers)
        {
            List<AnswerDTO> answerDTOs = new List<AnswerDTO>();
            foreach (Answer answer in answers)
            {
                answerDTOs.Add(ConvertToAnswerDto(answer));
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

        public List<UserDTO> ConvertToUserListDto(IEnumerable<User> users)
        {
            List<UserDTO> userDTOs = new List<UserDTO>();
            foreach (User user in users)
            {
                userDTOs.Add(ConvertToUserDto(user));
            }

            return userDTOs;
        }

        public CardDTO ConvertToCardDto(Card card)
        {
            return new CardDTO
            {
                Id = card.Id,
                Question = card.Question,
                CardType = ConvertToCardTypeDto(card.CardType),
                Deck = ConvertToDeckDto(card.Deck),
                Answers = ConvertToAnswerListDto(card.Answers),
                Comments = ConvertToCommentListDto(card.Comments)
            };
        }

        public List<CardDTO> ConvertToCardListDto(IEnumerable<Card> cards)
        {
            List<CardDTO> cardDTOs = new List<CardDTO>();
            foreach (var card in cards)
            {
                cardDTOs.Add(ConvertToCardDto(card));
            }

            return cardDTOs;
        }

        public CommentDTO ConvertToCommentDto(Comment comment)
        {
            return new CommentDTO
            {
                Message = comment.Message,
                Course = ConvertToCourseDto(comment.Course),
                User = ConvertToUserDto(comment.User)
            };
        }

        public List<CommentDTO> ConvertToCommentListDto(IEnumerable<Comment> comments)
        {
            List<CommentDTO> commentDTOs = new List<CommentDTO>();
            foreach (Comment comment in comments)
            {
                commentDTOs.Add(ConvertToCommentDto(comment));
            }

            return commentDTOs;
        }

        public ReportDTO ConvertToReportDto(Report report)
        {
            return new ReportDTO
            {
                Date = report.Date,
                Description = report.Description,
                Reason = report.Reason,
                Sender = ConvertToUserDto(report.Sender)
            };
        }

        public StatisticsDTO ConvertToStatisticsDto(Statistics statistic)
        {
            return new StatisticsDTO
            {
                Id = statistic.Id,
                CardStatus = statistic.CardStatus,
                UserLogin = statistic.User.UserName,
                CardId = statistic.Card.Id
            };
        }

        public List<StatisticsDTO> ConvertToStatisticsListDto(IEnumerable<Statistics> statistics)
        {
            List<StatisticsDTO> statisticsDTOs = new List<StatisticsDTO>();
            foreach (var s in statistics)
            {
                statisticsDTOs.Add(ConvertToStatisticsDto(s));
            }

            return statisticsDTOs;
        }

        public SubscribedCourseDTO ConvertToSubscribedCourseDto(SubscribedCourse subscribedCourse)
        {
            return new SubscribedCourseDTO
            {
                Id = subscribedCourse.Id,
                Rating = subscribedCourse.Rating,
                Course = ConvertToCourseDto(subscribedCourse.Course),
                User = ConvertToUserDto(subscribedCourse.User)
            };
        }

        public SubscribedDeckDTO ConvertToSubscribedDeckDto(SubscribedDeck subscribedDeck)
        {
            return new SubscribedDeckDTO
            {
                Id = subscribedDeck.Id,
                Rating = subscribedDeck.Rating,
                User = ConvertToUserDto(subscribedDeck.User),
                Deck = ConvertToDeckDto(subscribedDeck.Deck)
            };
        }

        public RoleDTO ConvertToRoleDto(Role role)
        {
            throw new System.NotImplementedException();
        }

        public UserDTO ConvertToUserDto(User user)
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
