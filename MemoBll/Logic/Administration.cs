﻿using MemoBll.Interfaces;
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

		public IEnumerable<Role> GetAllRoles()
		{
			return unitOfWork.Roles.GetAll();
		}

		public IEnumerable<Role> GetRoles(int userId)
		{
			return unitOfWork.Users.Get(userId).Roles;
		}

		public void CreateRole(Role role)
		{
			unitOfWork.Roles.Create(role);
			unitOfWork.Save();
		}

		public void UpdateRole(Role role)
		{
			unitOfWork.Roles.Update(role);
			unitOfWork.Save();
		}

		public void DeleteRole(Role role)
		{
			unitOfWork.Roles.Delete(role);
			unitOfWork.Save();
		}

		public IEnumerable<Statistics> GetDeckStatistics(int deckId)
		{
			return unitOfWork.Statistics
				.GetAll().Where(x => x.Deck.Id == deckId);
		}

		public Course GetCourse(int courseId)
		{
			return unitOfWork.Courses.Get(courseId);
		}

		public IEnumerable<Statistics> GetStatistics(int deckId, int userId)
		{
			return unitOfWork.Statistics
				.GetAll()
				.Where(x => x.Deck.Id == deckId && x.User.Id == userId);
		}

		public void DeleteStatistics(Statistics statistics)
		{
			unitOfWork.Statistics.Delete(statistics);
			unitOfWork.Save();
		}

		public IEnumerable<User> GetAllUsersOnRole(string roleName)
		{
			return unitOfWork.Roles
				.GetAll()
				.FirstOrDefault(x => x.Name == roleName)
				.Users;
		}

		public User GetUser(int userId)
		{
			return unitOfWork.Users.Get(userId);
		}

		public IEnumerable<User> GetAllBlockedUsers()
		{
			return unitOfWork.Users
				.GetAll()
				.Where(x => x.IsBlocked == true);
		}

		public void BlockUser(int userId)
		{
			unitOfWork.Users.Get(userId).IsBlocked = true;
			unitOfWork.Save();
		}

		public void UnblockUser(int userId)
		{
			unitOfWork.Users.Get(userId).IsBlocked = false;
			unitOfWork.Save();
		}

		public void DeleteUser(User user)
		{
			unitOfWork.Users.Delete(user);
			unitOfWork.Save();
		}

		public IEnumerable<Role> GetUserRoles(int userId)
		{
			return unitOfWork.Users
				.GetAll()
				.First(x => x.Id == userId)
				.Roles;
		}

		public void SetUserRole(User user, Role role)
		{
			if (user != null && role != null)
			{
				User currentUser = unitOfWork.Users
					.GetAll()
					.First(x => x.Id == user.Id);

				if (currentUser != null)
				{
					currentUser.Roles.Add(role);
					unitOfWork.Users.Update(currentUser);
					unitOfWork.Save();
				}
			}
		}

		public void RemoveRoleFromUser(User user, Role role)
		{
			if (user != null && role != null)
			{
				User currentUser = unitOfWork.Users
					.GetAll().First(x => x.Id == user.Id);
				if (currentUser != null)
				{
					currentUser.Roles.Remove(role);
					unitOfWork.Users.Update(currentUser);
					unitOfWork.Save();
				}
			}
		}

		public void CreateAnswer(Answer answer)
		{
			unitOfWork.Answers.Create(answer);
		}

		public void UpdateAnswer(Answer answer)
		{
			unitOfWork.Answers.Update(answer);
		}

		public void RemoveAnswer(Answer answer)
		{
			unitOfWork.Answers.Delete(answer);
		}

		public IEnumerable<Answer> GetAllCorrectAnswersInCard(int cardId)
		{
			return unitOfWork.Answers.GetAll()
				.Where(x => x.Card.Id == cardId && x.IsCorrect);
		}

		public void AddCategory(Category category)
		{
			unitOfWork.Categories.Create(category);
		}

		public void UpdateCategory(Category category) //to return bool is better idea
		{                                             //to give only id and then delete by id
			unitOfWork.Categories.Update(category);
		}

		public void RemoveCategory(Category category) //to return bool is better idea
		{                                             //to give only id and then delete by id
			unitOfWork.Categories.Delete(category);
		}

		public void CreateCourse(Course course)
		{
			unitOfWork.Courses.Create(course);
		}

		public void UpdateCourse(Course course)
		{
			unitOfWork.Courses.Update(course);
		}

		public void RemoveCourse(Course course)
		{
			unitOfWork.Courses.Delete(course);
		}
	}
}
