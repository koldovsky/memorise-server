using MemoDAL.Entities;
using System.Collections.Generic;

namespace MemoBll.Interfaces
{
	public interface IAdministration
	{
		IEnumerable<Role> GetAllRoles();
		IEnumerable<Role> GetRoles(int userId);

		void CreateRole(Role role);
		void UpdateRole(Role role);
		void DeleteRole(Role role);

		IEnumerable<Statistics> GetDeckStatistics(int deckId);
		Course GetCourse(int courseId);
		IEnumerable<Statistics> GetStatistics(int deckId, int userId);
		void DeleteStatistics(int statisticsId);

		IEnumerable<User> GetAllUsersOnRole(string roleName);
		User GetUser(int userId);
		IEnumerable<User> GetAllBlockedUsers();

		void BlockUser(int userId);
		void UnblockUser(int userId);
		void DeleteUser(User user);

		IEnumerable<Role> GetUserRoles(int userId);
		void SetUserRole(User user, Role role);
		void RemoveRoleFromUser(User user, Role role);

    }
}
