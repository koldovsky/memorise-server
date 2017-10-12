using System;
using System.Collections.Generic;
using MemoBll.Logic;
using MemoDAL;
using MemoDAL.Entities;
using Moq;
using NUnit.Framework;
using System.Linq;

namespace Memorise.Tests.BLL.LogicTests
{
	[TestFixture]
    class ModerationLogicTests
    {
        Mock<IUnitOfWork> unitOfWork;
        List<Report> reports = new List<Report>();
        List<Deck> decks = new List<Deck>();
        List<User> users = new List<User>();
        List<Statistics> statistics = new List<Statistics>();
        List<UserCourse> userCourses = new List<UserCourse>();
        Moderation moderation;

        public ModerationLogicTests()
        {
            reports.Add(new Report
            {
                Id = 1,
                Date = DateTime.Today,
                Reason = "reason1"
            });
            reports.Add(new Report
            {
                Id = 1,
                Date = DateTime.Now,
                Reason = "reason1"
            });
            reports.Add(new Report
            {
                Id = 1,
                Date = DateTime.Today,
                Reason = "reason2"
            });

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
            userCourses.Add(
                new UserCourse
                {
                    Id = 1,
                    Course = new Course { Id = 1, Name = "course1" },
                    User = users[0]

                });
            statistics.Add(
                new Statistics
                {
                    Id = 1,
                    Deck = new Deck { Id = 1, Name="deck1" },
                    SuccessPercent = 20,
                    User = users[0]
                });
            statistics.Add(
                new Statistics
                {
                    Id = 2,
                    Deck = new Deck { Id = 2, Name = "deck2" },
                    SuccessPercent = 80,
                    User = users[1]
                });
            statistics.Add(
                new Statistics
                {
                    Id = 3,
                    Deck = new Deck { Id = 3, Name = "deck3" },
                    SuccessPercent = 30,
                    User = users[2]
                });
            statistics.Add(new Statistics
            {
                Id = 4,
                Deck = new Deck { Id = 4, Name = "C#" },
                User = new User { UserProfile = new MemoDAL.Entities.UserProfile { Id = 4 } }
            });



        }

        [Test]
        public void GetReportsCountForReasonTest()
        {
            // Arrange
            int expected = 2;
            var reason = reports[0].Reason;
            unitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
            unitOfWork.Setup(uow => uow.Reports.GetAll()).Returns(reports);
            moderation = new Moderation(unitOfWork.Object);

            // Act
            var actual = moderation.GetReportCountForReason(reason);

            // Assert
            Assert.AreEqual(expected, actual);
            unitOfWork.Verify(uow => uow.Reports.GetAll());
        }

        [Test]
        public void GetAllReportsOnReasonTest()
        {
            // Arrange
            var expected = new List<Report>();
            expected.Add(reports[0]);
            expected.Add(reports[1]);
            var reason = reports[0].Reason;
            unitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
            unitOfWork.Setup(uow => uow.Reports.GetAll()).Returns(reports);
            moderation = new Moderation(unitOfWork.Object);

            // Act
            var actual = moderation.GetAllReportsOnReason(reason);

            // Assert
            Assert.AreEqual(expected, actual);
            unitOfWork.Verify(uow => uow.Reports.GetAll(), Times.Once);
        }

        [Test]
        public void GetAllReportsOnDateTest()
        {
            // Arrange
            var expected = new List<Report>();
            expected.Add(reports[0]);
            expected.Add(reports[2]);
            var date = reports[0].Date;
            unitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
            unitOfWork.Setup(uow => uow.Reports.GetAll()).Returns(reports);
            moderation = new Moderation(unitOfWork.Object);

            // Act
            var actual = moderation.GetAllReportsOnDate(date);

            // Assert
            Assert.AreEqual(expected, actual);
            unitOfWork.Verify(uow => uow.Reports.GetAll(), Times.Once);
        }

        [Test]
        public void GetAllReportsFromDateTest()
        {
            // Arrange
            var expected = reports;
            unitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
            unitOfWork.Setup(uow => uow.Reports.GetAll()).Returns(reports);
            moderation = new Moderation(unitOfWork.Object);

            // Act
            var actual = moderation.GetAllReportsFromDate(DateTime.MinValue);

            // Assert
            Assert.AreEqual(expected, actual);
            unitOfWork.Verify(uow => uow.Reports.GetAll(), Times.Once);
        }

        [Test]
        public void GetReportTest()
        {
            // Arrange
            int id = reports[0].Id;
            var expected = reports[0];
            unitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
            unitOfWork.Setup(uow => uow.Reports.Get(id)).Returns(reports[0]);
            moderation = new Moderation(unitOfWork.Object);

            // Act
            var actual = moderation.GetReport(id);

            // Assert
            Assert.AreEqual(expected, actual);
            unitOfWork.Verify(uow => uow.Reports.Get(id), Times.Once);
        }

        
        [Test]
        public void GetAllUsersByCourseTest()
        {
            // Arrange
            unitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
            unitOfWork.Setup(uow => uow.UserCourses.GetAll()).Returns(userCourses);
            moderation = new Moderation(unitOfWork.Object);
            var expected = new List<User> { users[0]};
            const int VALID_COURSE_ID = 1;
            // Act
            var actual = moderation.GetAllUsersByCourse(VALID_COURSE_ID);

            // Assert
            Assert.AreEqual(expected, actual);
            unitOfWork.Verify(x=>x.UserCourses.GetAll(),Times.Once);

        }

        [Test]
        public void GetAllUsersByCourseTestIsEmpty()
        {
            // Arrange
            unitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
            unitOfWork.Setup(uow => uow.UserCourses.GetAll()).Returns(userCourses);
            moderation = new Moderation(unitOfWork.Object);
            var expected = new List<User> { users[0] };
            const int INVALID_COURSE_ID = 2;
            // Act
            var actual = moderation.GetAllUsersByCourse(INVALID_COURSE_ID);

            // Assert
            Assert.IsEmpty(actual);
            unitOfWork.Verify(x => x.UserCourses.GetAll(), Times.Once);

        }

        [Test]
        public void GetAllUsersByDeckTest()
        {
            // Arrange
            unitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
            unitOfWork.Setup(uow => uow.Statistics.GetAll()).Returns(statistics);
            moderation = new Moderation(unitOfWork.Object);
            var expected = new List<User> { users[0] };
            const string VALID_DECK_NAME = "deck1";

            // Act
            var actual = moderation.GetAllUsersByDeck(VALID_DECK_NAME);

            // Assert
            Assert.AreEqual(expected, actual);
            unitOfWork.Verify(x => x.Statistics.GetAll(), Times.Once);

        }
        [Test]
        public void GetAllUsersByDeckTestIsEmpty()
        {
            // Arrange
            unitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
            unitOfWork.Setup(uow => uow.Statistics.GetAll()).Returns(statistics);
            moderation = new Moderation(unitOfWork.Object);
            var expected = new List<User> { users[0] };
            const string INVALID_DECK_NAME = "deck4";

            // Act
            var actual = moderation.GetAllUsersByDeck(INVALID_DECK_NAME);

            // Assert
            Assert.IsEmpty(actual);
            unitOfWork.Verify(x => x.Statistics.GetAll(), Times.Once);

        }

        [Test]
        public void GetDeckStatisticsTest()
        {
            var expected = statistics[3];
            unitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
            unitOfWork.Setup(temp => temp.Statistics.GetAll()).Returns(statistics);
            moderation = new Moderation(unitOfWork.Object);

            var actual = moderation.GetDeckStatistics(4).First();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetStatisticsTest()
        {
            var expected = statistics[3];
            unitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
            unitOfWork.Setup(temp => temp.Statistics.GetAll()).Returns(statistics);
            moderation = new Moderation(unitOfWork.Object);

            var actual = moderation.GetStatistics("C#", 4);

            Assert.AreEqual(expected, actual);
        }



        


    }
}
