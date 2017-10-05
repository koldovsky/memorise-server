using MemoBll.Interfaces;
using MemoBll.Logic;
using MemoBll.Managers;
using MemoDAL.Entities;
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
