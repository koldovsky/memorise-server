using MemoBll.Interfaces;
using MemoDAL;
using MemoDAL.EF;
using MemoDAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MemoBll.Logic
{
	public class Administration : IAdministration
	{
		IUnitOfWork unitOfWork;

		public Administration()
		{
			this.unitOfWork = new UnitOfWork(new MemoContext());
		}

		public Administration(IUnitOfWork uow)
		{
			this.unitOfWork = uow;
		}

		//public IEnumerable<Role> GetAllRoles()
		//{
		//	return unitOfWork.Roles.GetAll();
		//}

		//public IEnumerable<Role> GetRoles(int userId)
		//{
		//	return unitOfWork.Users.Get(userId).Roles;
		//}

		//public void CreateRole(Role role)
		//{
		//	unitOfWork.Roles.Create(role);
		//	unitOfWork.Save();
		//}

		//public void UpdateRole(Role role)
		//{
		//	unitOfWork.Roles.Update(role);
		//	unitOfWork.Save();
		//}

		//public void DeleteRole(Role role)
		//{
		//	unitOfWork.Roles.Delete(role);
		//	unitOfWork.Save();
		//}

		public IEnumerable<Statistics> GetDeckStatistics(int deckId)
		{
			return unitOfWork.Statistics
				.GetAll().Where(x => x.Deck.Id == deckId);
		}

		public Course GetCourse(int courseId)
		{
			return unitOfWork.Courses.Get(courseId);
		}

		//public IEnumerable<Statistics> GetStatistics(int deckId, int userId)
		//{
		//	return unitOfWork.Statistics
		//		.GetAll()
		//		.Where(x => x.Deck.Id == deckId && x.User.Id == userId);
		//}

		public void DeleteStatistics(int statisticsId)
		{
			unitOfWork.Statistics.Delete(statisticsId);
			unitOfWork.Save();
		}

		//public IEnumerable<User> GetAllUsersOnRole(string roleName)
		//{
		//	return unitOfWork.Roles
		//		.GetAll()
		//		.FirstOrDefault(x => x.Name == roleName)
		//		.Users;
		//}

		//public User GetUser(int userId)
		//{
		//	return unitOfWork.Users.Get(userId);
		//}

		//public IEnumerable<User> GetAllBlockedUsers()
		//{
		//	return unitOfWork.Users
		//		.GetAll()
		//		.Where(x => x.IsBlocked == true);
		//}

		//public void BlockUser(int userId)
		//{
		//	unitOfWork.Users.Get(userId).IsBlocked = true;
		//	unitOfWork.Save();
		//}

		//public void UnblockUser(int userId)
		//{
		//	unitOfWork.Users.Get(userId).IsBlocked = false;
		//	unitOfWork.Save();
		//}

		//public void DeleteUser(User user)
		//{
		//	unitOfWork.Users.Delete(user);
		//	unitOfWork.Save();
		//}

		//public IEnumerable<Role> GetUserRoles(int userId)
		//{
		//	return unitOfWork.Users
		//		.GetAll()
		//		.First(x => x.Id == userId)
		//		.Roles;
		//}

		//public void SetUserRole(User user, Role role)
		//{
		//	if (user != null && role != null)
		//	{
		//		User currentUser = unitOfWork.Users
		//			.GetAll()
		//			.First(x => x.Id == user.Id);

		//		if (currentUser != null)
		//		{
		//			currentUser.Roles.Add(role);
		//			unitOfWork.Users.Update(currentUser);
		//			unitOfWork.Save();
		//		}
		//	}
		//}

		//public void RemoveRoleFromUser(User user, Role role)
		//{
		//	if (user != null && role != null)
		//	{
		//		User currentUser = unitOfWork.Users
		//			.GetAll().First(x => x.Id == user.Id);
		//		if (currentUser != null)
		//		{
		//			currentUser.Roles.Remove(role);
		//			unitOfWork.Users.Update(currentUser);
		//			unitOfWork.Save();
		//		}
		//	}
		//}

		public void CreateAnswer(Answer answer)
		{
			unitOfWork.Answers.Create(answer);
		}

		public void UpdateAnswer(Answer answer)
		{
			unitOfWork.Answers.Update(answer);
		}

		public void RemoveAnswer(int answerId)
		{
			unitOfWork.Answers.Delete(answerId);
		}

        public IEnumerable<Role> GetAllRoles()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Role> GetRoles(int userId)
        {
            throw new System.NotImplementedException();
        }

        public void CreateRole(Role role)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateRole(Role role)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteRole(Role role)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Statistics> GetStatistics(int deckId, int userId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<User> GetAllUsersOnRole(string roleName)
        {
            throw new System.NotImplementedException();
        }

        public User GetUser(int userId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<User> GetAllBlockedUsers()
        {
            throw new System.NotImplementedException();
        }

        public void BlockUser(int userId)
        {
            throw new System.NotImplementedException();
        }

        public void UnblockUser(int userId)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteUser(User user)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Role> GetUserRoles(int userId)
        {
            throw new System.NotImplementedException();
        }

        public void SetUserRole(User user, Role role)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveRoleFromUser(User user, Role role)
        {
            throw new System.NotImplementedException();
        }

    }
}
