using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MemoDAL.Entities;

namespace MemoDAL.EF
{
    public class MemoInitializer: CreateDatabaseIfNotExists<MemoContext>
    {
        protected override void Seed(MemoContext context)
        {
            //ROLE
            IList<Role> roles = new List<Role>()
            {
                new Role {Name="Admin"},
                new Role {Name="Moderator"},
                new Role {Name="Guest"},
                new Role {Name="Customer"}
            };
            foreach (var role in roles)
            {
                context.Roles.Add(role);
            }
            //USER
            IList<User> users = new List<User>()
            {
                new User{Login="user1",Password="1",Email="user1@gmail",IsBlocked=false},
                new User{Login="user2",Password="2",Email="user2@gmail",IsBlocked=false},
                new User{Login="user3",Password="3",Email="user3@gmail",IsBlocked=false},
                new User{Login="user4",Password="4",Email="user4@gmail",IsBlocked=false}
            };
            foreach(var user in users)
            {
                context.Users.Add(user);
            }
            //USERROLE
            IList<UserRole> userRoles = new List<UserRole>()
            {
                new UserRole{User=users[0],Role=roles[0]},
                new UserRole{User=users[1],Role=roles[1]},
                new UserRole{User=users[2],Role=roles[2]},
                new UserRole{User=users[3],Role=roles[3]},
            };
            foreach (var userRole in userRoles)
            {
                context.UserRoles.Add(userRole);
            }
            //CATEGORY
            IList<Category> categories = new List<Category>()
            {
                new Category{Name=".Net"},
                new Category{Name="Java"},
                new Category{Name="JavaScript"},
                new Category{Name="Python"},
                new Category{Name="Ruby"}
            };
            foreach(var cat in categories)
            {
                context.Categories.Add(cat);
            }
            //COURSE
            IList<Course> courses = new List<Course>()
            {
                new Course{Name="C#",Description="C# course description",Price=0,Category=categories[0]},
                new Course{Name="ASP.MVC",Description="ASP.MVC course description",Price=0,Category=categories[0]},
                new Course{Name="EntityFramework",Description="EntityFramework course description",Price=100,Category=categories[0]},
                new Course{Name="WPF",Description="WPF course description",Price=0,Category=categories[0]}
            };
            foreach (var course in courses)
            {
                context.Courses.Add(course);
            }
            //USERCOURSE
            context.UserCourses.Add(new UserCourse { User = users[0], Course = courses[0], Rating = 4 });
            //DECK
            IList<Deck> decks = new List<Deck>()
            {
                new Deck{Name="Arrays",Price=0,Category=categories[0]},
                new Deck{Name="Generics",Price=0,Category=categories[0]},
                new Deck{Name="Threads",Price=0,Category=categories[0]},
                new Deck{Name="LINQ",Price=0,Category=categories[0]}
            };
            foreach (var deck in decks)
            {
                context.Decks.Add(deck);
            }
            //DECKCOURSE
            context.DecksCourses.Add(new DeckCourse { Deck = decks[0], Course = courses[0] });
            context.DecksCourses.Add(new DeckCourse { Deck = decks[1], Course = courses[0] });
            context.DecksCourses.Add(new DeckCourse { Deck = decks[2], Course = courses[0] });
            context.DecksCourses.Add(new DeckCourse { Deck = decks[3], Course = courses[2] });
            //CARDTYPE
            IList<CardType> cardTypes = new List<CardType>()
            {
                new CardType{Name="CardType1"},
                new CardType{Name="CardType2"},
                new CardType{Name="CardType3"},
                new CardType{Name="CardType4"},
            };
            foreach(var cardType in cardTypes)
            {
                context.CardTypes.Add(cardType);
            }
            //CARD
            IList<Card> cards = new List<Card>()
            {
                new Card{Question="Question1",Deck=decks[0],CardType=cardTypes[0]},
                new Card{Question="Question2",Deck=decks[0],CardType=cardTypes[1]},
                new Card{Question="Question3",Deck=decks[0],CardType=cardTypes[2]},
                new Card{Question="Question4",Deck=decks[0],CardType=cardTypes[3]},
            };
            foreach(var card in cards)
            {
                context.Cards.Add(card);
            }
            //ANSWER
            IList<Answer> answers = new List<Answer>()
            {
                new Answer{Text="Answer1",IsCorrect=true,Card=cards[0]},
                new Answer{Text="Answer2",IsCorrect=false,Card=cards[0]},
                new Answer{Text="Answer3",IsCorrect=false,Card=cards[0]},
                new Answer{Text="Answer4",IsCorrect=false,Card=cards[0]},
                new Answer{Text="Answer5",IsCorrect=true,Card=cards[1]},
                new Answer{Text="Answer6",IsCorrect=true,Card=cards[2]},
                new Answer{Text="Answer7",IsCorrect=false,Card=cards[2]},
                new Answer{Text="Answer8",IsCorrect=false,Card=cards[2]},
                new Answer{Text="Answer9",IsCorrect=false,Card=cards[2]},
                new Answer{Text="Answer10",IsCorrect=true,Card=cards[2]},
                new Answer{Text="Answer11",IsCorrect=true,Card=cards[3]}
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