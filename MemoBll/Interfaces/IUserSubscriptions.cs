using System.Collections.Generic;
using MemoDAL.Entities;

namespace MemoBll.Interfaces
{
    public interface IUserSubscriptions
    {
        IEnumerable<CourseSubscription> GetCourseSubscriptions(string userLogin);

        IEnumerable<DeckSubscription> GetDeckSubscriptions(string userLogin);

        CourseSubscription CreateCourseSubscription(string userLogin, int courseId);

        DeckSubscription CreateDeckSubscription(string userLogin, int deckId);

        CourseSubscription UpdateCourseSubscription(CourseSubscription course);

        DeckSubscription UpdateDeckSubscribtion(DeckSubscription deck);

        CourseSubscription DeleteCourseSubsription(int subscriptionId);

        DeckSubscription DeleteDeckSubscription(int subscriptionId);
    }
}