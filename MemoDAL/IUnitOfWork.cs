using System;
using MemoDAL.Repositories.Interfaces;
using Microsoft.AspNet.Identity;
using MemoDAL.Entities;
using MemoDAL.Repositories;

namespace MemoDAL
{
    public interface IUnitOfWork : IDisposable
    {
        IAnswerRepository Answers { get; }
        ICardRepository Cards { get; }
        ICardTypeRepository CardTypes { get; }
        ICategoryRepository Categories { get; }
        ICommentRepository Comments { get; }
        ICourseRepository Courses { get; }
        IDeckRepository Decks { get; }
        IReportRepository Reports { get; }
        RoleManager<Role> Roles { get; }
        IStatisticsRepository Statistics { get; }
        ICourseSubscriptionRepository CourseSubscriptions { get; }
        UserRepository Users { get; }
        IUserProfileRepository UserProfiles { get; }
        IDeckSubscriptionRepository DeckSubscriptions { get; }

        void Save();
    }
}
