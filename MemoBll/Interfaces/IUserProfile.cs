using System.Collections.Generic;
using MemoDAL.Entities;

namespace MemoBll.Interfaces
{
    public interface IUserProfile
    {
        IEnumerable<Course> GetCoursesByUser(string userEmail);
        User GetUser(int userId);
    }
}
