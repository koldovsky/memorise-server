using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemoBll;
using MemoDAL;
using MemoDAL.Repositories.Interfaces;
using Moq;
using NUnit.Framework;

namespace Memorise.Tests
{
    [TestFixture]
    class FilterTests
    {
        private Filter GetMockedSut()
        {
            Mock<ICategoryRepository> categories = new Mock<ICategoryRepository>();
            Mock<ICourseRepository> courses = new Mock<ICourseRepository>();
            Mock<IUnitOfWork> unitOfWork = new Mock<IUnitOfWork>();

            unitOfWork.Setup(uow => uow.Categories).Returns(categories.Object);
            unitOfWork.Setup(uow => uow.Courses).Returns(courses.Object);

            var filter = new Filter(unitOfWork.Object);
            return filter;
        }
    }
}
