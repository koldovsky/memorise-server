using MemoDAL.Entities;
using System.Collections.Generic;

namespace MemoBll.Interfaces
{
	public interface IUserProfile
    {
        IEnumerable<Course> GetCoursesByUser(string userLogin);
        User GetUserByLogin(string userLogin);
        User GetUserByEmail(string userEmail);
        bool UpdateUserProfileEmail(string id, string userEmail);
        User GetUserById(string userId);
        bool UpdateUserById(User user);
        IEnumerable<Deck> GetDecksByUser(string userLogin);
        bool UpdateUserProfileById(UserProfile userProfile);
        bool UpdateUserByLogin(string existingLogin, User newUserData);
    }
}
