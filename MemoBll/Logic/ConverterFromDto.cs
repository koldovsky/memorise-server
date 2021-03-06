﻿using System;
using System.Collections.Generic;
using System.Linq;
using MemoBll.Interfaces;
using MemoDAL;
using MemoDAL.EF;
using MemoDAL.Entities;
using MemoDTO;
using Microsoft.AspNet.Identity;

namespace MemoBll.Logic
{
    public class ConverterFromDTO : IConverterFromDTO
    {
        private IUnitOfWork unitOfWork;

        public ConverterFromDTO()
        {
            unitOfWork = new UnitOfWork(new MemoContext());
        }

        public ConverterFromDTO(IUnitOfWork uow)
        {
            unitOfWork = uow;
        }

        public Algorithm ConvertToAlgorithm(AlgorithmDTO algorithmDTO)
        {
            return new Algorithm
            {
                Id = algorithmDTO.Id,
                Name = algorithmDTO.Name,
                Description = algorithmDTO.Description,
                IsActive = algorithmDTO.IsActive
            };
        }

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
                Question = cardDTO.Question ?? string.Empty,
                CardType = ConvertToCardType(cardDTO.CardType ?? new CardTypeDTO()),
                Deck = ConvertToDeck(cardDTO.Deck ?? new DeckDTO()),
                Answers = ConvertToAnswerList(cardDTO.Answers ?? new List<AnswerDTO>()),
                Comments = ConvertToCommentList(cardDTO.Comments ?? new List<CommentDTO>())
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
                Course = ConvertToCourse(commentDTO.Course ?? new CourseDTO()),
                User = ConvertToUser(commentDTO.User ?? new UserDTO())
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

        public Course ConvertToCourse(CourseWithDecksDTO courseWithDecksDto)
        {
            return new Course
            {
                Id = courseWithDecksDto.Id,
                Name = courseWithDecksDto.Name,
                Description = courseWithDecksDto.Description,
                Linking = courseWithDecksDto.Linking,
                Price = courseWithDecksDto.Price,
                Photo = courseWithDecksDto.Photo
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
                  Price = deckDTO.Price,
                  Description = deckDTO.Description
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

        public Statistics ConvertToStatistics(StatisticsDTO statistics)
        {
            return new Statistics
            {
                Id = statistics.Id,
                CardStatus = statistics.CardStatus,
                UserId = unitOfWork.Users.FindByName(statistics.UserLogin).Id,
                User = unitOfWork.Users.FindByName(statistics.UserLogin),
                CardId = statistics.CardId,
                Card = unitOfWork.Cards.Get(statistics.CardId)
            };
        }

        public CourseSubscription ConvertToCourseSubscription(CourseSubscriptionDTO courseSubscription)
        {
            return new CourseSubscription
            {
                Id = courseSubscription.Id,
                Rating = courseSubscription.Rating,
                UserId = unitOfWork.Users.FindByName(courseSubscription.UserLogin).Id,
                User = unitOfWork.Users.FindByName(courseSubscription.UserLogin),
                CourseId = courseSubscription.CourseId,
                Course = unitOfWork.Courses.Get(courseSubscription.CourseId)
            };
        }

        public DeckSubscription ConvertToDeckSubscription(DeckSubscriptionDTO deckSubscription)
        {
            return new DeckSubscription
            {
                Id = deckSubscription.Id,
                Rating = deckSubscription.Rating,
                UserId = unitOfWork.Users.FindByName(deckSubscription.UserLogin).Id,
                User = unitOfWork.Users.FindByName(deckSubscription.UserLogin),
                DeckId = deckSubscription.DeckId,
                Deck = unitOfWork.Decks.Get(deckSubscription.DeckId)
            };
        }
        
        public User ConvertToUser(UserDTO userDTO)
        {
            UserProfile userProfileDetails = new UserProfile()
            {
                IsBlocked = userDTO.IsBlocked,
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                Gender = userDTO.Gender,
                Country = userDTO.Country,
                City = userDTO.City
            };
            User user = new User()
            {
                Id = userDTO.Id,
                UserName = userDTO.Login,
                Email = userDTO.Email,
                UserProfile = userProfileDetails
            };
            return user;
        }

        public UserProfile ConvertToUserProfile(UserDTO userDTO)
        {
            User user = new User()
            {
                Id = userDTO.Id,
                UserName = userDTO.Login,
                Email = userDTO.Email
            };
            UserProfile userProfileDetails = new UserProfile()
            {
                IsBlocked = userDTO.IsBlocked,
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                Gender = userDTO.Gender,
                Country = userDTO.Country,
                City = userDTO.City,
                User = user
            };
            return userProfileDetails;
        }

        public List<User> ConvertToUserList(IEnumerable<UserDTO> users)
        {
            List<User> listedUsers = new List<User>();
            foreach (UserDTO user in users)
            {
                listedUsers.Add(ConvertToUser(user));
            }

            return listedUsers;
        }
    }
}
