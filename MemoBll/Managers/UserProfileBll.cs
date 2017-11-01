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
        private IUserProfile userProfile;
        private IConverterToDTO converterToDTO;
        private IConverterFromDTO converterFromDTO;

        public UserProfileBll()
        {
            userProfile = new UserProfileDetails(new UnitOfWork(new MemoContext()));
            converterToDTO = new ConverterToDTO();
            converterFromDTO = new ConverterFromDTO();
        }

        public UserProfileBll(IUserProfile userProfile, IConverterToDTO converterToDto, IConverterFromDTO converterFromDto)
        {
            this.userProfile = userProfile;
            this.converterToDTO = converterToDto;
            this.converterFromDTO = converterFromDto;
        }

        public UserProfileBll(IUserProfile userProfile, IConverterToDTO converterToDTO)
        {
            this.userProfile = userProfile;
            this.converterToDTO = converterToDTO;
        }

        public UserProfileBll(IUserProfile userProfile)
        {
            this.userProfile = userProfile;
        }

        public List<CourseDTO> GetCoursesByUser(string userLogin)
        {
            List<Course> courses = userProfile.GetCoursesByUser(userLogin).ToList();
            return converterToDTO.ConvertToCourseListDTO(courses);
        }

        public List<DeckDTO> GetDecksByUser(string userLogin)
        {
            List<Deck> decks = userProfile.GetDecksByUser(userLogin).ToList();
            return converterToDTO.ConvertToDeckListDTO(decks);
        }

        public UserDTO GetUserById(string userId)
        {
            User user = userProfile.GetUserById(userId);
            return user != null
                ? converterToDTO.ConvertToUserDTO(user)
                : throw new ArgumentNullException();
        }

        public UserDTO GetUserByLogin(string userLogin)
        {
            User user = userProfile.GetUserByLogin(userLogin);
            return user != null
                ? converterToDTO.ConvertToUserDTO(user)
                : throw new ArgumentNullException();
        }

        public UserDTO GetUserByEmail(string userEmail)
        {
            User user = userProfile.GetUserByEmail(userEmail);
            return user != null
                ? converterToDTO.ConvertToUserDTO(user)
                : throw new ArgumentNullException();
        }

        public bool UpdateUserProfileById(UserDTO user)
        {
            return user != null
                ? userProfile.UpdateUserProfileById(converterFromDTO.ConvertToUserProfile(user))
                : throw new ArgumentNullException();
        }

        public bool UpdateUserProfileEmail(string userId, string userEmail)
        {
            return userProfile.UpdateUserProfileEmail(userId, userEmail);
        }

        public bool UpdateUserById(UserDTO user)
        {
            return user != null
                ? userProfile.UpdateUserById(converterFromDTO.ConvertToUser(user))
                : throw new ArgumentNullException();
        }

        public bool UpdateUserByLogin(string existingLogin, UserDTO newUserData)
        {
            return newUserData != null
                ? userProfile.UpdateUserByLogin(existingLogin, converterFromDTO.ConvertToUser(newUserData))
                : throw new ArgumentNullException();
        }
    }
}
