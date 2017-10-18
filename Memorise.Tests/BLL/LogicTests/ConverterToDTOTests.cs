using System.Collections.Generic;
using MemoDAL.Entities;
using NUnit.Framework;

namespace Memorise.Tests.BLL.LogicTests
{
    [TestFixture]
    public class ConverterToDTOTests
    {
        private static readonly IList<Category> Categories = new List<Category>();
        private static readonly IList<Course> Courses = new List<Course>();
        private static readonly IList<Deck> Decks = new List<Deck>();
        private static readonly IList<Card> Cards = new List<Card>();
        private static readonly IList<Statistics> Statistics = new List<Statistics>();
        private static readonly IList<User> Users = new List<User>();
        private static readonly IList<Answer> Answers = new List<Answer>();

        public ConverterToDTOTests()
        {
            for (int i = 0; i < 3; i++)
            {
                Categories.Add(new Category { Id = i, Name = $"Category{i}" });
                Courses.Add(new Course { Id = i, Name = $"Course{i}" });
                Decks.Add(new Deck { Id = i, Name = $"Decks{i}" });
                //Statistics.Add(new Statistics { Id = i, SuccessPercent = i });
                Answers.Add(new Answer
                {
                    Id = i,
                    Text = $"Answer{i}",
                    IsCorrect = i % 2 == 0 ? false : true
                });
                Cards.Add(new Card { Id = i });
                Cards[0].Answers.Add(Answers[i]);
                Answers[i].Card = Cards[0];
            }

            Courses[0].Decks.Add(Decks[0]);
            Courses[1].Decks.Add(Decks[2]);
            Courses[2].Decks.Add(Decks[0]);
            Courses[0].Decks.Add(Decks[1]);

            Categories[1].Decks.Add(Decks[0]);
            Categories[1].Decks.Add(Decks[2]);
            Categories[0].Decks.Add(Decks[0]);
            Categories[2].Decks.Add(Decks[1]);

            Categories[1].Courses.Add(Courses[0]);
            Categories[1].Courses.Add(Courses[2]);
            Categories[0].Courses.Add(Courses[0]);
            Categories[2].Courses.Add(Courses[1]);

            //Statistics[0].Deck = Decks[0];
            //Statistics[0].User = Users[0];

            //Statistics[1].Deck = Decks[0];
            //Statistics[1].User = Users[2];

            //Statistics[2].Deck = Decks[1];
            //Statistics[2].User = Users[0];
        }
    }
}
