using MemoDAL;
using MemoDAL.Entities;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memorise.Tests
{
    [TestFixture]
    class ModerationTests
    {
        [Test]
        public void GetAllCategoriesTest()
        {
            // Arrange
            var expected = new List<Category>();
            Mock<IUnitOfWork> unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(uow => uow.Categories.GetAll()).Returns(expected);

            // Act

            // Assert
            unitOfWork.Verify();
        }
    }
}
