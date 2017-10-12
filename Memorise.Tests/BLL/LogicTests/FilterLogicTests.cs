using System.Collections.Generic;
using MemoBll.Logic;
using MemoDAL;
using MemoDAL.Entities;
using Moq;
using NUnit.Framework;

namespace Memorise.Tests.BLL.LogicTests
{
    [TestFixture]
    public class FilterLogicTests
    {
        private Mock<IUnitOfWork> unitOfWork;
        private List<Category> categories = new List<Category>();
        private List<Course> courses = new List<Course>();

        public FilterLogicTests()
        {
            this.unitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
            this.categories.Add(new Category { Id = 1, Name = "Category1" });
            this.categories.Add(new Category { Id = 2, Name = "Category2" });
            this.categories.Add(new Category { Id = 3, Name = "Category3" });
            this.courses.Add(new Course { Id = 1, Name = "Course1" });
            this.courses.Add(new Course { Id = 2, Name = "Course2" });
            this.courses.Add(new Course { Id = 3, Name = "Course3" });
        }

        [Test]
        public void GetAllCategoriesTest()
        {
            // Arrange
            var expected = this.categories;
            this.unitOfWork.Setup(uow => uow.Categories.GetAll()).Returns(expected);
            var filter = new Filter(this.unitOfWork.Object);

            // Act
            var actual = filter.GetAllCategories();

            // Assert
            Assert.AreEqual(expected, actual);
            this.unitOfWork.Verify(uow => uow.Categories.GetAll(), Times.Once);
        }

        [Test]
        public void GetAllCoursesTest()
        {
            // Arrange
            var expected = this.courses;
            this.unitOfWork.Setup(uow => uow.Courses.GetAll()).Returns(expected);
            var filter = new Filter(this.unitOfWork.Object);

            // Act
            var actual = filter.GetAllCourses();

            // Assert
            Assert.AreEqual(expected, actual);
            this.unitOfWork.Verify(uow => uow.Courses.GetAll(), Times.Once);
        }

        [Test]
        public void GetCategoryTest()
        {
            // Arrange
            var expected = this.categories[0];
            int id = expected.Id;
            this.unitOfWork.Setup(uow => uow.Categories.Get(id)).Returns(expected);
            var filter = new Filter(this.unitOfWork.Object);

            // Act
            var actual = filter.GetCategory(id);

            // Assert
            Assert.AreEqual(expected, actual);
            this.unitOfWork.Verify(uow => uow.Courses.GetAll(), Times.Once);
        }
    }
}
