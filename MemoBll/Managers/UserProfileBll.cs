using MemoBll.Interfaces;
using MemoBll.Logic;
using MemoDAL;
using MemoDAL.EF;
using MemoDAL.Entities;
using MemoDTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MemoBll.Managers
{
	public class UserProfileBll
    {
        IUserProfile userProfile;
        IConverterToDTO converterToDto;

        public UserProfileBll()
        {
            this.userProfile = new UserProfile(new UnitOfWork(new MemoContext()));
            this.converterToDto = new ConverterToDTO();
        }

        public UserProfileBll(IUserProfile userProfile, IConverterToDTO converterToDto)
        {
            this.userProfile = userProfile;
            this.converterToDto = converterToDto;
        }

        public List<CourseDTO> GetCoursesByUser(string userEmail)
        {
            List<Course> courses = userProfile.GetCoursesByUser(userEmail).ToList();
           
            return converterToDto.ConvertToCourseListDTO(courses);
        }

        public UserDTO GetUser(int userId)
        {
            User user = userProfile.GetUser(userId);
            
            return user != null
                ? converterToDto.ConvertToUserDTO(user)
                : throw new ArgumentNullException();
        }
    }
}
