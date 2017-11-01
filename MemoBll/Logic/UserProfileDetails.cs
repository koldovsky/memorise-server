using System;
using MemoBll.Interfaces;
using MemoDAL;
using MemoDAL.EF;
using MemoDAL.Entities;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;

namespace MemoBll.Logic
{
    public class UserProfileDetails : IUserProfile
    {
        private IUnitOfWork unitOfWork;

        public UserProfileDetails()
        {
            unitOfWork = new UnitOfWork(new MemoContext());
        }

        public UserProfileDetails(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Course> GetCoursesByUser(string userLogin)
        {
            throw new NotImplementedException();
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

        public User GetUserById(string userId)
        {
            return unitOfWork.Users.FindById(userId);
        }

        public bool UpdateUserById(User user)
        {
            User currentUser = unitOfWork.Users.FindById(user.Id);
            InitUserWithData(currentUser, user);
            bool result = unitOfWork.Users.Update(currentUser).Succeeded;
            unitOfWork.Save();
            return result;
        }

        public bool UpdateUserProfileById(UserProfile user)
        {
            unitOfWork.UserProfiles.Update(user);
            unitOfWork.Save();
            return true;
        }

        public bool UpdateUserByLogin(string existingLogin, User newUserData)
        {
            User currentUser = unitOfWork.Users.FindByName(existingLogin);
            InitUserWithData(currentUser, newUserData);
            bool result = unitOfWork.Users.Update(currentUser).Succeeded;
            unitOfWork.Save();
            return result;
        }

        public IEnumerable<Deck> GetDecksByUser(string userLogin)
        {
            throw new NotImplementedException();
        }

        private void InitUserWithData(User currentUser, User dataUser)
        {
            currentUser.UserName = dataUser.UserName;
            currentUser.Email = dataUser.Email;
            currentUser.UserProfile.FirstName = dataUser.UserProfile.FirstName;
            currentUser.UserProfile.LastName = dataUser.UserProfile.LastName;
            currentUser.UserProfile.Gender = dataUser.UserProfile.Gender;
            currentUser.UserProfile.Country = dataUser.UserProfile.Country;
            currentUser.UserProfile.City = dataUser.UserProfile.City;
        }
    }
}
