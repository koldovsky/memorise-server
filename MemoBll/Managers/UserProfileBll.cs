using System;
using MemoBll.Interfaces;
using MemoBll.Logic;
using MemoDAL.Entities;
using MemoDTO;
using System.Collections.Generic;
using System.Linq;
using MemoBll.ManagersInterfaces;
using MemoDAL;
using MemoDAL.EF;

namespace MemoBll.Managers
{
    public class UserProfileBll : IUserProfileBll
    {
        IUserProfile userProfile;
        IConverterToDTO converterToDto;
        IConverterFromDTO converterFromDto;

        public UserProfileBll()
        {
            userProfile = new UserProfileDetails(new UnitOfWork(new MemoContext()));
            converterToDto = new ConverterToDTO();
            converterFromDto = new ConverterFromDTO();
        }

        public UserProfileBll(IUserProfile userProfile, IConverterToDTO converterToDto,
            IConverterFromDTO converterFromDto)
        {
            this.userProfile = userProfile;
            this.converterToDto = converterToDto;
            this.converterFromDto = converterFromDto;
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

        public List<CourseDTO> GetCoursesByUser(string userLogin)
        {
            List<Course> courses = userProfile.GetCoursesByUser(userLogin).ToList();
            return converterToDto.ConvertToCourseListDTO(courses);
        }

        public List<DeckDTO> GetDecksByUser(string userLogin)
        {
            List<Deck> decks = userProfile.GetDecksByUser(userLogin).ToList();
            return converterToDto.ConvertToDeckListDTO(decks);
        }

        public UserDTO GetUserById(string userId)
        {
            User user = userProfile.GetUserById(userId);
            return user != null
                ? converterToDto.ConvertToUserDTO(user)
                : throw new ArgumentNullException();
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

        public bool UpdateUserProfileById(UserDTO user)
        {
            return user != null
                ? userProfile.UpdateUserProfileById(converterFromDto.ConvertToUserProfile(user))
                : throw new ArgumentNullException();
        }

        public bool UpdateUserProfileEmail(string userId, string userEmail)
        {
            return userProfile.UpdateUserProfileEmail(userId, userEmail);
        }

        public bool UpdateUserById(UserDTO user)
        {
            return user != null
                ? userProfile.UpdateUserById(converterFromDto.ConvertToUser(user))
                : throw new ArgumentNullException();
        }

        public bool UpdateUserByLogin(string existingLogin, UserDTO newUserData)
        {
            return newUserData != null
                ? userProfile.UpdateUserByLogin(existingLogin, converterFromDto.ConvertToUser(newUserData))
                : throw new ArgumentNullException();
        }
    }
}
