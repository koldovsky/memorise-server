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
        IAuthRepository Auth { get; }
        ICardRepository Cards { get; }
        ICardTypeRepository CardTypes { get; }
        ICategoryRepository Categories { get; }
        ICommentRepository Comments { get; }
        ICourseRepository Courses { get; }
        IDeckRepository Decks { get; }
        IReportRepository Reports { get; }
        RoleManager<Role> Roles { get; }
        IStatisticsRepository Statistics { get; }
        ISubscribedCourseRepository SubscribedCourses { get; }
        UserRepository Users { get; }
        IUserProfileRepository UserProfiles { get; }
        ISubscribedDeckRepository SubscribedDecks { get; }

        void Save();
    }
}
