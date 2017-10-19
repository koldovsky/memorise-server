using MemoBll.Interfaces;
using MemoDAL;
using MemoDAL.EF;
using MemoDAL.Entities;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;

namespace MemoBll.Logic
{
    public class UserProfile : IUserProfile
    {
        IUnitOfWork unitOfWork;

        public UserProfile()
        {
            this.unitOfWork = new UnitOfWork(new MemoContext());
        }

        public UserProfile(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Course> GetCoursesByUser(string userEmail)
        {
            List<Course> courses = new List<Course>();
            IEnumerable<SubscribedCourse> userCourses = unitOfWork.SubscribedCourses
                .GetAll().Where(x => x.User.Email == userEmail);
            foreach (SubscribedCourse userCourse in userCourses)
            {
                courses.Add(userCourse.Course);
            }
            return courses;
        }

        public User GetUserByEmail(string userEmail)
        {
            return unitOfWork.Users.FindByEmail(userEmail);
        }

        public User GetUserByLogin(string userLogin)
        {
            return unitOfWork.Users.FindByName(userLogin);
        }

        public bool UpdateUserProfileEmail(string userId, string userEmail)
        {
            return unitOfWork.Users.SetEmail(userId, userEmail).Succeeded;
        }

        public bool UpdateUserProfileLogin(string userId, string userLogin)
        {
            User user = unitOfWork.Users.FindById(userId);
            user.UserName = userLogin;
            return unitOfWork.Users.Update(user).Succeeded;
        }
    }
}
