using MemoBll.Interfaces;
using MemoBll.Managers;
using MemoDAL.Entities;
using MemoDTO;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memorise.Tests.BLL.ManagersTests
{
    [TestFixture]
    class ModerationManagersTests
    {
        List<User> users = new List<User>();

        public ModerationManagersTests()
        {
            users.Add(
                new User
                {
                    Id = "1",
                    UserName = "User1",
                    UserProfile = new MemoDAL.Entities.UserProfile
                    {
                        Id = 1
                    }
                });
            users.Add(
                new User
                {
                    Id = "2",
                    UserName = "User2",
                    UserProfile = new MemoDAL.Entities.UserProfile
                    {
                        Id = 2
                    }
                    
                });
            users.Add(
                new User
                {
                    Id = "3",
                    UserName = "User3",
                    UserProfile = new MemoDAL.Entities.UserProfile
                    {
                        Id = 3
                    }
                });
        }

        [Test]
        public void GetAllUsersByCourseTestManager()
        {
            const int VALID_COURSE_ID = 1;
            Mock<IModeration> moderation = new Mock<IModeration>(
                                                 MockBehavior.Strict);
            moderation.Setup(m => m.GetAllUsersByCourse(VALID_COURSE_ID))
                      .Returns(users);

            Mock<IConverterToDTO> converter = new Mock<IConverterToDTO>(
                                              MockBehavior.Strict);

            converter.Setup(c => c.ConvertToUserDTO(It.IsIn<User>(users)))
                     .Returns(new UserDTO());

            var systemUnderTest= new ModerationBll(moderation.Object, 
                                                   converter.Object);
            
            var actual = systemUnderTest.GetAllUsersByCourse(VALID_COURSE_ID);
            
            moderation.Verify(
                m => m.GetAllUsersByCourse(VALID_COURSE_ID), Times.Once);
            converter.Verify(
                c => c.ConvertToUserDTO(
                    It.IsAny<User>()),
                Times.Exactly(users.Count));
            
        }

        [Test]
        public void GetAllUsersByDeckTestManager()
        {
            const string VALID_DECK_NAME = "deck1";
            Mock<IModeration> moderation = new Mock<IModeration>(
                                                 MockBehavior.Strict);
            moderation.Setup(m => m.GetAllUsersByDeck(VALID_DECK_NAME))
                      .Returns(users);

            Mock<IConverterToDTO> converter = new Mock<IConverterToDTO>(
                                              MockBehavior.Strict);

            converter.Setup(c => c.ConvertToUserDTO(It.IsIn<User>(users)))
                     .Returns(new UserDTO());

            var systemUnderTest = new ModerationBll(moderation.Object,
                                                   converter.Object);

            var actual = systemUnderTest.GetAllUsersByDeck(VALID_DECK_NAME);
            
            moderation.Verify(
                m => m.GetAllUsersByDeck(VALID_DECK_NAME), Times.Once);
            converter.Verify(
                c => c.ConvertToUserDTO(
                    It.IsAny<User>()),
                Times.Exactly(users.Count));


        }

        [Test]
        public void GetDeckStatisticsTest()
        {
            List<Statistics> list = new List<Statistics> {
                    new Statistics { Id = 1, Deck = new Deck { Id = 1}, SuccessPercent = 20  },
                    new Statistics { Id = 2, Deck = new Deck { Id = 1 }, SuccessPercent = 80 },
                    new Statistics { Id = 3, Deck = new Deck { Id = 1 }, SuccessPercent = 20 } };
            var moderationMock = new Mock<IModeration>();
            var id = 1;
            moderationMock.Setup(temp => temp.GetDeckStatistics(id)).Returns(list);
            ModerationBll getStat = new ModerationBll(moderationMock.Object, new ConverterToDTO());
            var actual = getStat.GetDeckStatistics(1);

            Assert.AreEqual(40, actual);
        }

        [Test]
        public void GetStatisticsTest()
        {
            List<Statistics> list = new List<Statistics>
            {
                new Statistics { Deck = new Deck { Name = "DataBase" }, SuccessPercent = 30,
                    User = new User { UserProfile = new MemoDAL.Entities.UserProfile { Id = 1 } } }
            };
            var moderationMock = new Mock<IModeration>();
            var id = 1; var name = "DataBase";
            moderationMock.Setup(temp => temp.GetStatistics(name, id)).Returns(list[0]);
            ModerationBll getStat = new ModerationBll(moderationMock.Object, new ConverterToDTO());
            var actual = getStat.GetStatistics(name, id);

            Assert.AreEqual(30, actual);
        }



    }
}
