using System;
using System.Collections.Generic;
using System.Linq;
using MemoDAL;
using MemoDAL.Entities;
using MemoDAL.EF;
using MemoDTO;

namespace MemoBll
{
    public class UserProfileBll
    {
        IUnitOfWork unitOfWork;
        IConverterToDTO converterToDto;

        public UserProfileBll()
        {
            this.unitOfWork = new UnitOfWork(new MemoContext());
            this.converterToDto = new ConverterToDTO();
        }

        public UserProfileBll(IUnitOfWork unitOfWork, IConverterToDTO converterToDto)
        {
            this.unitOfWork = unitOfWork;
            this.converterToDto = converterToDto;
        }

        public List<CourseDTO> GetCoursesByUser(string userEmail)
        {
            List<CourseDTO> courses = new List<CourseDTO>();
            IEnumerable<UserCourse> userCourses = unitOfWork.UserCourses
                .GetAll().Where(x => x.User.Email == userEmail);
            if (userCourses.ToList().Count > 0)
            {
                foreach (UserCourse userCourse in userCourses)
                {
                    courses.Add(converterToDto.ConvertToCourseDTO(userCourse.Course));
                }
            }
            else
            {
                throw new ArgumentNullException();
            }

            return courses;
        }

        public UserDTO GetUser(int userId)
        {
            User user = unitOfWork.Users.GetAll().FirstOrDefault(x => x.Id == userId);
            
            return user != null
                ? converterToDto.ConvertToUserDTO(user)
                : throw new ArgumentNullException();
        }
    }
}
