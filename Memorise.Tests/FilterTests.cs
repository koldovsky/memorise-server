using System.Collections.Generic;
using MemoBll;
using MemoDAL;
using MemoDAL.Entities;
using Moq;
using NUnit.Framework;

namespace Memorise.Tests
{
    [TestFixture]
    class FilterTests
    {
        [Test]
        public void GetAllCategoriesTest()
        {
            // Arrange
            var expected = new List<Category>();
            for (int i = 0; i < 3; i++)
            {
                expected.Add(new Category { Id = i, Name = $"Category{i}" });
            }
            Mock<IUnitOfWork> unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(uow => uow.Categories.GetAll()).Returns(expected);
            var filter = new Filter(unitOfWork.Object);

            // Act
            var actual = filter.GetAllCategories();

            // Assert
            Assert.AreEqual(expected, actual);
            unitOfWork.Verify();
        }

        [Test]
        public void GetAllCoursesTest()
        {
            // Arrange
            var expected = new List<Course>();
            for (int i = 0; i < 3; i++)
            {
                expected.Add(new Course { Id = i, Name = $"Course{i}" });
            }
            Mock<IUnitOfWork> unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(uow => uow.Courses.GetAll()).Returns(expected);
            var filter = new Filter(unitOfWork.Object);

            // Act
            var actual = filter.GetAllCourses();

            // Assert
            Assert.AreEqual(expected, actual);
            unitOfWork.Verify();
        }

        [Test]
        public void GetCategoryTest()
        {
            // Arrange
            int id = 1;
            var expected = new Category { Id = id, Name = $"Category1" };
            
            Mock<IUnitOfWork> unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(uow => uow.Categories.Get(id)).Returns(expected);
            var filter = new Filter(unitOfWork.Object);

            // Act
            var actual = filter.GetCategory(id);

            // Assert
            Assert.AreEqual(expected, actual);
            unitOfWork.Verify();
        }
    }
}
