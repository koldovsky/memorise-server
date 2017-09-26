using System;
using MemoDAL.Repositories;
using MemoDAL.EF;
using MemoDAL.Repositories.Interfaces;

namespace MemoDAL
{
	public class UnitOfWork : IUnitOfWork
	{
		public UnitOfWork(MemoContext context)
		{
			this.dbContext = context;
			this.answers = new AnswerRepository(dbContext);
			this.cards = new CardRepository(dbContext);
			this.cardTypes = new CardTypeRepository(dbContext);
			this.categories = new CategoryRepository(dbContext);
			this.comments = new CommentRepository(dbContext);
			this.courses = new CourseRepository(dbContext);
			this.decks = new DeckRepository(dbContext);
			this.reports = new ReportRepository(dbContext);
			this.roles = new RoleRepository(dbContext);
			this.statistics = new StatisticsRepository(dbContext);
			this.userCourses = new UserCourseRepository(dbContext);
			this.users = new UserRepository(dbContext);
		}

		#region Fields

		private MemoContext dbContext;
		private IAnswerRepository answers;
		private ICardRepository cards;
		private ICardTypeRepository cardTypes;
		private ICategoryRepository categories;
		private ICommentRepository comments;
		private ICourseRepository courses;
		private IDeckRepository decks;
		private IReportRepository reports;
		private IRoleRepository roles;
		private IStatisticsRepository statistics;
		private IUserCourseRepository userCourses;
		private IUserRepository users;
		private bool disposed = false;

		#endregion

		#region Properties

		public IAnswerRepository Answers
		{
			get { return answers; }
		}

		public ICardRepository Cards
		{
			get { return cards; }
		}

		public ICardTypeRepository CardTypes
		{
			get { return cardTypes; }
		}

		public ICategoryRepository Categories
		{
			get { return categories; }
		}

		public ICommentRepository Comments
		{
			get { return comments; }
		}

		public ICourseRepository Courses
		{
			get { return courses; }
		}

		public IDeckRepository Decks
		{
			get { return decks; }
		}

		public IReportRepository Reports
		{
			get { return reports; }
		}

		public IRoleRepository Roles
		{
			get { return roles; }
		}

		public IStatisticsRepository Statistics
		{
			get { return statistics; }
		}

		public IUserCourseRepository UserCourses
		{
			get { return userCourses; }
		}

		public IUserRepository Users
		{
			get { return users; }
		}

		#endregion

		public void Save()
		{
			dbContext.SaveChanges();
		}

		public virtual void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				if (disposing)
				{
					dbContext.Dispose();
				}
				this.disposed = true;
			}
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}