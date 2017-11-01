using MemoDAL.EF;
using MemoDAL.Entities;
using MemoDAL.Repositories;
using MemoDAL.Repositories.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace MemoDAL
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Fields

        private MemoContext databaseContext;
        private IAnswerRepository answers;
        private ICardRepository cards;
        private ICardTypeRepository cardTypes;
        private ICategoryRepository categories;
        private ICommentRepository comments;
        private ICourseRepository courses;
        private IDeckRepository decks;
        private IReportRepository reports;
        private RoleManager<Role> roles;
        private IStatisticsRepository statistics;
        private ICourseSubscriptionRepository courseSubscriptions;
        private UserRepository users;
        private IDeckSubscriptionRepository deckSubscriptions;
        private IUserProfileRepository userProfiles;
        private bool disposed = false;

        #endregion

        public UnitOfWork(MemoContext context)
        {
            this.databaseContext = context;
            this.answers = new AnswerRepository(databaseContext);
            this.cards = new CardRepository(databaseContext);
            this.cardTypes = new CardTypeRepository(databaseContext);
            this.categories = new CategoryRepository(databaseContext);
            this.comments = new CommentRepository(databaseContext);
            this.courses = new CourseRepository(databaseContext);
            this.decks = new DeckRepository(databaseContext);
            this.reports = new ReportRepository(databaseContext);
            this.roles = new RoleRepository(new RoleStore<Role>(databaseContext));
            this.statistics = new StatisticsRepository(databaseContext);
            this.courseSubscriptions = new CourseSubscriptionsRepository(databaseContext);
            this.users = new UserRepository(new UserStore<User>(databaseContext));
            this.deckSubscriptions = new DeckSubscriptionsRepository(databaseContext);
            this.userProfiles = new UserProfileRepository(databaseContext);
        }

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

        public RoleManager<Role> Roles
        {
            get { return roles; }
        }

        public IStatisticsRepository Statistics
        {
            get { return statistics; }
        }

        public ICourseSubscriptionRepository CourseSubscriptions
        {
            get { return courseSubscriptions; }
        }

        public UserRepository Users
        {
            get { return users; }
        }

        public IUserProfileRepository UserProfiles
        {
            get { return userProfiles; }
        }

        public IDeckSubscriptionRepository DeckSubscriptions
        {
            get { return deckSubscriptions; }
        }

        #endregion

        public void Save()
        {
            databaseContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    databaseContext.Dispose();
                }

                this.disposed = true;
            }
        }
    }
}