using System.Collections.Generic;
using MemoDAL.Entities;

namespace MemoBll.Interfaces
{
    public interface IUserSubscriptions
    {
        //IEnumerable<Course> GetSubscribedCourses(string userName);
        //IEnumerable<Deck> GetSubscribedDecks(string userName);
        IEnumerable<CourseSubscription> GetCourseSubscriptions(string userName);
        IEnumerable<DeckSubscription> GetDeckSubscriptions(string userName);
        void CreateCourseSubscription(string userName, int courseId);
        void CreateDeckSubscription(string userName, int deckId);
        void UpdateCourseSubscription(CourseSubscription course);
        void UpdateDeckSubscribtion(DeckSubscription deck);
        void DeleteCourseSubsription(int subscriptionId);
        void DeleteDeckSubscription(int subscriptionId);
    }
}
