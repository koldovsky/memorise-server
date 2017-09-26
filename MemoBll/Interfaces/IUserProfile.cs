using MemoDAL.Entities;
using System.Collections.Generic;

namespace MemoBll.Interfaces
{
	public interface IUserProfile
    {
        IEnumerable<Course> GetCoursesByUser(string userEmail);
        User GetUser(int userId);
    }
}
