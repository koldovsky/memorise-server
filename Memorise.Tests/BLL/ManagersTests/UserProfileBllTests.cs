using System.Collections.Generic;
using System.Linq;
using MemoBll.Interfaces;
using MemoBll.Managers;
using MemoDAL.Entities;
using MemoDTO;
using Moq;
using NUnit.Framework;

namespace Memorise.Tests.BLL.ManagersTests
{
    [TestFixture]
    public class UserProfileBllTests
    {
        private static IList<User> users = new List<User>();
        private static IList<Course> courses = new List<Course>();
        private static IList<UserProfile> usersProfiles = new List<UserProfile>();
        private static bool updated = true;

        public UserProfileBllTests()
        {
            for (int i = 0; i < 5; i++)
            {
                users.Add(new User
                {
                    Id = $"{i}",
                    UserName = $"Category{i}",
                    Email = $"user{i}@gmail.com"
                });
                usersProfiles.Add(new UserProfile { User = users[i], IsBlocked = false });
                courses.Add(new Course { Name = $"user{i}" });
            }
        }

        [Test]
        public void GetUserByLoginTest()
        {
            Mock<IUserProfile> userProfile = new Mock<IUserProfile>(MockBehavior.Strict);
            userProfile
                .Setup(exuser => exuser.GetUserByLogin(It.IsIn(users.Select(u => u.UserName))))
                .Returns(users[0]);
            Mock<IConverterToDto> converter = new Mock<IConverterToDto>(MockBehavior.Strict);
            converter
                .Setup(c => c.ConvertToUserDto(It.IsIn<User>(users)))
                .Returns(new UserDTO());
            var sut = new UserProfileBll(
                userProfile.Object,
                converter.Object);
            var expected = users[0];
            var actual = sut.GetUserByLogin(expected.UserName);

            userProfile.Verify(
                up => up.GetUserByLogin(expected.UserName), Times.Once);
            converter.Verify(
                c => c.ConvertToUserDto(
                    It.IsAny<User>()),
                Times.Once);
        }

        [Test]
        public void GetCoursesByUserTest()
        {
            Mock<IUserProfile> userProfile = new Mock<IUserProfile>(MockBehavior.Strict);
            userProfile
                .Setup(exuser => exuser.GetCoursesByUser(It.IsIn(users.Select(u => u.Email))))
                .Returns(courses);
            Mock<IConverterToDto> converter = new Mock<IConverterToDto>(MockBehavior.Loose);
            converter
                .Setup(c => c.ConvertToCourseListDto(It.IsIn<IEnumerable<Course>>(courses)))
                .Returns(new List<CourseDTO>());
            var sut = new UserProfileBll(
                userProfile.Object,
                converter.Object);
            var expected = users[0];
            var actual = sut.GetCoursesByUser(expected.Email);
            userProfile.Verify(
                up => up.GetCoursesByUser(expected.Email), Times.Once);
            converter.Verify(
                c => c.ConvertToCourseListDto(
                    It.IsAny<IEnumerable<Course>>()),
                Times.Once);
        }

        [Test]
        public void GetUserByEmailTest()
        {
            Mock<IUserProfile> userProfile = new Mock<IUserProfile>(MockBehavior.Strict);
            userProfile
                .Setup(exuser => exuser.GetUserByEmail(It.IsIn(users.Select(u => u.Email))))
                .Returns(users[0]);
            Mock<IConverterToDto> converter = new Mock<IConverterToDto>(MockBehavior.Loose);
            converter
                .Setup(c => c.ConvertToUserDto(It.IsIn<User>(users)))
                .Returns(new UserDTO());
            var sut = new UserProfileBll(
                userProfile.Object,
                converter.Object);
            var expected = users[0];
            var actual = sut.GetUserByEmail(expected.Email);
            userProfile.Verify(
                up => up.GetUserByEmail(expected.Email), Times.Once);
            converter.Verify(
                c => c.ConvertToUserDto(
                    It.IsAny<User>()),
                Times.Once);
        }

        [Test]
        public void UpdateUserProfileEmailTest()
        {
            Mock<IUserProfile> userProfile = new Mock<IUserProfile>(MockBehavior.Strict);
            userProfile
                .Setup(exuser =>
                    exuser.UpdateUserProfileEmail(
                        It.IsIn(users.Select(u => u.Id)),
                        It.IsIn(users.Select(u => u.Email))))
                .Returns(updated);
            Mock<IConverterToDto> converter = new Mock<IConverterToDto>(MockBehavior.Strict);
            converter
                .Setup(c => c.ConvertToUserDto(It.IsIn<User>(users)))
                .Returns(new UserDTO());
            var sut = new UserProfileBll(userProfile.Object);
            var userCurrent = users[0];
            var userUpdate = users[1];
            var actual = sut.UpdateUserProfileEmail(userCurrent.Id, userUpdate.Email);

            Assert.AreEqual(updated, actual);

            userProfile.Verify(
                up => up.UpdateUserProfileEmail(userCurrent.Id, userUpdate.Email), Times.Once);
        }
    }
}