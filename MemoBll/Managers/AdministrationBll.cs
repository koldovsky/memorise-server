using MemoBll.Interfaces;
using MemoBll.Logic;
using MemoDAL.Entities;
using MemoDTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MemoBll.Managers
{
	public class AdministrationBll
	{
		IAdministration administration;
		IConverterToDTO converterToDto;

		public AdministrationBll()
		{
			this.administration = new Administration();
			this.converterToDto = new ConverterToDTO();
		}

		public AdministrationBll(
			IAdministration administration,
			IConverterToDTO converterToDto)
		{
			this.administration = administration;
			this.converterToDto = converterToDto;
		}

		#region ForRoles

		public IEnumerable<Role> GetAllRoles()
		{
			return administration.GetAllRoles();
		}

		public IEnumerable<RoleDTO> GetRoles(int userId)
		{
			return administration.GetRoles(userId)
				.Select(role => converterToDto.ConvertToRoleDTO(role));
		}

		public void CreateRole(Role role)
		{
			administration.CreateRole(role);
		}

		public void UpdateRole(Role role)
		{
			administration.UpdateRole(role);
		}

		public void DeleteRole(Role role)
		{
			administration.DeleteRole(role);
		}

		#endregion

		//#region ForStatistics

		//public int GetDeckStatistics(int deckId)
		//{
		//	List<Statistics> deckStatistics = administration.GetDeckStatistics(deckId).ToList();

		//	if (deckStatistics != null && deckStatistics.Count > 0)
		//	{
		//		double totalDeckPercent = 0.0;
		//		double averageDeckPercent = 0.0;

		//		foreach (Statistics statistic in deckStatistics)
		//		{
		//			totalDeckPercent += statistic.SuccessPercent;
		//		}
		//		averageDeckPercent = Math.Round(totalDeckPercent / deckStatistics.Count);

		//		return Convert.ToInt32(averageDeckPercent);
		//	}
		//	else
		//	{
		//		throw new ArgumentNullException();
		//	}
		//}

		//public int GetCourseStatistics(int courseId)
		//{
		//	Course course = administration.GetCourse(courseId);
		//	if (course != null)
		//	{
		//		double totalCoursePercent = 0.0;
		//		double averageCoursePercent = 0.0;
		//		foreach (Deck deck in course.Decks)
		//		{
		//			totalCoursePercent += GetDeckStatistics(deck.Id);
		//		}
		//		averageCoursePercent = Math.Round(totalCoursePercent / course.Decks.Count);
		//		return Convert.ToInt32(averageCoursePercent);
		//	}
		//	else
		//	{
		//		throw new ArgumentNullException();
		//	}
		//}

		//public int GetStatistics(int deckId, int userId)
		//{
		//	List<Statistics> statistics =
		//		administration.GetStatistics(deckId, userId).ToList();
		//	if (statistics != null && statistics.Count >= 1)
		//	{
		//		return statistics[0].SuccessPercent;
		//	}
		//	else
		//	{
		//		throw new Exception();
		//	}
		//}

		//public void DeleteStatistics(int statisticsId)
		//{
		//	administration.DeleteStatistics(statisticsId);
		//}

		//#endregion

		#region ForUsers

		public List<UserDTO> GetAllUsersOnRole(string roleName)
		{
			return converterToDto
				.ConvertToUserListDTO(
				administration.GetAllUsersOnRole(roleName));
		}

		public User GetUser(int userId)
		{
			return administration.GetUser(userId);
		}

		public IEnumerable<User> GetAllBlockedUsers()
		{
			return administration.GetAllBlockedUsers();
		}

		public void BlockUser(int userId)
		{
			administration.BlockUser(userId);
		}

		public void UnblockUser(int userId)
		{
			administration.UnblockUser(userId);
		}

		public void DeleteUser(User user)
		{
			administration.DeleteUser(user);
		}

		public IEnumerable<Role> GetUserRoles(int userId)
		{
			return administration.GetUserRoles(userId);
		}

		public void SetUserRole(User user, Role role)
		{
			administration.SetUserRole(user, role);
		}

		public void RemoveRoleFromUser(User user, Role role)
		{
			administration.RemoveRoleFromUser(user, role);
		}

		#endregion

    }
}
