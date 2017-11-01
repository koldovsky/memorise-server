using MemoDAL.Entities;
using System;
using System.Collections.Generic;

namespace MemoBll.Interfaces
{
	public interface IModeration
    {
        int GetReportCountForReason(string reason);

        IEnumerable<Report> GetAllReportsOnReason(string reason);

        IEnumerable<Report> GetAllReportsOnDate(DateTime date);

        IEnumerable<Report> GetAllReportsFromDate(DateTime date);

        Report GetReport(int reportId);

        IEnumerable<Statistics> GetDeckStatistics(int deckId);

        Statistics GetStatistics(string deckName, int userId);

        void DeleteStatistics(int statisticsId);

        IEnumerable<User> GetAllUsersByCourse(int courseId);

        IEnumerable<User> GetAllUsersByDeck(int deckId);

        Answer CreateAnswer(Answer answer);

        Answer GetAnswer(int id);

        void UpdateAnswer(Answer answer);

        void RemoveAnswer(int answerId);

        void CreateCategory(Category category);

        void UpdateCategory(Category category);

        void RemoveCategory(int categoryId);

        Category GetCategory(int id);

        Category FindCategoryByName(string categoryName);

        Category FindCategoryByLinking(string categoryLinking);

        void CreateCourse(Course course);

        void UpdateCourse(Course course);

        void RemoveCourse(int courseId);

        Course GetCourse(int id);

        Course FindCourseByName(string courseName);

        void CreateDeck(Deck deck);

        void UpdateDeck(Deck deck);

        void RemoveDeck(int deckId);

        Deck GetDeck(int id);

        Deck FindDeckByName(string deckName);

        void CreateCard(Card card);

        void UpdateCard(Card card);

        void RemoveCard(int cardId);

        Card FindCardById(int cardId);

        Card GetCardById(int cardId);

        IEnumerable<CardType> GetAllCardTypes();

        CardType FindCardTypeByName(string cardTypeName);
    }
}
