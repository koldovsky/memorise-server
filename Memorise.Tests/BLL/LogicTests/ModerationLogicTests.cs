using System;
using System.Collections.Generic;
using MemoBll.Logic;
using MemoDAL;
using MemoDAL.Entities;
using Moq;
using NUnit.Framework;
using MemoBll.Managers;
using MemoBll.Interfaces;

namespace Memorise.Tests.BLL.LogicTests
{
	[TestFixture]
    class ModerationLogicTests
    {
        Mock<IUnitOfWork> unitOfWork;
        List<Report> reports = new List<Report>();
        List<Deck> decks = new List<Deck>();
        //List<User> users = new List<User>();
        List<Statistics> statistics = new List<Statistics>();
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
            statistics.Add(new Statistics
            {
                Id = 2,
                Deck = new Deck { Id = 1 ,Name = "C#"},
                User = new User {  UserProfile = new MemoDAL.Entities.UserProfile {  Id = 1} } 
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
        public void GetDeckStatisticsTest()
        {
            var expected = statistics;
            unitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
            unitOfWork.Setup(temp => temp.Statistics.GetAll()).Returns(statistics);
            moderation = new Moderation(unitOfWork.Object);

            var actual = moderation.GetDeckStatistics(1);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetStatisticsTest()
        {
            var expected = statistics[0];
            unitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
            unitOfWork.Setup(temp => temp.Statistics.GetAll()).Returns(statistics);
            moderation = new Moderation(unitOfWork.Object);

            var actual = moderation.GetStatistics("C#", 1);

            Assert.AreEqual(expected, actual);
        }

        //[Test]
        //public void DeleteStatisticsTest()
        //{
        //    Statistics statistics = new Statistics();
        //    var moderationMock = new Mock<IModeration>();
        //    moderationMock.Setup(temp => temp.DeleteStatistics(statistics));
        //    ModerationBll getStat = new ModerationBll(moderationMock.Object, new ConverterToDTO());

        //    ;
        //}

    }
}
