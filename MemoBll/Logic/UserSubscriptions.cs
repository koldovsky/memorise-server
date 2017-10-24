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
    public class UserSubscriptions : IUserSubscriptions
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

        public IEnumerable<CourseSubscription> GetCourseSubscriptions(
            string userLogin)
        {
            return unitOfWork.CourseSubscriptions.GetAll()
                .Where(subscription => subscription.User.UserName == userLogin);
        }

        public IEnumerable<DeckSubscription> GetDeckSubscriptions(
            string userLogin)
        {
            return unitOfWork.DeckSubscriptions.GetAll()
                .Where(subscription => subscription.User.UserName == userLogin);
        }

        public CourseSubscription CreateCourseSubscription(string userLogin, int courseId)
        {
            var subscription = unitOfWork.CourseSubscriptions.GetAll()
                .FirstOrDefault(x => x.User.UserName == userLogin
                && x.CourseId == courseId);
            if (subscription == null)
            {
                var course = unitOfWork.Courses.Get(courseId);
                //var decks = course
                //    ?.Decks.ToList()
                //    ?? throw new ArgumentNullException();
                subscription = new CourseSubscription
                {
                    Rating = -1,
                    User = unitOfWork.Users.FindByName(userLogin),
                    Course = course
                };
                unitOfWork.CourseSubscriptions.Create(subscription);
                //decks.ForEach(deck =>
                //{
                //    CreateDeckSubscription(userLogin, deck.Id);
                //});
                unitOfWork.Save();
            }

            return subscription;
        }

        public DeckSubscription CreateDeckSubscription(string userLogin, int deckId)
        {
            var subscription = unitOfWork.DeckSubscriptions.GetAll()
                .FirstOrDefault(x => x.User.UserName == userLogin
                                     && x.DeckId == deckId);
            if (subscription == null)
            {
                subscription = new DeckSubscription
                {
                    Rating = -1,
                    User = unitOfWork.Users.FindByName(userLogin),
                    Deck = unitOfWork.Decks.Get(deckId)
                };
                unitOfWork.DeckSubscriptions.Create(subscription);
                unitOfWork.Save();
            }

            return subscription;
        }

        public CourseSubscription UpdateCourseSubscription(CourseSubscription subscription)
        {
            unitOfWork.CourseSubscriptions.Update(subscription);
            unitOfWork.Save();

            return subscription;
        }

        public DeckSubscription UpdateDeckSubscribtion(DeckSubscription subscription)
        {
            unitOfWork.DeckSubscriptions.Update(subscription);
            unitOfWork.Save();

            return subscription;
        }

        public CourseSubscription DeleteCourseSubsription(int subscriptionId)
        {
            var subscription = unitOfWork.CourseSubscriptions.Get(subscriptionId);
            unitOfWork.CourseSubscriptions.Delete(subscriptionId);
            unitOfWork.Save();

            return subscription;
        }

        public DeckSubscription DeleteDeckSubscription(int subscriptionId)
        {
            var subscription = unitOfWork.DeckSubscriptions.Get(subscriptionId);
            unitOfWork.DeckSubscriptions.Delete(subscriptionId);
            unitOfWork.Save();

            return subscription;
        }
    }
}
