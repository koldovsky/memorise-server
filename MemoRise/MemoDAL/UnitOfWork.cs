using System;
using MemoDAL.Repositories;
using MemoDAL.EF;
using Microsoft.AspNet.Identity.EntityFramework;
using MemoDAL.Entities;
using System.Threading.Tasks;

namespace MemoDAL
{
    public class UnitOfWork: IUnitOfWork
    {
        private MemoContext dbContext;
        public UnitOfWork(MemoContext context)
        {
            this.dbContext=context;
            Answers = new AnswerRepository(dbContext);
            Cards = new CardRepository(dbContext);
            CardTypes = new CardTypeRepository(dbContext);
            Categories = new CategoryRepository(dbContext);
            Comments = new CommentRepository(dbContext);
            Course = new CourseRepository(dbContext);
            Decks = new DeckRepository(dbContext);
            Reports = new ReportRepository(dbContext);
            Roles = new RoleRepository(new RoleStore<Role>(dbContext));
            Statistics = new StatisticRepository(dbContext);
            UserCourses = new UserCourseRepository(dbContext);
            Users = new UserRepository(new UserStore<User>(dbContext));
            UserProfiles = new UserProfileRepository(dbContext);
        }

        public AnswerRepository Answers { get; private set; }
        public CardRepository Cards { get; private set; }
        public CardTypeRepository CardTypes { get; private set; }
        public CategoryRepository Categories { get; private set; }
        public CommentRepository Comments { get; private set; }
        public CourseRepository Course { get; private set; }
        public DeckRepository Decks { get; private set; }
        public ReportRepository Reports { get; private set; }
        public RoleRepository Roles { get; private set; }
        public StatisticRepository Statistics { get; private set; }
        public UserCourseRepository UserCourses { get; private set; }
        public UserRepository Users { get; private set; }
        public UserProfileRepository UserProfiles { get; private set; }
        private bool disposed = false;

        public async Task SaveAsync()
        {
            if (this.disposed) throw new ObjectDisposedException("UnitOfWork");
            await dbContext.SaveChangesAsync();
        }

        public void Save()
        {
            if (this.disposed) throw new ObjectDisposedException("UnitOfWork");
            dbContext.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
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