using System.Collections.Generic;
using System.Data.Entity;
using MemoDAL.Entities;

namespace MemoDAL.EF
{
    public class MemoInitializer : DropCreateDatabaseIfModelChanges<MemoContext>
    {
        protected override void Seed(MemoContext context)
        {
            ////ROLE
            //IList<Role> roles = new List<Role>()
            //{
            //    new Role {Name="Admin"},
            //    new Role {Name="Moderator"},
            //    new Role {Name="Guest"},
            //    new Role {Name="Customer"}
            //};
            //foreach (var role in roles)
            //{
            //    context.Roles.Add(role);
            //}
            ////USER
            //IList<User> users = new List<User>()
            //{
            //    new User{Login="user1",Password="1",Email="user1@gmail",IsBlocked=false},
            //    new User{Login="user2",Password="2",Email="user2@gmail",IsBlocked=false},
            //    new User{Login="user3",Password="3",Email="user3@gmail",IsBlocked=false},
            //    new User{Login="user4",Password="4",Email="user4@gmail",IsBlocked=false}
            //};
            //for (int i = 0; i < users.Count; i++)
            //{
            //    users[i].Roles.Add(roles[i]);
            //}
            //foreach (var user in users)
            //{
            //    context.Users.Add(user);
            //}

            //CATEGORY
            IList<Category> categories = new List<Category>()
            {
                new Category{Name=".Net", Linking="_Net"},
                new Category{Name="Java", Linking="Java"},
                new Category{Name="JavaScript", Linking="JavaScript"},
                new Category{Name="Python", Linking="Python"},
                new Category{Name="Ruby", Linking="Ruby"}
            };
            foreach (var cat in categories)
            {
                context.Categories.Add(cat);
            }

            //DECK
            IList<Deck> decks = new List<Deck>()
            {
                new Deck{Name="Arrays", Linking="Arrays", Price=0, Category=categories[0]},
                new Deck{Name="Generics",Linking="Generics", Price=0, Category=categories[0]},
                new Deck{Name="Threads",Linking="Threads",Price=0,Category=categories[0]},
                new Deck{Name="LINQ",Linking="LINQ",Price=0,Category=categories[0]},
                new Deck{Name="Database First",Linking="Database_First",Price=0,Category=categories[0]},
                new Deck{Name="Model First",Linking="Model_First",Price=0,Category=categories[0]},
                new Deck{Name="Code First",Linking="Code_First",Price=0,Category=categories[0]},
                new Deck{Name="Web API",Linking="Web_API",Price=0,Category=categories[0]},
                new Deck{Name="IIS",Linking="IIS",Price=0,Category=categories[0]},
                new Deck{Name="Routing",Linking="Routing",Price=0,Category=categories[0]},
                new Deck{Name="XAML",Linking="XAML",Price=0,Category=categories[0]},
                new Deck{Name="Binding",Linking="Binding",Price=0,Category=categories[0]},
                new Deck{Name="CSS", Linking="CSS", Price=0, Category=categories[2]}
            };
            foreach (var deck in decks)
            {
                context.Decks.Add(deck);
            }

            //COURSE
            IList<Course> courses = new List<Course>()
            {
                new Course{Name="C#", Linking="cSharp", Description="C# course description",Price=0,Category=categories[0]},
                new Course{Name="ASP.MVC", Linking="ASP_MVC", Description="ASP.MVC course description",Price=0,Category=categories[0]},
                new Course{Name="EntityFramework",Linking="EF", Description="EntityFramework course description",Price=100,Category=categories[0]},
                new Course{Name="WPF", Linking="WPF", Description="WPF course description",Price=0,Category=categories[0]},
                new Course{Name="JQUERY", Linking="JQ", Description="JQUERY course description", Price=0, Category=categories[2]}
            };
            for (int i = 0; i < 4; i++)
            {
                courses[0].Decks.Add(decks[i]);
            }
            for (int i = 4; i < 7; i++)
            {
                courses[1].Decks.Add(decks[i]);
            }
            for (int i = 7; i < 10; i++)
            {
                courses[2].Decks.Add(decks[i]);
            }
            for (int i = 10; i < 12; i++)
            {
                courses[3].Decks.Add(decks[i]);
            }
            for (int i = 12; i <= 12; i++)
            {
                courses[4].Decks.Add(decks[i]);
            }
            foreach (var course in courses)
            {
                context.Courses.Add(course);
            }
            ////USERCOURSE
            //context.UserCourses.Add(new UserCourse { User = users[0], Course = courses[0], Rating = 4 });
            //CARDTYPE
            IList<CardType> cardTypes = new List<CardType>()
            {
                new CardType{Name="CardType1"},
                new CardType{Name="CardType2"},
                new CardType{Name="CardType3"},
                new CardType{Name="CardType4"},
            };
            foreach (var cardType in cardTypes)
            {
                context.CardTypes.Add(cardType);
            }
            //CARD
            IList<Card> cards = new List<Card>()
            {
                new Card{Question="Which of the following statements are correct about the C#.NET code snippet given below?  \n int[ , , ] a = new int[ 3, 2, 3 ]; \n Console.WriteLine(a.Length); ",Deck=decks[0],CardType=cardTypes[0]},
                new Card{Question="Which of the following statements are correct about the C#.NET code snippet given below?  \n int[][][] intMyArr = new int[2][][];",Deck=decks[0],CardType=cardTypes[1]},
                new Card{Question="Which one of the following statements is correct?",Deck=decks[0],CardType=cardTypes[2]}
                
            };
            foreach (var card in cards)
            {
                context.Cards.Add(card);
            }

            //ANSWER
            IList<Answer> answers = new List<Answer>()
            {
                new Answer{Text="18",IsCorrect=true,Card=cards[0]},
                new Answer{Text="4",IsCorrect=false,Card=cards[0]},
                new Answer{Text="20",IsCorrect=false,Card=cards[0]},
                new Answer{Text="10",IsCorrect=false,Card=cards[0]},
                new Answer{Text="intMyArr refers to a 2-D jagged array containing 2 rows.",IsCorrect=false,Card=cards[1]},
                new Answer{Text="intMyArr refers to a 2-D jagged array containing 3 rows.",IsCorrect=false,Card=cards[1]},
                new Answer{Text="intMyArr refers to a 3-D jagged array containing 2 2-D jagged arrays.",IsCorrect=true,Card=cards[1]},
                new Answer{Text="intMyArr refers to a 3-D jagged array containing three 2-D jagged arrays.",IsCorrect=false,Card=cards[1]},
                new Answer{Text="intMyArr refers to a 3-D jagged array containing 2 2-D rectangular arrays.",IsCorrect=false,Card=cards[1]},
                new Answer{Text="Array elements can be of integer type only",IsCorrect=false,Card=cards[2]},
                new Answer{Text="The rank of an Array is the total number of elements it can contain.",IsCorrect=false,Card=cards[2]},
                new Answer{Text="The length of an Array is the number of dimensions in the Array.",IsCorrect=false,Card=cards[2]},
                new Answer{Text="The Array elements are guaranteed to be sorted.",IsCorrect=false,Card=cards[2]},
                new Answer{Text="The default value of numeric array elements is zero.",IsCorrect=true,Card=cards[2]}

            };
            foreach (var answ in answers)
            {
                context.Answers.Add(answ);
            }
            context.SaveChanges();

            base.Seed(context);
        }
    }
}