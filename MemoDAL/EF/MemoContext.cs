using System.Data.Entity;
using MemoDAL.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MemoDAL.EF
{
    public class MemoContext : IdentityDbContext<User>
    {
        public MemoContext() : base("MemoDB")
        {
            Database.SetInitializer(new MemoInitializer());
        }

        public DbSet<Answer> Answers { get; set; }

        public DbSet<Card> Cards { get; set; }

        public DbSet<CardType> CardTypes { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Deck> Decks { get; set; }

        public DbSet<Report> Reports { get; set; }

        public DbSet<Statistics> Statistics { get; set; }
        public DbSet<CourseSubscription> SubscribedCourses { get; set; }
        public DbSet<DeckSubscription> SubscribedDecks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasRequired(x => x.UserProfile)
                .WithRequiredPrincipal(x => x.User);

            base.OnModelCreating(modelBuilder);
        }
    }
}