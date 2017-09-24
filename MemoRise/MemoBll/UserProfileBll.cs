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
        //UnitOfWork unitOfWork = new UnitOfWork(new MemoContext());
        //ConverterToDto converterToDto = new ConverterToDto();

        //public List<CourseDTO> GetCoursesByUser(string userEmail)
        //{
        //    List<CourseDTO> courses = new List<CourseDTO>();
        //    IEnumerable<UserCourse> userCourses = unitOfWork.UserCourses.GetCollectionByPredicate(x => x.User.Email == userEmail);
        //    if (userCourses.ToList().Count > 0)
        //    {
        //        foreach (UserCourse userCourse in userCourses)
        //        {
        //            courses.Add(converterToDto.ConvertToCourseDTO(userCourse.Course));
        //        }
        //        return courses;
        //    }
        //    else
        //    {
        //        throw new ArgumentNullException();
        //    }
        //}

        //public UserDTO GetUser(int userId)
        //{
        //    User user = unitOfWork.Users.GetOneElementOrDefault(x => x.Id == userId);

        //    UserDTO userDTO;
        //    if (user != null)
        //    {
        //        userDTO = converterToDto.ConvertToUserDTO(user);
        //        return userDTO;
        //    }
        //    else
        //    {
        //        throw new ArgumentNullException();
        //    }
        //}
    }
}
