using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemoDAL;
using MemoDAL.Entities;
using MemoDAL.EF;

namespace MemoBll
{
    public class UserProfileBll
    {
        UnitOfWork unitOfWork = new UnitOfWork(new MemoContext());

        public MemoDTO.CourseDTO GetCoursesByUser(string userEmail)
        {
            List<MemoDTO.CourseDTO> courses = new List<MemoDTO.CourseDTO>();
            IEnumerable<UserCourse> userCourses = unitOfWork.UserCourses.Find(x => x.User.Email == userEmail);
            foreach(UserCourse userCourse in userCourses)
            {
                userCourse.Course
            }
        }
    }
}
