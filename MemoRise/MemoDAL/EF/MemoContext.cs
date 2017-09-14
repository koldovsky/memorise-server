using System.Data.Entity;
using MemoDAL.Entities;

namespace MemoDAL.EF
{
    public class MemoContext:DbContext
    {
        public MemoContext() : base("MemoDB") {

           Database.SetInitializer<MemoContext>(new MemoInitializer());
        }

        public DbSet<Answer> Answers { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<CardType> CardTypes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Deck> Decks { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Role> Roles{ get; set; }
        public DbSet<Statistic> Statistics { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserCourse> UserCourses { get; set; }
        
    }
}