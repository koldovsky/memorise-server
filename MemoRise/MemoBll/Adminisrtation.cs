using System;
using System.Collections.Generic;
using System.Linq;
using MemoDAL;
using MemoDAL.Entities;
using MemoDAL.EF;

namespace MemoBll
{
    class Adminisrtation
    {
        UnitOfWork unitOfWork = new UnitOfWork(new MemoContext());

        public List<Role> GetAllRoles()
        {
            return unitOfWork.Roles.GetAll().ToList();
        }

        //public List<Role> GetRoles(int userId)
        //{
        //    List<UserRole> userRoles = new List<UserRole>();
        //    userRoles = unitOfWork.UserRoles.GetCollectionByPredicate(x => x.User.Id == userId).ToList();

        //    List<Role> roles = new List<Role>();
        //    userRoles.ForEach(x => roles.Add(x.Role));
        //    return roles;
        //}

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

        public int GetDeckStatistics(int deckId)
        {
            List<Statistic> deckStatistics = unitOfWork.Statistics.GetCollectionByPredicate(x => x.Deck.Id == deckId).ToList();

            if (deckStatistics.Count > 0)
            {
                double totalDeckPercent = 0.0;
                double result = 0.0;

                foreach (Statistic statistic in deckStatistics)
                {
                    totalDeckPercent += statistic.SuccessPercent;
                }
                result = Math.Round(totalDeckPercent / deckStatistics.Count);

                return Convert.ToInt32(result);
            }
            return 0;
        }

        //public int GetCourseStatistics(int courseId)
        //{
        //    List<DeckCourse> deckCourses = unitOfWork.DeckCourses.GetCollectionByPredicate(x => x.Course.Id == courseId).ToList();

        //    if (deckCourses.Count > 1)
        //    {
        //        double totalCoursePercent = 0.0;
        //        double result = 0.0;
        //        foreach (DeckCourse deckCourse in deckCourses)
        //        {
        //            totalCoursePercent += GetDeckStatistics(deckCourse.Deck.Id);
        //        }
        //        result = Math.Round(totalCoursePercent / deckCourses.Count);
        //        return Convert.ToInt32(result);
        //    }
        //    return 0;
        //}

        public int GetStatistics(int deckId, int userId)
        {
            List<Statistic> statistics = unitOfWork.Statistics.GetCollectionByPredicate(x => x.Deck.Id == deckId && x.User.Id == userId).ToList();
            if (statistics.Count > 1)
            {
                return statistics[0].SuccessPercent;
            }
            return 0;
        }

        public void DeleteStatistics(Statistic statistics)
        {
            unitOfWork.Statistics.Delete(statistics);
            unitOfWork.Save();
        }

        //Returns all users which have some role
        //public List<User> GetAllUserOnRole(Role role)
        //{
        //    List<UserRole> userRoles = unitOfWork.UserRoles.GetCollectionByPredicate(x => x.Role == role).ToList();
        //    List<User> users = new List<User>();
        //    foreach (UserRole userRole in userRoles)
        //    {
        //        users.Add(userRole.User);
        //    }
        //    return users;
        //}

        public User GetUser(int userId)
        {
            return unitOfWork.Users.Get(userId);
        }

        public List<User> GetAllBlocedUser()
        {
            return unitOfWork.Users.GetCollectionByPredicate(x => x.IsBlocked == true).ToList();
        }

        //admin
        public void BlockUser(int userId)
        {
            unitOfWork.Users.Get(userId).IsBlocked = true;
            unitOfWork.Save();
        }

        //admin
        public void UnBlockUser(int userId)
        {
            unitOfWork.Users.Get(userId).IsBlocked = false;
            unitOfWork.Save();
        }

        //admin
        public void DeleteUser(User user)
        {
            unitOfWork.Users.Delete(user);
            unitOfWork.Save();
        }

        public List<Role> GetUserRoles(int userId)
        {
            User currentUser = unitOfWork.Users.GetOneElementOrDefault(x => x.Id == user.Id);
            List<Role> roles = currentUser.Roles.ToList();
            
            return roles;
        }

        public void SetUserRole(User user, Role role)
        {
            if (user != null && role != null)
            {
                User currentUser = unitOfWork.Users.GetOneElementOrDefault(x => x.Id == user.Id);
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
                User currentUser=unitOfWork.Users.GetOneElementOrDefault(x => x.Id == user.Id);
                if (currentUser!=null)
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

        public List<Answer> GetAllCorrectAnswersInCard(int cardId)
        {
            return unitOfWork.Answers.GetAll().Where(x => x.Card.Id == cardId && x.IsCorrect).ToList();
        }

        public void AddCategory(Category category)
        {
            unitOfWork.Categories.Create(category);
        }

        public void UpdateCategory(Category category) /*to return bool is better idea*/
        {                                               /*to give only id and then delete by id*/
            unitOfWork.Categories.Update(category);
        }

        public void RemoveCategory(Category category) /*to return bool is better idea*/
        {                                               /*to give only id and then delete by id*/
            unitOfWork.Categories.Delete(category);
        }

        public void CreateCourse(Course course)
        {
            unitOfWork.Course.Create(course);
        }

        public void UpdateCourse(Course course)
        {
            unitOfWork.Course.Update(course);
        }

        public void RemoveCourse(Course course)
        {
            unitOfWork.Course.Delete(course);
        }
    }
}
