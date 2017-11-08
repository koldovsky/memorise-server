using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq.Expressions;
using MemoDAL.Entities;

namespace MemoDAL.EF
{
    public class MemoInitializer : DropCreateDatabaseIfModelChanges<MemoContext>
    {
        protected override void Seed(MemoContext context)
        {
            #region Categories

            // CATEGORY
            IList<Category> categories = new List<Category>
            {
                new Category { Name = ".Net", Linking = "Net" },
                new Category { Name = "Java", Linking = "Java" },
                new Category { Name = "JavaScript", Linking = "JavaScript" },
                new Category { Name = "Python", Linking = "Python" },
                new Category { Name = "Ruby", Linking = "Ruby" }
            };
            context.Categories.AddRange(categories);

            #endregion

            #region Decks

            // DECK
            IList<Deck> decks = new List<Deck>
            {
                new Deck { Name = "Arrays", Linking = "Arrays", Description = "Deck description", Price = 0, Category = categories[0], Photo = @"https://i.imgur.com/qYAgx66.png" },
                new Deck { Name = "Generics", Linking = "Generics", Description = "Deck description", Price = 0, Category = categories[0], Photo = @"https://i.imgur.com/YYc2V8A.png" },
                new Deck { Name = "LINQ", Linking = "LINQ", Description = "Deck description", Price = 0, Category = categories[0], Photo = @"https://i.imgur.com/jwBRMP4.png" },
                new Deck { Name = "Database First", Linking = "DatabaseFirst", Description = "Deck description", Price = 0, Category = categories[0], Photo = @"https://i.imgur.com/ZmzHx0S.png" },
                new Deck { Name = "Model First", Linking = "ModelFirst", Description = "Deck description", Price = 0, Category = categories[0], Photo = @"https://i.imgur.com/MSRN6WC.png" },
                new Deck { Name = "Code First", Linking = "CodeFirst", Description = "Deck description", Price = 0, Category = categories[0], Photo = @"https://i.imgur.com/Jq7sfsp.png" },
                new Deck { Name = "Web API", Linking = "WebAPI", Description = "Deck description", Price = 0, Category = categories[0], Photo = @"https://i.imgur.com/M4L85kg.png" },
                new Deck { Name = "IIS", Linking = "IIS", Description = "Deck description", Price = 0, Category = categories[0], Photo = @"https://i.imgur.com/CRPMCQ8.png" },
                new Deck { Name = "Routing", Linking = "Routing", Description = "Deck description", Price = 0, Category = categories[0], Photo = @"https://i.imgur.com/oiU5ZTp.png" },
                new Deck { Name = "XAML", Linking = "XAML", Description = "Deck description", Price = 0, Category = categories[0], Photo = @"https://i.imgur.com/Jliebsp.png" },
                new Deck { Name = "Binding", Linking = "Binding", Description = "Deck description", Price = 0, Category = categories[0], Photo = @"https://i.imgur.com/zDi5DBO.png" },
                new Deck { Name = "CSS", Linking = "CSS", Description = "Deck description", Price = 0, Category = categories[2], Photo = @"https://i.imgur.com/A3lbO5t.png" },
                new Deck { Name = "Base knowledge", Linking = "BaseKnowledge", Description = "Deck description", Price = 12, Category = categories[0], Photo = @"https://i.imgur.com/yMtHjwy.png" }
            };
            context.Decks.AddRange(decks);

            #endregion

            #region Courses

            // COURSE
            IList<Course> courses = new List<Course>
            {
                new Course { Name = "C#", Linking = "cSharp", Description = "C# course description", Price = 0, Category = categories[0], Photo = @"https://i.imgur.com/6ayw4TN.png" },
                new Course { Name = "ASP.MVC", Linking = "ASPMVC", Description = "ASP.MVC course description", Price = 0, Category = categories[0], Photo = @"https://i.imgur.com/jTuKNU3.png" },
                new Course { Name = "EntityFramework", Linking = "EF", Description = "EntityFramework course description", Price = 100, Category = categories[0], Photo = @"https://i.imgur.com/oICDyxz.png" },
                new Course { Name = "WPF", Linking = "WPF", Description = "WPF course description", Price = 0, Category = categories[0], Photo = @"https://i.imgur.com/pO8UwID.png" },
                new Course { Name = "JQUERY", Linking = "JQ", Description = "JQUERY course description", Price = 0, Category = categories[2], Photo = @"https://i.imgur.com/kdOqFtB.jpg" }
            };
            for (int i = 0; i < 3; i++)
            {
                courses[0].Decks.Add(decks[i]);
            }

            courses[0].Decks.Add(decks[12]);

            for (int i = 3; i < 6; i++)
            {
                courses[1].Decks.Add(decks[i]);
            }

            for (int i = 6; i < 9; i++)
            {
                courses[2].Decks.Add(decks[i]);
            }

            for (int i = 9; i < 11; i++)
            {
                courses[3].Decks.Add(decks[i]);
            }

            for (int i = 11; i < 12; i++)
            {
                courses[4].Decks.Add(decks[i]);
            }

            context.Courses.AddRange(courses);

            #endregion

            #region Card Types

            // CARDTYPE
            IList<CardType> cardTypes = new List<CardType>
            {
                new CardType { Name = "One answer" },
                new CardType { Name = "Few answers" },
                new CardType { Name = "Words input" },
                new CardType { Name = "Code input" }
            };
            context.CardTypes.AddRange(cardTypes);

            #endregion

            #region Cards

            // CARD
            IList<Card> cards = new List<Card>
            {
                #region Arrays

                new Card
                {
                    Question = "Which of the following is the correct output of the C#.NET code snippet given below?  \n int[ , , ] a = new int[ 3, 2, 3 ]; \n Console.WriteLine(a.Length); ",
                    Deck = decks[0],
                    CardType  = cardTypes[0]
                },
                new Card
                {
                    Question = "Which of the following statements are correct about the C#.NET code snippet given below?  \n int[][][] intMyArr = new int[2][][];",
                    Deck = decks[0],
                    CardType  = cardTypes[1]
                },
                new Card
                {
                    Question = "Which one of the following statements is correct?",
                    Deck = decks[0],
                    CardType  = cardTypes[0]
                },
                new Card
                {
                    Question = "Which of the following statements are correct about arrays used in C#.NET?",
                    Deck = decks[0],
                    CardType  = cardTypes[1]
                },

                #endregion

                #region Generics

                new Card
                {
                    Question = "Which one of the following classes are present System.Collections.Generic namespace?",
                    Deck = decks[1],
                    CardType  = cardTypes[1]
                },
                new Card
                {
                    Question = "Which of the following statements are valid about generics in .NET Framework?",
                    Deck = decks[1],
                    CardType  = cardTypes[1]
                },
                new Card
                {
                    Question = "Which of the following statements is valid about generic procedures in C#.NET?",
                    Deck = decks[1],
                    CardType  = cardTypes[1]
                },
                new Card
                {
                    Question = "Which of the following statements is valid about advantages of generics?",
                    Deck = decks[1],
                    CardType  = cardTypes[0]
                },

                #endregion

                #region Generics

                new Card
                {
                    Question = "The full form of LINQ is _______.",
                    Deck = decks[2],
                    CardType  = cardTypes[0]
                },
                new Card
                {
                    Question = "Which of the following supports LINQ?",
                    Deck = decks[2],
                    CardType  = cardTypes[0]
                },
                new Card
                {
                    Question = "A class must implement ____________ interface in order to provide querying facility using LINQ.",
                    Deck = decks[2],
                    CardType  = cardTypes[0]
                },
                new Card
                {
                    Question = "Which of the following statement is TRUE?",
                    Deck = decks[2],
                    CardType  = cardTypes[0]
                },

                #endregion

                #region Base knowledge

                new Card
                {
                     Question = "What key word is used in class declaration to prevent the class from being inherited from other classes?",
                     CardType = cardTypes[2],
                     Deck = decks[12]
                },
                new Card
                {
                     Question = "What operator is used for checking the object with type and this will return a Boolean value?",
                     CardType = cardTypes[2],
                     Deck = decks[12]
                },
                new Card
                {
                     Question = "What is name of the compiler for C#?",
                     CardType = cardTypes[2],
                     Deck = decks[12]
                },
                new Card
                {
                     Question = "What is the base type for all other types in C#?",
                     CardType = cardTypes[2],
                     Deck = decks[12]
                },
                new Card
                {
                     Question = @"Return sum a and b",
                     CardType = cardTypes[3],
                     Deck = decks[12]
                },
                new Card
                {
                     Question = @"Return remainder from dividing a to b",
                     CardType = cardTypes[3],
                     Deck = decks[12]
                },
                new Card
                {
                     Question = "2What key word is used in class declaration to prevent the class from being inherited from other classes?",
                     CardType = cardTypes[2],
                     Deck = decks[12]
                },
                new Card
                {
                     Question = "2What operator is used for checking the object with type and this will return a Boolean value?",
                     CardType = cardTypes[2],
                     Deck = decks[12]
                },
                new Card
                {
                     Question = "2What is name of the compiler for C#?",
                     CardType = cardTypes[2],
                     Deck = decks[12]
                },
                new Card
                {
                     Question = "2What is the base type for all other types in C#?",
                     CardType = cardTypes[2],
                     Deck = decks[12]
                },
                new Card
                {
                     Question = @"2Return sum a and b",
                     CardType = cardTypes[3],
                     Deck = decks[12]
                },
                new Card
                {
                     Question = @"2Return remainder from dividing a to b",
                     CardType = cardTypes[3],
                     Deck = decks[12]
                },
                new Card
                {
                     Question = "3What key word is used in class declaration to prevent the class from being inherited from other classes?",
                     CardType = cardTypes[2],
                     Deck = decks[12]
                },
                new Card
                {
                     Question = "3What operator is used for checking the object with type and this will return a Boolean value?",
                     CardType = cardTypes[2],
                     Deck = decks[12]
                },
                new Card
                {
                     Question = "3What is name of the compiler for C#?",
                     CardType = cardTypes[2],
                     Deck = decks[12]
                },
                new Card
                {
                     Question = "3What is the base type for all other types in C#?",
                     CardType = cardTypes[2],
                     Deck = decks[12]
                },
                new Card
                {
                     Question = @"3Return sum a and b",
                     CardType = cardTypes[3],
                     Deck = decks[12]
                },
                new Card
                {
                     Question = @"3Return remainder from dividing a to b",
                     CardType = cardTypes[3],
                     Deck = decks[12]
                },
                new Card
                {
                     Question = "4What key word is used in class declaration to prevent the class from being inherited from other classes?",
                     CardType = cardTypes[2],
                     Deck = decks[12]
                },
                new Card
                {
                     Question = "4What operator is used for checking the object with type and this will return a Boolean value?",
                     CardType = cardTypes[2],
                     Deck = decks[12]
                },
                new Card
                {
                     Question = "4What is name of the compiler for C#?",
                     CardType = cardTypes[2],
                     Deck = decks[12]
                },
                new Card
                {
                     Question = "4What is the base type for all other types in C#?",
                     CardType = cardTypes[2],
                     Deck = decks[12]
                },
                new Card
                {
                     Question = @"4Return sum a and b",
                     CardType = cardTypes[3],
                     Deck = decks[12]
                },
                new Card
                {
                     Question = @"4Return remainder from dividing a to b",
                     CardType = cardTypes[3],
                     Deck = decks[12]
                },
                #endregion
            };

            context.Cards.AddRange(cards);

            #endregion

            #region Answers

            // ANSWER
            IList<Answer> answers = new List<Answer>
            {
                #region Arrays 1

                new Answer
                {
                    Text = "18",
                    IsCorrect = true,
                    Card  = cards[0]
                },
                new Answer
                {
                    Text = "4",
                    IsCorrect = false,
                    Card  = cards[0]
                },
                new Answer
                {
                    Text = "20",
                    IsCorrect = false,
                    Card  = cards[0]
                },
                new Answer
                {
                    Text = "10",
                    IsCorrect = false,
                    Card = cards[0]
                },

                #endregion

                #region Arrays 2

                new Answer
                {
                    Text = "intMyArr refers to a 2-D jagged array containing 2 rows.",
                    IsCorrect = false,
                    Card = cards[1]
                },
                new Answer
                {
                    Text = "intMyArr refers to a 2-D jagged array containing 3 rows.",
                    IsCorrect = false,
                    Card = cards[1]
                },
                new Answer
                {
                    Text = "intMyArr refers to a 3-D jagged array containing 2 2-D jagged arrays.",
                    IsCorrect = true,
                    Card = cards[1]
                },
                new Answer
                {
                    Text = "intMyArr refers to a 3-D jagged array containing three 2-D jagged arrays.",
                    IsCorrect = false,
                    Card = cards[1]
                },
                new Answer
                {
                    Text = "intMyArr refers to a 3-D jagged array containing 2 2-D rectangular arrays.",
                    IsCorrect = false,
                    Card = cards[1]
                },

                #endregion

                #region Arrays 3

                new Answer
                {
                    Text = "Array elements can be of integer type only",
                    IsCorrect = false,
                    Card = cards[2]
                },
                new Answer
                {
                    Text = "The rank of an Array is the total number of elements it can contain.",
                    IsCorrect = false,
                    Card = cards[2]
                },
                new Answer
                {
                    Text = "The length of an Array is the number of dimensions in the Array.",
                    IsCorrect = false,
                    Card = cards[2]
                },
                new Answer
                {
                    Text = "The Array elements are guaranteed to be sorted.",
                    IsCorrect = false,
                    Card = cards[2]
                },
                new Answer
                {
                    Text = "The default value of numeric array elements is zero.",
                    IsCorrect = true,
                    Card = cards[2]
                },

                #endregion

                #region Arrays 4

                new Answer
                {
                    Text = "Arrays can be rectangular or jagged",
                    IsCorrect = true,
                    Card = cards[3]
                },
                new Answer
                {
                    Text = "Rectangular arrays have similar rows stored in adjacent memory locations.",
                    IsCorrect = true,
                    Card = cards[3]
                },
                new Answer
                {
                    Text = "Jagged arrays do not have an access to the methods of System.Array Class.",
                    IsCorrect = false,
                    Card = cards[3]
                },
                new Answer
                {
                    Text = "Rectangular arrays do not have an access to the methods of System.Array Class.",
                    IsCorrect = false,
                    Card = cards[3]
                },
                new Answer
                {
                    Text = "Jagged arrays have dissimilar rows stored in non-adjacent memory locations.",
                    IsCorrect = true,
                    Card = cards[3]
                },

                #endregion

                #region Generics 1

                new Answer
                {
                    Text = "Stack",
                    IsCorrect = true,
                    Card  = cards[4]
                },
                new Answer
                {
                    Text = "Tree",
                    IsCorrect = false,
                    Card  = cards[4]
                },
                new Answer
                {
                    Text = "SortedDictionary",
                    IsCorrect = true,
                    Card  = cards[4]
                },
                new Answer
                {
                    Text = "SortedArray",
                    IsCorrect = false,
                    Card = cards[4]
                },

                #endregion

                #region Generics 2

                new Answer
                {
                    Text = "Generics is a language feature.",
                    IsCorrect = true,
                    Card = cards[5]
                },
                new Answer
                {
                    Text = "We can create a generic class, however, we cannot create a generic interface in C#.NET.",
                    IsCorrect = false,
                    Card = cards[5]
                },
                new Answer
                {
                    Text = "Generics delegates are not allowed in C#.NET.",
                    IsCorrect = true,
                    Card = cards[5]
                },
                new Answer
                {
                    Text = "Generics are useful in collection classes in .NET framework.",
                    IsCorrect = true,
                    Card = cards[5]
                },
                new Answer
                {
                    Text = "None of the above",
                    IsCorrect = false,
                    Card = cards[5]
                },

                #endregion

                #region Generics 3

                new Answer
                {
                    Text = "All procedures in a Generic class are generic.",
                    IsCorrect = false,
                    Card = cards[6]
                },
                new Answer
                {
                    Text = "Only those procedures labeled as Generic are generic.",
                    IsCorrect = false,
                    Card = cards[6]
                },
                new Answer
                {
                    Text = "Generic procedures can take at the most one generic parameter.",
                    IsCorrect = false,
                    Card = cards[6]
                },
                new Answer
                {
                    Text = "Generic procedures must take at least one type parameter.",
                    IsCorrect = true,
                    Card = cards[6]
                },
                new Answer
                {
                    Text = "None of the above.",
                    IsCorrect = true,
                    Card = cards[6]
                },

                #endregion

                #region Generics 4

                new Answer
                {
                    Text = "Generics shift the burden of type safety to the programmer rather than compiler.",
                    IsCorrect = false,
                    Card = cards[7]
                },
                new Answer
                {
                    Text = "Generics require use of explicit type casting.",
                    IsCorrect = false,
                    Card = cards[7]
                },
                new Answer
                {
                    Text = "Generics provide type safety without the overhead of multiple implementations.",
                    IsCorrect = true,
                    Card = cards[7]
                },
                new Answer
                {
                    Text = "Generics eliminate the possibility of run-time errors.",
                    IsCorrect = false,
                    Card = cards[7]
                },
                new Answer
                {
                    Text = "None of the above.",
                    IsCorrect = false,
                    Card = cards[7]
                },

                #endregion

                #region LINQ 1

                new Answer
                {
                    Text = "Link-List Inner Query",
                    IsCorrect = false,
                    Card  = cards[8]
                },
                new Answer
                {
                    Text = "Language-Integrated Query",
                    IsCorrect = true,
                    Card  = cards[8]
                },
                new Answer
                {
                    Text = "Linked-Integrated Query",
                    IsCorrect = false,
                    Card  = cards[8]
                },
                new Answer
                {
                    Text = "Lazy Integration Query",
                    IsCorrect = false,
                    Card = cards[8]
                },

                #endregion

                #region LINQ 2

                new Answer
                {
                    Text = "Object collection.",
                    IsCorrect = false,
                    Card = cards[9]
                },
                new Answer
                {
                    Text = "XML Document.",
                    IsCorrect = false,
                    Card = cards[9]
                },
                new Answer
                {
                    Text = "Entity Framework.",
                    IsCorrect = false,
                    Card = cards[9]
                },
                new Answer
                {
                    Text = "All of the above.",
                    IsCorrect = true,
                    Card = cards[9]
                },
                new Answer
                {
                    Text = "None of the above",
                    IsCorrect = false,
                    Card = cards[9]
                },

                #endregion

                #region LINQ 3

                new Answer
                {
                    Text = "IEnumerator or IQueryable.",
                    IsCorrect = false,
                    Card = cards[10]
                },
                new Answer
                {
                    Text = "IEnumerable or IQueryable.",
                    IsCorrect = true,
                    Card = cards[10]
                },
                new Answer
                {
                    Text = "Enumerable or Queryable.",
                    IsCorrect = false,
                    Card = cards[10]
                },
                new Answer
                {
                    Text = "None of the above.",
                    IsCorrect = false,
                    Card = cards[10]
                },

                #endregion

                #region LINQ 4

                new Answer
                {
                    Text = "The lambda expression is nothing but extension method.",
                    IsCorrect = false,
                    Card = cards[11]
                },
                new Answer
                {
                    Text = "The lambda expression is a style of representing dynamic types.",
                    IsCorrect = false,
                    Card = cards[11]
                },
                new Answer
                {
                    Text = "The lambda expression is a shorter way of representing anonymous methods.",
                    IsCorrect = true,
                    Card = cards[11]
                },
                new Answer
                {
                    Text = "The lambda expression is nothing but static delegate method.",
                    IsCorrect = false,
                    Card = cards[11]
                },
                new Answer
                {
                    Text = "None of the above.",
                    IsCorrect = false,
                    Card = cards[11]
                },

                #endregion

                #region For Base knowledge

                new Answer
                {
                    Text = "sealed",
                    IsCorrect = true,
                    Card = cards[12]
                },
                new Answer
                {
                    Text = "is",
                    IsCorrect = true,
                    Card = cards[13]
                },
                new Answer
                {
                    Text = "CSC",
                    IsCorrect = true,
                    Card = cards[14]
                },
                new Answer
                {
                    Text = "csc",
                    IsCorrect = true,
                    Card = cards[14]
                },
                new Answer
                {
                    Text = "object",
                    IsCorrect = true,
                    Card = cards[15]
                },
                new Answer
                {
                    Text = "System.Object",
                    IsCorrect = true,
                    Card = cards[15]
                },
                new Answer
                {
                    Text = "Object",
                    IsCorrect = true,
                    Card = cards[15]
                },
                new Answer
                {
                    Text = @"
                            public class Quiz
                            {
                                public int Sum(int a, int b)
                                {
                                    //Type your code here
                                }
                            }
                    ",
                    IsCorrect = true,
                    Card = cards[16]
                },
                new Answer
                {
                    Text = @"
                            public class Quiz
                            {
                                public int Remainder(int a, int b)
                                {
                                    //Type your code here
                                }
                            }
                    ",
                    IsCorrect = true,
                    Card = cards[17]
                },
                new Answer
                {
                    Text = "sealed",
                    IsCorrect = true,
                    Card = cards[18]
                },
                new Answer
                {
                    Text = "is",
                    IsCorrect = true,
                    Card = cards[19]
                },
                new Answer
                {
                    Text = "CSC",
                    IsCorrect = true,
                    Card = cards[20]
                },
                new Answer
                {
                    Text = "csc",
                    IsCorrect = true,
                    Card = cards[20]
                },
                new Answer
                {
                    Text = "object",
                    IsCorrect = true,
                    Card = cards[21]
                },
                new Answer
                {
                    Text = "System.Object",
                    IsCorrect = true,
                    Card = cards[21]
                },
                new Answer
                {
                    Text = "Object",
                    IsCorrect = true,
                    Card = cards[21]
                },
                new Answer
                {
                    Text = @"
                            public class Quiz
                            {
                                public int Sum(int a, int b)
                                {
                                    //Type your code here
                                }
                            }
                    ",
                    IsCorrect = true,
                    Card = cards[22]
                },
                new Answer
                {
                    Text = @"
                            public class Quiz
                            {
                                public int Remainder(int a, int b)
                                {
                                    //Type your code here
                                }
                            }
                    ",
                    IsCorrect = true,
                    Card = cards[23]
                },
                new Answer
                {
                    Text = "sealed",
                    IsCorrect = true,
                    Card = cards[24]
                },
                new Answer
                {
                    Text = "is",
                    IsCorrect = true,
                    Card = cards[25]
                },
                new Answer
                {
                    Text = "CSC",
                    IsCorrect = true,
                    Card = cards[26]
                },
                new Answer
                {
                    Text = "csc",
                    IsCorrect = true,
                    Card = cards[26]
                },
                new Answer
                {
                    Text = "object",
                    IsCorrect = true,
                    Card = cards[27]
                },
                new Answer
                {
                    Text = "System.Object",
                    IsCorrect = true,
                    Card = cards[27]
                },
                new Answer
                {
                    Text = "Object",
                    IsCorrect = true,
                    Card = cards[27]
                },
                new Answer
                {
                    Text = @"
                            public class Quiz
                            {
                                public int Sum(int a, int b)
                                {
                                    //Type your code here
                                }
                            }
                    ",
                    IsCorrect = true,
                    Card = cards[28]
                },
                new Answer
                {
                    Text = @"
                            public class Quiz
                            {
                                public int Remainder(int a, int b)
                                {
                                    //Type your code here
                                }
                            }
                    ",
                    IsCorrect = true,
                    Card = cards[29]
                },
                new Answer
                {
                    Text = "sealed",
                    IsCorrect = true,
                    Card = cards[30]
                },
                new Answer
                {
                    Text = "is",
                    IsCorrect = true,
                    Card = cards[31]
                },
                new Answer
                {
                    Text = "CSC",
                    IsCorrect = true,
                    Card = cards[32]
                },
                new Answer
                {
                    Text = "csc",
                    IsCorrect = true,
                    Card = cards[32]
                },
                new Answer
                {
                    Text = "object",
                    IsCorrect = true,
                    Card = cards[33]
                },
                new Answer
                {
                    Text = "System.Object",
                    IsCorrect = true,
                    Card = cards[33]
                },
                new Answer
                {
                    Text = "Object",
                    IsCorrect = true,
                    Card = cards[33]
                },
                new Answer
                {
                    Text = @"
                            public class Quiz
                            {
                                public int Sum(int a, int b)
                                {
                                    //Type your code here
                                }
                            }
                    ",
                    IsCorrect = true,
                    Card = cards[34]
                },
                new Answer
                {
                    Text = @"
                            public class Quiz
                            {
                                public int Remainder(int a, int b)
                                {
                                    //Type your code here
                                }
                            }
                    ",
                    IsCorrect = true,
                    Card = cards[35]
                },
                #endregion
            };
            context.Answers.AddRange(answers);

            #endregion

            #region Algorithms

            IList<Algorithm> algorithms = new List<Algorithm>
            {
                new Algorithm { Name = "Five Repeat intervals", Description = "Quiz cads depends on card status and have reminder for repeat.", ClassName = "DefaultAlgorithm", IsActive = true },
                new Algorithm { Name = "Just random", Description = "You get random quiz cards without any logic.", ClassName = "RandomAlgorithm", IsActive = false }
                
            };
            context.Algorithms.AddRange(algorithms);

            #endregion

            context.SaveChanges();

            base.Seed(context);
        }
    }
}