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
        IUserCourseRepository UserCourses { get; }
        UserRepository Users { get; }

        void Save();
    }
}
