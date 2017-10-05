using System;
using MemoBll.Interfaces;
using MemoBll.Logic;
using MemoDAL.Entities;
using MemoDTO;
using System.Collections.Generic;
using System.Linq;
using MemoDAL;
using MemoDAL.EF;

namespace MemoBll.Managers
{
	public class UserProfileBll
    {
        IUserProfile userProfile;
        IConverterToDTO converterToDto;

        public UserProfileBll()
        {
            this.userProfile = new Logic.UserProfile(new UnitOfWork(new MemoContext()));
            this.converterToDto = new ConverterToDTO();
        }

        public UserProfileBll(IUserProfile userProfile, IConverterToDTO converterToDto)
        {
            this.userProfile = userProfile;
            this.converterToDto = converterToDto;
        }

        public UserProfileBll(IUserProfile userProfile)
        {
            this.userProfile = userProfile;
        }

        public List<CourseDTO> GetCoursesByUser(string userEmail)
        {
            List<Course> courses = userProfile.GetCoursesByUser(userEmail).ToList();
            return converterToDto.ConvertToCourseListDTO(courses);
        }

        public UserDTO GetUserByLogin(string userLogin)
        {
            User user = userProfile.GetUserByLogin(userLogin);
            return user != null
                ? converterToDto.ConvertToUserDTO(user)
                : throw new ArgumentNullException();
        }

        public UserDTO GetUserByEmail(string userEmail)
        {
            User user = userProfile.GetUserByEmail(userEmail);
            return user != null
                ? converterToDto.ConvertToUserDTO(user)
                : throw new ArgumentNullException();
        }

        public bool UpdateUserProfileEmail(string userId, string userEmail)
        {
            return userProfile.UpdateUserProfileEmail(userId, userEmail);
        }

        public bool UpdateUserProfileLogin(string userId, string userLogin)
        {
            return true; //userProfile.UpdateUserProfileLogin(userId, userLogin);
        }
    }
}
