﻿using System;
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
        public DeckDTO ConvertToDeckDTO(DeckCourse deckCourse)
        {
            return new DeckDTO
            {
                Name = deckCourse.Deck.Name,
                Price = deckCourse.Deck.Price
            };
        }

        public DeckDTO ConvertToDeckDTO(Deck deck)
        {
            return new DeckDTO
            {
                Name = deck.Name,
                Price = deck.Price
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
                Price = course.Price,
                Description = course.Description
            };
        }

        public CategoryDTO ConvertToCategoryDTO(Category category)
        {
            return new CategoryDTO { Name = category.Name };
        }

        public CardTypeDTO ConvertToCardTypeDTO(CardType cardtype)
        {
            return new CardTypeDTO { Name = cardtype.Name };
        }

        public AnswerDTO ConvertToAnswerDTO(Answer answer)
        {
            return new AnswerDTO
            {
                IsCorrect = answer.IsCorrect,
                Text = answer.Text
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

        public RoleDTO ConvertToRoleDTO(Role role)
        {
            return new RoleDTO { Name = role.Name };
        }

        public UserDTO ConvertToUserDTO(User user)
        {
            return new UserDTO
            {
                Email = user.Email,
                IsBlocked = user.IsBlocked,
                Login = user.Login,
                Photo = user.Photo
            };
        }

        public CardDTO ConvertToCardDTO(Card card)
        {
            return new CardDTO
            {
                Question = card.Question,
                CardType = ConvertToCardTypeDTO(card.CardType),
                Deck = ConvertToDeckDTO(card.Deck),
                Answers = ConvertToAnswerListDTO(card.Answers),
                Comments = ConvertToCommentListDTO(card.Comments)
            };
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

        public DeckCourseDTO ConvertToDeckCourseDTO(DeckCourse deckCourse)
        {
            return new DeckCourseDTO
            {
                Course = ConvertToCourseDTO(deckCourse.Course),
                Deck = ConvertToDeckDTO(deckCourse.Deck)
            };
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

        public StatisticDTO ConvertToStatisticDTO(Statistic statistic)
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
    }
}