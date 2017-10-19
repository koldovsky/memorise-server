using System.Collections.Generic;
using System.Linq;
using MemoBll.Interfaces;
using MemoDAL.Entities;
using MemoDAL;
using MemoDAL.EF;
using Microsoft.AspNet.Identity;

namespace MemoBll.Logic
{
    public class UserSubscriptions: IUserSubscriptions
    {
        IUnitOfWork unitOfWork;

        public UserSubscriptions()
        {
            this.unitOfWork = new UnitOfWork(new MemoContext());
        }

        public UserSubscriptions(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        //public IEnumerable<Course> GetSubscribedCourses(string userName)
        //{
        //    return unitOfWork.SubscribedCourses.GetAll()
        //        .Where(subscription => subscription.User.UserName == userName)
        //        .Select(subscription => subscription.Course);
        //}

        //public IEnumerable<Deck> GetSubscribedDecks(string userName)
        //{
        //    return unitOfWork.SubscribedDecks.GetAll()
        //        .Where(subscription => subscription.User.UserName == userName)
        //        .Select(subscription => subscription.Deck);
        //}

        public IEnumerable<SubscribedCourse> GetCoursesSubscriptions(string userName)
        {
            return unitOfWork.SubscribedCourses.GetAll()
                .Where(subscription => subscription.User.UserName == userName);
        }

        public IEnumerable<SubscribedDeck> GetDecksSubscriptions(string userName)
        {
            return unitOfWork.SubscribedDecks.GetAll()
                .Where(subscription => subscription.User.UserName == userName);
        }

        public void CreateCourseSubscription(string userName, int courseId)
        {
            unitOfWork.SubscribedCourses.Create(new SubscribedCourse
            {
                Rating = -1,
                User = unitOfWork.Users.FindByName(userName),
                Course = unitOfWork.Courses.Get(courseId)
            });
            unitOfWork.Save();
        }

        public void CreateDeckSubscription(string userName, int deckId)
        {
            unitOfWork.SubscribedDecks.Create(new SubscribedDeck
            {
                Rating = -1,
                User = unitOfWork.Users.FindByName(userName),
                Deck = unitOfWork.Decks.Get(deckId)
            });
            unitOfWork.Save();
        }

        public void UpdateCourseSubscription(SubscribedCourse course)
        {
            unitOfWork.SubscribedCourses.Update(course);
            unitOfWork.Save();
        }

        public void UpdateDeckSubscribtion(SubscribedDeck deck)
        {
            unitOfWork.SubscribedDecks.Update(deck);
            unitOfWork.Save();
        }

        public void DeleteCourseSubsription(int subscriptionId)
        {
            unitOfWork.SubscribedCourses.Delete(subscriptionId);
            unitOfWork.Save();
        }

        public void DeleteDeckSubscription(int subscriptionId)
        {
            unitOfWork.SubscribedDecks.Delete(subscriptionId);
            unitOfWork.Save();
        }
    }
}
