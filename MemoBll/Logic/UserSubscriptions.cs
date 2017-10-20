using System;
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

        public IEnumerable<CourseSubscription> GetCourseSubscriptions(
            string userName)
        {
            return unitOfWork.CourseSubscriptions.GetAll()
                .Where(subscription => subscription.User.UserName == userName);
        }

        public IEnumerable<DeckSubscription> GetDeckSubscriptions(
            string userName)
        {
            return unitOfWork.DeckSubscriptions.GetAll()
                .Where(subscription => subscription.User.UserName == userName);
        }

        public void CreateCourseSubscription(string userName, int courseId)
        {
            var user = unitOfWork.Users.FindByName(userName);
            var course = unitOfWork.Courses.Get(courseId);
            var decks = course
                ?.Decks.ToList()
                ?? throw new ArgumentNullException();
            unitOfWork.CourseSubscriptions.Create(new CourseSubscription
            {
                Rating = -1,
                User = user,
                Course = course
            });
            decks.ForEach(deck => unitOfWork.DeckSubscriptions
                .Create(new DeckSubscription
            {
                Rating = -1,
                User = user,
                Deck = deck
            }));
            unitOfWork.Save();
        }

        public void CreateDeckSubscription(string userName, int deckId)
        {
            unitOfWork.DeckSubscriptions.Create(new DeckSubscription
            {
                Rating = -1,
                User = unitOfWork.Users.FindByName(userName),
                Deck = unitOfWork.Decks.Get(deckId)
            });
            unitOfWork.Save();
        }

        public void UpdateCourseSubscription(CourseSubscription course)
        {
            unitOfWork.CourseSubscriptions.Update(course);
            unitOfWork.Save();
        }

        public void UpdateDeckSubscribtion(DeckSubscription deck)
        {
            unitOfWork.DeckSubscriptions.Update(deck);
            unitOfWork.Save();
        }

        public void DeleteCourseSubsription(int subscriptionId)
        {
            unitOfWork.CourseSubscriptions.Delete(subscriptionId);
            unitOfWork.Save();
        }

        public void DeleteDeckSubscription(int subscriptionId)
        {
            unitOfWork.DeckSubscriptions.Delete(subscriptionId);
            unitOfWork.Save();
        }
    }
}
