using MemoDAL.Repositories.Interfaces;
using System;

namespace MemoDAL
{
	public interface IUnitOfWork: IDisposable
    {
		IAnswerRepository Answers { get; }
		ICardRepository Cards { get; }
		ICardTypeRepository CardTypes { get; }
		ICategoryRepository Categories { get; }
		ICommentRepository Comments { get; }
		ICourseRepository Courses { get; }
		IDeckRepository Decks { get; }
		IReportRepository Reports { get; }
		IRoleRepository Roles { get; }
		IStatisticsRepository Statistics { get; }
		IUserCourseRepository UserCourses { get; }
		IUserRepository Users { get; }

		void Save();
	}
}
