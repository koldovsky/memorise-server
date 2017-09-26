using MemoBll.Interfaces;
using MemoDAL;
using MemoDAL.EF;
using MemoDAL.Entities;
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
            IEnumerable<UserCourse> userCourses = unitOfWork.UserCourses
                .GetAll().Where(x => x.User.Email == userEmail);
            foreach (UserCourse userCourse in userCourses)
            {
                courses.Add(userCourse.Course);
            }

            return courses;
        }

        public User GetUser(int userId)
        {
            return unitOfWork.Users.Get(userId);
        }
    }
}
