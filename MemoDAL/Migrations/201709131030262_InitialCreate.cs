namespace MemoDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        IsCorrect = c.Boolean(nullable: false),
                        Card_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cards", t => t.Card_Id)
                .Index(t => t.Card_Id);
            
            CreateTable(
                "dbo.Cards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Question = c.String(),
                        CardType_Id = c.Int(),
                        Deck_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CardTypes", t => t.CardType_Id)
                .ForeignKey("dbo.Decks", t => t.Deck_Id)
                .Index(t => t.CardType_Id)
                .Index(t => t.Deck_Id);
            
            CreateTable(
                "dbo.CardTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        Card_Id = c.Int(),
                        Course_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cards", t => t.Card_Id)
                .ForeignKey("dbo.Courses", t => t.Course_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Card_Id)
                .Index(t => t.Course_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.Int(nullable: false),
                        Photo = c.String(),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Decks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Int(nullable: false),
                        Photo = c.String(),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Password = c.String(),
                        Photo = c.String(),
                        Email = c.String(),
                        IsBlocked = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Reason = c.String(),
                        Description = c.String(),
                        Date = c.DateTime(nullable: false),
                        Sender_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Sender_Id)
                .Index(t => t.Sender_Id);
            
            CreateTable(
                "dbo.DeckCourses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Course_Id = c.Int(),
                        Deck_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.Course_Id)
                .ForeignKey("dbo.Decks", t => t.Deck_Id)
                .Index(t => t.Course_Id)
                .Index(t => t.Deck_Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Statistics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SuccessPercent = c.Int(nullable: false),
                        Deck_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Decks", t => t.Deck_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Deck_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.UserCourses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rating = c.Int(nullable: false),
                        Course_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.Course_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Course_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Role_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.Role_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Role_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRoles", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "Role_Id", "dbo.Roles");
            DropForeignKey("dbo.UserCourses", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserCourses", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.Statistics", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Statistics", "Deck_Id", "dbo.Decks");
            DropForeignKey("dbo.DeckCourses", "Deck_Id", "dbo.Decks");
            DropForeignKey("dbo.DeckCourses", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.Reports", "Sender_Id", "dbo.Users");
            DropForeignKey("dbo.Comments", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Comments", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.Decks", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Cards", "Deck_Id", "dbo.Decks");
            DropForeignKey("dbo.Courses", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Comments", "Card_Id", "dbo.Cards");
            DropForeignKey("dbo.Cards", "CardType_Id", "dbo.CardTypes");
            DropForeignKey("dbo.Answers", "Card_Id", "dbo.Cards");
            DropIndex("dbo.UserRoles", new[] { "User_Id" });
            DropIndex("dbo.UserRoles", new[] { "Role_Id" });
            DropIndex("dbo.UserCourses", new[] { "User_Id" });
            DropIndex("dbo.UserCourses", new[] { "Course_Id" });
            DropIndex("dbo.Statistics", new[] { "User_Id" });
            DropIndex("dbo.Statistics", new[] { "Deck_Id" });
            DropIndex("dbo.DeckCourses", new[] { "Deck_Id" });
            DropIndex("dbo.DeckCourses", new[] { "Course_Id" });
            DropIndex("dbo.Reports", new[] { "Sender_Id" });
            DropIndex("dbo.Decks", new[] { "Category_Id" });
            DropIndex("dbo.Courses", new[] { "Category_Id" });
            DropIndex("dbo.Comments", new[] { "User_Id" });
            DropIndex("dbo.Comments", new[] { "Course_Id" });
            DropIndex("dbo.Comments", new[] { "Card_Id" });
            DropIndex("dbo.Cards", new[] { "Deck_Id" });
            DropIndex("dbo.Cards", new[] { "CardType_Id" });
            DropIndex("dbo.Answers", new[] { "Card_Id" });
            DropTable("dbo.UserRoles");
            DropTable("dbo.UserCourses");
            DropTable("dbo.Statistics");
            DropTable("dbo.Roles");
            DropTable("dbo.DeckCourses");
            DropTable("dbo.Reports");
            DropTable("dbo.Users");
            DropTable("dbo.Decks");
            DropTable("dbo.Categories");
            DropTable("dbo.Courses");
            DropTable("dbo.Comments");
            DropTable("dbo.CardTypes");
            DropTable("dbo.Cards");
            DropTable("dbo.Answers");
        }
    }
}
