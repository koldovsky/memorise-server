using MemoBll.Interfaces;
using MemoBll.Logic;
using MemoDAL.Entities;
using MemoDTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MemoBll.Managers
{
    public class ModerationBll
    {
        private IModeration moderation;
        private IConverterToDTO converterToDTO;

        public ModerationBll()
        {
            moderation = new Moderation();
            converterToDTO = new ConverterToDTO();
        }

        public ModerationBll(
            IModeration moderation,
            IConverterToDTO converterToDTO)
        {
            this.moderation = moderation;
            this.converterToDTO = converterToDTO;
        }

        #region ForReports

        public int GetReportCountForReason(string reason)
        {
            return moderation.GetReportCountForReason(reason);
        }

        public List<Report> GetAllReportsOnReason(string reason)
        {
            return moderation.GetAllReportsOnReason(reason).ToList();
        }

        public List<Report> GetAllReportsOnDate(DateTime date)
        {
            return moderation.GetAllReportsOnDate(date).ToList();
        }

        public List<Report> GetAllReportsFromDate(DateTime date)
        {
            return moderation.GetAllReportsFromDate(date).ToList();
        }

        public Report GetReport(int reportId)
        {
            return moderation.GetReport(reportId);
        }

        #endregion

        #region ForStatistics

        ////public int GetDeckStatistics(int deckId)
        ////{
        ////    var deckStatistics = moderation.GetDeckStatistics(deckId).ToList();
        ////    int result = 0;
        ////    if (deckStatistics.Count > 0)
        ////    {
        ////        double totalDeckPercent = 0.0;
        ////        foreach (Statistics statistic in deckStatistics)
        ////        {
        ////            totalDeckPercent += statistic.SuccessPercent;
        ////        }
        ////        result = Convert.ToInt32(
        ////            Math.Round(totalDeckPercent / deckStatistics.Count));
        ////    }

        ////    return result;
        ////}

        ////public int GetStatistics(string deckName, int userId)
        ////{
        ////    Statistics statistics = moderation.GetStatistics(deckName, userId);

        ////    return statistics != null ? statistics.SuccessPercent : 0;
        ////}

        ////public void DeleteStatistics(int statisticsId)
        ////{
        ////    moderation.DeleteStatistics(statisticsId);
        ////}

        #endregion

        #region ForUserBy

        public List<UserDTO> GetAllUsersByCourse(int courseId)
        {
            List<User> users = moderation.GetAllUsersByCourse(courseId).ToList();
            List<UserDTO> usersDTO = new List<UserDTO>();
            foreach (var user in users)
            {
                usersDTO.Add(converterToDTO.ConvertToUserDTO(user));
            }

            return usersDTO;
        }

        public List<UserDTO> GetAllUsersByDeck(int deckId)
        {
            List<User> users = moderation.GetAllUsersByDeck(deckId).ToList();
            List<UserDTO> usersDTO = new List<UserDTO>();
            foreach (var user in users)
            {
                usersDTO.Add(converterToDTO.ConvertToUserDTO(user));
            }

            return usersDTO;
        }

        #endregion

        #region ForAnswers

        public Answer CreateAnswer(Answer answer)
        {
           return moderation.CreateAnswer(answer);
        }

        public void UpdateAnswer(Answer answer)
        {
            moderation.UpdateAnswer(answer);
        }

        public void RemoveAnswer(int answerId)
        {
            moderation.RemoveAnswer(answerId);
        }

        #endregion

        #region ForCategories

        public void CreateCategory(Category category)
        {
            moderation.CreateCategory(category);
        }

        public void UpdateCategory(Category category)
        {
            moderation.UpdateCategory(category);
        }

        public void RemoveCategory(int categoryId)
        {
            moderation.RemoveCategory(categoryId);
        }

        public CategoryDTO FindCategoryDTOByName(string categoryName)
        {
            Category category = moderation.FindCategoryByName(categoryName);
            return converterToDTO.ConvertToCategoryDTO(category);
        }

        public Category FindCategoryByName(string categoryName)
        {
            return moderation.FindCategoryByName(categoryName);
        }

        #endregion

        #region ForCourses

        public void CreateCourse(Course course)
        {
            moderation.CreateCourse(course);
        }

        public void UpdateCourse(Course course)
        {
            moderation.UpdateCourse(course);
        }

        public void RemoveCourse(int courseId)
        {
            moderation.RemoveCourse(courseId);
        }
        public Course GetCourse(int id)
        {
           return  moderation.GetCourse(id);
        }

        public CourseDTO FindCourseDTOByName(string courseName)
        {
            Course course = moderation.FindCourseByName(courseName);
            return converterToDTO.ConvertToCourseDTO(course);
        }

        public Course FindCourseByName(string courseName)
        {
            return moderation.FindCourseByName(courseName);
        }

        public Course FindCourseAndUpdateValues(CourseWithDecksDTO courseDTO)
        {
            Course course = moderation.GetCourse (courseDTO.Id);
            course.Name = courseDTO.Name;
            course.Linking = courseDTO.Linking;
            course.Description = courseDTO.Description;
            course.Price = courseDTO.Price;
            course.Photo = courseDTO.Photo;

            Category category = moderation.FindCategoryByName(courseDTO.CategoryName);
            course.Category = category;

            course.Decks.Clear();
            for (int i = 0; i < courseDTO.DeckNames.Length; i++)
            {
                course.Decks.Add(moderation.FindDeckByName(courseDTO.DeckNames[i]));
            }
            
            return course;
        }
        #endregion

        #region ForDecks

        public void CreateDeck(Deck deck)
        {
            moderation.CreateDeck(deck);
        }

        public void UpdateDeck(Deck deck)
        {
            moderation.UpdateDeck(deck);
        }

        public void RemoveDeck(int deckId)
        {
            moderation.RemoveDeck(deckId);
        }

        public DeckDTO FindDeckDTOByName(string deckName)
        {
            Deck deck = moderation.FindDeckByName(deckName);
            return converterToDTO.ConvertToDeckDTO(deck);
        }

        public Deck FindDeckByName(string deckName)
        {
            return moderation.FindDeckByName(deckName);
        }

        #endregion

        #region ForCards

        public void CreateCard(Card card)
        {
            moderation.CreateCard(card);
        }

        public void UpdateCard(Card card)
        {
            moderation.UpdateCard(card);
        }

        public void RemoveCard(int cardId)
        {
            moderation.RemoveCard(cardId);
        }

        public Card FindCardById(string cardId)
        {
            int id;
            int.TryParse(cardId, out id);
            if (id != 0)
            {
                return moderation.FindCardById(id);
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public CardDTO GetCardById(int cardId)
        {
            return converterToDTO.ConvertToCardDTO(moderation.GetCardById(cardId));
        }

        #endregion

        #region CardType

        public IEnumerable<CardTypeDTO> GetAllCardTypes()
        {
            var cardTypes = moderation.GetAllCardTypes();
            return converterToDTO.ConvertToCardTypeListDTO(cardTypes);
        }

        public CardType FindCardTypeByName(string cardTypeName)
        {
            return moderation.FindCardTypeByName(cardTypeName);
        }
        #endregion
    }
}
