using System.Collections.Generic;
using MemoDAL.Entities;

namespace MemoBll.Interfaces
{
    public interface IUserSubscriptions
    {
        ////IEnumerable<Course> GetSubscribedCourses(string userName);
        ////IEnumerable<Deck> GetSubscribedDecks(string userName);
        IEnumerable<SubscribedCourse> GetCoursesSubscriptions(string userName);

        IEnumerable<SubscribedDeck> GetDecksSubscriptions(string userName);

        void CreateCourseSubscription(string userName, int courseId);

        void CreateDeckSubscription(string userName, int deckId);

        void UpdateCourseSubscription(SubscribedCourse course);

        void UpdateDeckSubscribtion(SubscribedDeck deck);

        void DeleteCourseSubsription(int subscriptionId);

        void DeleteDeckSubscription(int subscriptionId);
    }
}