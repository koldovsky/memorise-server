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
            userSubscriptions = new UserSubscriptions(uow);
            converterToDto = new ConverterToDTO();
            converterFromDto = new ConverterFromDTO(uow);
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

        public IEnumerable<CourseDTO> GetSubscribedCourses(string userLogin)
        {
            var courses = userSubscriptions.GetCourseSubscriptions(userLogin)
                .Select(x => x.Course);
            return courses.Select(x => converterToDto.ConvertToCourseDTO(x));
        }

        public IEnumerable<DeckDTO> GetSubscribedDecks(string userLogin)
        {
            var decks = userSubscriptions.GetDeckSubscriptions(userLogin)
                .Select(x => x.Deck);
            return decks.Select(x => converterToDto.ConvertToDeckDTO(x));
        }

        public IEnumerable<CourseSubscriptionDTO> GetCourseSubscriptions(
            string userLogin)
        {
            var subscriptions = userSubscriptions.GetCourseSubscriptions(userLogin);
            return subscriptions
                .Select(x => converterToDto.ConvertToCourseSubscriptionDTO(x));
        }

        public IEnumerable<DeckSubscriptionDTO> GetDeckSubscriptions(
            string userLogin)
        {
            var subscriptions = userSubscriptions
                .GetDeckSubscriptions(userLogin);
            return subscriptions
                .Select(x => converterToDto.ConvertToDeckSubscriptionDTO(x));
        }

        public CourseSubscriptionDTO CreateCourseSubscription(
            string userLogin, 
            int courseId)
        {
            var subscription = userSubscriptions
                .CreateCourseSubscription(userLogin, courseId);
            return converterToDto.ConvertToCourseSubscriptionDTO(subscription);
        }

        public DeckSubscriptionDTO CreateDeckSubscription(
            string userLogin, 
            int deckId)
        {
            var subscription = userSubscriptions
                .CreateDeckSubscription(userLogin, deckId);

            return converterToDto.ConvertToDeckSubscriptionDTO(subscription);
        }

        public CourseSubscriptionDTO UpdateCourseSubscription(
            CourseSubscriptionDTO courseSubscription)
        {
            var subscription = converterFromDto
                .ConvertToCourseSubscription(courseSubscription);
            subscription = userSubscriptions
                .UpdateCourseSubscription(subscription);

            return converterToDto.ConvertToCourseSubscriptionDTO(subscription);
        }

        public DeckSubscriptionDTO UpdateDeckSubscribtion(
            DeckSubscriptionDTO deckSubscription)
        {
            var subscription = converterFromDto
                .ConvertToDeckSubscription(deckSubscription);
            subscription = userSubscriptions
                .UpdateDeckSubscribtion(subscription);

            return converterToDto.ConvertToDeckSubscriptionDTO(subscription);
        }

        public CourseSubscriptionDTO DeleteCourseSubsription(int subscriptionId)
        {
            var subscription = userSubscriptions
                .DeleteCourseSubsription(subscriptionId);

            return converterToDto.ConvertToCourseSubscriptionDTO(subscription);
        }

        public DeckSubscriptionDTO DeleteDeckSubscription(int subscriptionId)
        {
            var subscription = userSubscriptions
                .DeleteDeckSubscription(subscriptionId);

            return converterToDto.ConvertToDeckSubscriptionDTO(subscription);
        }
    }
}
