using MemoDAL.Entities;
using System.Collections.Generic;

namespace MemoBll.Interfaces
{
	public interface IUserProfile
    {
        IEnumerable<Course> GetCoursesByUser(string userEmail);
        User GetUserByLogin(string userLogin);
        User GetUserByEmail(string userEmail);
        bool UpdateUserProfileEmail(string Id, string userEmail);
        //bool UpdateUserProfileLogin(string Id, string userLogin);

    }
}
