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
        IConverterToDTO converterToDto;
        private IConverterFromDTO converterFromDto;

        public UserSubscriptionsBll()
        {
            var uow = new UnitOfWork(new MemoContext());
            this.userSubscriptions = new UserSubscriptions(uow);
            this.converterToDto = new ConverterToDTO();
            this.converterFromDto = new ConverterFromDTO(uow);
        }

        public UserSubscriptionsBll(
            IUserSubscriptions userSubscriptions,
            IConverterToDTO converterToDto,
            IConverterFromDTO converterFromDto)
        {
            this.userSubscriptions = userSubscriptions;
            this.converterToDto = converterToDto;
            this.converterFromDto = converterFromDto;
        }

        public IEnumerable<CourseDTO> GetSubscribedCourses(string userName)
        {
            var courses = userSubscriptions.GetCourseSubscriptions(userName)
                .Select(x => x.Course);
            return courses.Select(x => converterToDto.ConvertToCourseDTO(x));
        }

        public IEnumerable<DeckDTO> GetSubscribedDecks(string userName)
        {
            var decks = userSubscriptions.GetDeckSubscriptions(userName)
                .Select(x => x.Deck);
            return decks.Select(x => converterToDto.ConvertToDeckDTO(x));
        }

        public IEnumerable<CourseSubscriptionDTO> GetCourseSubscriptions(string userName)
        {
            var subscriptions = userSubscriptions.GetCourseSubscriptions(userName);
            return subscriptions
                .Select(x => converterToDto.ConvertToSubscribedCourseDTO(x));
        }

        public IEnumerable<DeckSubscriptionDTO> GetDeckSubscriptions(string userName)
        {
            var subscriptions = userSubscriptions.GetDeckSubscriptions(userName);
            return subscriptions
                .Select(x => converterToDto.ConvertToSubscribedDeckDTO(x));
        }

        public void CreateCourseSubscription(string userName, int courseId)
        {
            userSubscriptions.CreateCourseSubscription(userName, courseId);
        }

        public void CreateDeckSubscription(string userName, int deckId)
        {
            userSubscriptions.CreateDeckSubscription(userName, deckId);
        }

        public void UpdateCourseSubscription(CourseSubscriptionDTO courseSubscription)
        {
            var subscription = converterFromDto
                .ConvertToCourseSubscription(courseSubscription);
            userSubscriptions.UpdateCourseSubscription(subscription);
        }

        public void UpdateDeckSubscribtion(DeckSubscriptionDTO deckSubscription)
        {
            var subscription = converterFromDto
                .ConvertToDeckSubscription(deckSubscription);
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
