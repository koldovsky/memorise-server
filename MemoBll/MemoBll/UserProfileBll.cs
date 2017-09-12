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
        ConverterToDto converterToDto = new ConverterToDto();

        public List<MemoDTO.CourseDTO> GetCoursesByUser(string userEmail)
        {
            List<MemoDTO.CourseDTO> courses = new List<MemoDTO.CourseDTO>();
            IEnumerable<UserCourse> userCourses = unitOfWork.UserCourses.Find(x => x.User.Email == userEmail);
            foreach(UserCourse userCourse in userCourses)
            {
                courses.Add(converterToDto.ConvertToCourseDTO(userCourse.Course));
            }
            return courses;
        }

        public List<MemoDTO.CourseDTO> GetDecksByUser(string userEmail)
        {
            List<MemoDTO.CourseDTO> courses = new List<MemoDTO.CourseDTO>();
            //IEnumerable<UserCourse> userCourses = unitOfWork.Statistics.Find(x => x.User.Email == userEmail);
            //foreach (UserCourse userCourse in userCourses)
            //{
            //    courses.Add(converterToDto.ConvertToCourseDTO(userCourse.Course));
            //}
            return courses;
        }
    }
}
