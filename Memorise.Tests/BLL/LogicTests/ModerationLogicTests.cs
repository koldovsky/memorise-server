using System;
using System.Collections.Generic;
using System.Linq;
using MemoBll.Logic;
using MemoDAL;
using MemoDAL.Entities;
using Moq;
using NUnit.Framework;

namespace Memorise.Tests.BLL.LogicTests
{
    [TestFixture]
    public class ModerationLogicTests
    {
        private Mock<IUnitOfWork> unitOfWork;
        private List<Report> reports = new List<Report>();
        private List<Deck> decks = new List<Deck>();
        private List<User> users = new List<User>();
        private List<Statistics> statistics = new List<Statistics>();
        private List<UserCourse> userCourses = new List<UserCourse>();
        private Moderation moderation;

        public ModerationLogicTests()
        {
            this.reports.Add(new Report
            {
                Id = 1,
                Date = DateTime.Today,
                Reason = "reason1"
            });
            this.reports.Add(new Report
            {
                Id = 1,
                Date = DateTime.Now,
                Reason = "reason1"
            });
            this.reports.Add(new Report
            {
                Id = 1,
                Date = DateTime.Today,
                Reason = "reason2"
            });

            this.users.Add(
                new User
                {
                    Id = "1",
                    UserName = "User1",
                    UserProfile = new MemoDAL.Entities.UserProfile
                    {
                        Id = 1
                    }
                });
            this.users.Add(
                new User
                {
                    Id = "2",
                    UserName = "User2",
                    UserProfile = new MemoDAL.Entities.UserProfile
                    {
                        Id = 2
                    }
                });
            this.users.Add(
                new User
                {
                    Id = "3",
                    UserName = "User3",
                    UserProfile = new MemoDAL.Entities.UserProfile
                    {
                        Id = 3
                    }
                });
            this.userCourses.Add(
                new UserCourse
                {
                    Id = 1,
                    Course = new Course { Id = 1, Name = "course1" },
                    User = this.users[0]
                });
            this.statistics.Add(
                new Statistics
                {
                    Id = 1,
                    Deck = new Deck { Id = 1, Name = "deck1" },
                    SuccessPercent = 20,
                    User = this.users[0]
                });
            this.statistics.Add(
                new Statistics
                {
                    Id = 2,
                    Deck = new Deck { Id = 2, Name = "deck2" },
                    SuccessPercent = 80,
                    User = this.users[1]
                });
            this.statistics.Add(
                new Statistics
                {
                    Id = 3,
                    Deck = new Deck { Id = 3, Name = "deck3" },
                    SuccessPercent = 30,
                    User = this.users[2]
                });
            this.statistics.Add(new Statistics
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
            var reason = this.reports[0].Reason;
            this.unitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
            this.unitOfWork.Setup(uow => uow.Reports.GetAll()).Returns(this.reports);
            this.moderation = new Moderation(this.unitOfWork.Object);

            // Act
            var actual = this.moderation.GetReportCountForReason(reason);

            // Assert
            Assert.AreEqual(expected, actual);
            this.unitOfWork.Verify(uow => uow.Reports.GetAll());
        }

        [Test]
        public void GetAllReportsOnReasonTest()
        {
            // Arrange
            var expected = new List<Report>
            {
                this.reports[0],
                this.reports[1]
            };
            var reason = this.reports[0].Reason;
            this.unitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
            this.unitOfWork.Setup(uow => uow.Reports.GetAll()).Returns(this.reports);
            this.moderation = new Moderation(this.unitOfWork.Object);

            // Act
            var actual = this.moderation.GetAllReportsOnReason(reason);

            // Assert
            Assert.AreEqual(expected, actual);
            this.unitOfWork.Verify(uow => uow.Reports.GetAll(), Times.Once);
        }

        [Test]
        public void GetAllReportsOnDateTest()
        {
            // Arrange
            var expected = new List<Report>
            {
                this.reports[0],
                this.reports[2]
            };
            var date = this.reports[0].Date;
            this.unitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
            this.unitOfWork.Setup(uow => uow.Reports.GetAll()).Returns(this.reports);
            this.moderation = new Moderation(this.unitOfWork.Object);

            // Act
            var actual = this.moderation.GetAllReportsOnDate(date);

            // Assert
            Assert.AreEqual(expected, actual);
            this.unitOfWork.Verify(uow => uow.Reports.GetAll(), Times.Once);
        }

        [Test]
        public void GetAllReportsFromDateTest()
        {
            // Arrange
            var expected = this.reports;
            this.unitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
            this.unitOfWork.Setup(uow => uow.Reports.GetAll()).Returns(this.reports);
            this.moderation = new Moderation(this.unitOfWork.Object);

            // Act
            var actual = this.moderation.GetAllReportsFromDate(DateTime.MinValue);

            // Assert
            Assert.AreEqual(expected, actual);
            this.unitOfWork.Verify(uow => uow.Reports.GetAll(), Times.Once);
        }

        [Test]
        public void GetReportTest()
        {
            // Arrange
            int id = this.reports[0].Id;
            var expected = this.reports[0];
            this.unitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
            this.unitOfWork.Setup(uow => uow.Reports.Get(id)).Returns(this.reports[0]);
            this.moderation = new Moderation(this.unitOfWork.Object);

            // Act
            var actual = this.moderation.GetReport(id);

            // Assert
            Assert.AreEqual(expected, actual);
            this.unitOfWork.Verify(uow => uow.Reports.Get(id), Times.Once);
        }

        [Test]
        public void GetAllUsersByCourseTest()
        {
            // Arrange
            this.unitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
            this.unitOfWork.Setup(uow => uow.UserCourses.GetAll()).Returns(this.userCourses);
            this.moderation = new Moderation(this.unitOfWork.Object);
            var expected = new List<User> { this.users[0] };
            const int VALID_COURSE_ID = 1;

            // Act
            var actual = this.moderation.GetAllUsersByCourse(VALID_COURSE_ID);

            // Assert
            Assert.AreEqual(expected, actual);
            this.unitOfWork.Verify(x => x.UserCourses.GetAll(), Times.Once);
        }

        [Test]
        public void GetAllUsersByCourseTestIsEmpty()
        {
            // Arrange
            this.unitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
            this.unitOfWork.Setup(uow => uow.UserCourses.GetAll()).Returns(this.userCourses);
            this.moderation = new Moderation(this.unitOfWork.Object);
            var expected = new List<User> { this.users[0] };
            const int INVALID_COURSE_ID = 2;

            // Act
            var actual = this.moderation.GetAllUsersByCourse(INVALID_COURSE_ID);

            // Assert
            Assert.IsEmpty(actual);
            this.unitOfWork.Verify(x => x.UserCourses.GetAll(), Times.Once);
        }

        [Test]
        public void GetAllUsersByDeckTest()
        {
            // Arrange
            this.unitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
            this.unitOfWork.Setup(uow => uow.Statistics.GetAll()).Returns(this.statistics);
            this.moderation = new Moderation(this.unitOfWork.Object);
            var expected = new List<User> { this.users[0] };
            const string VALID_DECK_NAME = "deck1";

            // Act
            var actual = this.moderation.GetAllUsersByDeck(VALID_DECK_NAME);

            // Assert
            Assert.AreEqual(expected, actual);
            this.unitOfWork.Verify(x => x.Statistics.GetAll(), Times.Once);
        }

        [Test]
        public void GetAllUsersByDeckTestIsEmpty()
        {
            // Arrange
            this.unitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
            this.unitOfWork.Setup(uow => uow.Statistics.GetAll()).Returns(this.statistics);
            this.moderation = new Moderation(this.unitOfWork.Object);
            var expected = new List<User> { this.users[0] };
            const string INVALID_DECK_NAME = "deck4";

            // Act
            var actual = this.moderation.GetAllUsersByDeck(INVALID_DECK_NAME);

            // Assert
            Assert.IsEmpty(actual);
            this.unitOfWork.Verify(x => x.Statistics.GetAll(), Times.Once);
        }

        [Test]
        public void GetDeckStatisticsTest()
        {
            var expected = this.statistics[3];
            this.unitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
            this.unitOfWork.Setup(temp => temp.Statistics.GetAll()).Returns(this.statistics);
            this.moderation = new Moderation(this.unitOfWork.Object);

            var actual = this.moderation.GetDeckStatistics(4).First();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetStatisticsTest()
        {
            var expected = this.statistics[3];
            this.unitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
            this.unitOfWork.Setup(temp => temp.Statistics.GetAll()).Returns(this.statistics);
            this.moderation = new Moderation(this.unitOfWork.Object);

            var actual = this.moderation.GetStatistics("C#", 4);

            Assert.AreEqual(expected, actual);
        }
    }
}
