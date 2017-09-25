using MemoBll;
using MemoDAL;
using MemoDAL.Entities;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace Memorise.Tests
{
	[TestFixture]
    class FilterTests
    {
        Mock<IUnitOfWork> unitOfWork;
        List<Category> categories = new List<Category>();
        List<Course> courses = new List<Course>();

        public FilterTests()
        {
            unitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
            categories.Add(new Category { Id = 1, Name = "Category1" });
            categories.Add(new Category { Id = 2, Name = "Category2" });
            categories.Add(new Category { Id = 3, Name = "Category3" });
            courses.Add(new Course { Id = 1, Name = "Course1" });
            courses.Add(new Course { Id = 2, Name = "Course2" });
            courses.Add(new Course { Id = 3, Name = "Course3" });
        }

        [Test]
        public void GetAllCategoriesTest()
        {
            // Arrange
            var expected = categories;
            unitOfWork.Setup(uow => uow.Categories.GetAll()).Returns(expected);
            var filter = new Filter(unitOfWork.Object);

            // Act
            var actual = filter.GetAllCategories();

            // Assert
            Assert.AreEqual(expected, actual);
            unitOfWork.Verify(uow => uow.Categories.GetAll(), Times.Exactly(1));
        }

        [Test]
        public void GetAllCoursesTest()
        {
            // Arrange
            var expected = courses;            
            unitOfWork.Setup(uow => uow.Courses.GetAll()).Returns(expected);
            var filter = new Filter(unitOfWork.Object);

            // Act
            var actual = filter.GetAllCourses();

            // Assert
            Assert.AreEqual(expected, actual);
            unitOfWork.Verify(uow => uow.Courses.GetAll(), Times.Exactly(1));
        }

        [Test]
        public void GetCategoryTest()
        {
            // Arrange
            var expected = categories[0];
            int id = expected.Id;            
            unitOfWork.Setup(uow => uow.Categories.Get(id)).Returns(expected);
            var filter = new Filter(unitOfWork.Object);

            // Act
            var actual = filter.GetCategory(id);

            // Assert
            Assert.AreEqual(expected, actual);
            unitOfWork.Verify(uow => uow.Courses.GetAll(), Times.Exactly(1));
        }
    }
}
