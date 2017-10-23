using System.Collections.Generic;
using System.Linq;
using MemoBll.Interfaces;
using MemoBll.Logic;
using MemoDAL;
using MemoDAL.EF;
using MemoDTO;

namespace MemoBll.Managers
{
    public class UserSubscriptionsBll
    {
        IUserSubscriptions userSubscriptions;
        IConverterToDto converterToDto;
        private IConverterFromDto converterFromDto;

        public UserSubscriptionsBll()
        {
            var uow = new UnitOfWork(new MemoContext());
            this.userSubscriptions = new UserSubscriptions(uow);
            this.converterToDto = new ConverterToDto();
            this.converterFromDto = new ConverterFromDto(uow);
        }

        public UserSubscriptionsBll(
            IUserSubscriptions userSubscriptions,
            IConverterToDto converterToDto,
            IConverterFromDto converterFromDto)
        {
            this.userSubscriptions = userSubscriptions;
            this.converterToDto = converterToDto;
            this.converterFromDto = converterFromDto;
        }

        public IEnumerable<CourseDTO> GetSubscribedCourses(string userName)
        {
            var courses = userSubscriptions.GetCoursesSubscriptions(userName)
                .Select(x => x.Course);
            return courses.Select(x => converterToDto.ConvertToCourseDto(x));
        }

        public IEnumerable<DeckDTO> GetSubscribedDecks(string userName)
        {
            var decks = userSubscriptions.GetDecksSubscriptions(userName)
                .Select(x => x.Deck);
            return decks.Select(x => converterToDto.ConvertToDeckDto(x));
        }

        public IEnumerable<SubscribedCourseDTO> GetCoursesSubscriptions(string userName)
        {
            var subscriptions = userSubscriptions.GetCoursesSubscriptions(userName);
            return subscriptions
                .Select(x => converterToDto.ConvertToSubscribedCourseDto(x));
        }

        public IEnumerable<SubscribedDeckDTO> GetDecksSubscriptions(string userName)
        {
            var subscriptions = userSubscriptions.GetDecksSubscriptions(userName);
            return subscriptions
                .Select(x => converterToDto.ConvertToSubscribedDeckDto(x));
        }

        public void CreateCourseSubscription(string userName, int courseId)
        {
            userSubscriptions.CreateCourseSubscription(userName, courseId);
        }

        public void CreateDeckSubscription(string userName, int deckId)
        {
            userSubscriptions.CreateDeckSubscription(userName, deckId);
        }

        public void UpdateCourseSubscription(SubscribedCourseDTO subscribedCourse)
        {
            var subscription = converterFromDto
                .ConvertToSubscribedCourse(subscribedCourse);
            userSubscriptions.UpdateCourseSubscription(subscription);
        }

        public void UpdateDeckSubscribtion(SubscribedDeckDTO subscribedDeck)
        {
            var subscription = converterFromDto
                .ConvertToSubscribedDeck(subscribedDeck);
            userSubscriptions.UpdateDeckSubscribtion(subscription);
        }

        public void DeleteCourseSubsription(int subscriptionId)
        {
            userSubscriptions.DeleteCourseSubsription(subscriptionId);
        }

        public void DeleteDeckSubscription(int subscriptionId)
        {
            userSubscriptions.DeleteDeckSubscription(subscriptionId);
        }
    }
}
