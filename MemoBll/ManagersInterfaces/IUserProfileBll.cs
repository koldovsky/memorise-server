using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemoDTO;

namespace MemoBll.ManagersInterfaces
{
    public interface IUserProfileBll
    {
        List<CourseDTO> GetCoursesByUser(string userLogin);

        List<DeckDTO> GetDecksByUser(string userLogin);

        UserDTO GetUserById(string userId);

        UserDTO GetUserByLogin(string userLogin);

        UserDTO GetUserByEmail(string userEmail);

        bool UpdateUserProfileById(UserDTO user);

        bool UpdateUserProfileEmail(string userId, string userEmail);

        bool UpdateUserById(UserDTO user);

        bool UpdateUserByLogin(string existingLogin, UserDTO newUserData);
    }
}
