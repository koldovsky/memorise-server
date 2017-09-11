using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemoDAL;
using MemoDAL.Entities;
using MemoDAL.EF;

namespace MemoBll
{
    class Adminisrtation
    {
        UnitOfWork unitOfWork = new UnitOfWork(new MemoContext());

        //It should be enum of reasons. 
        //After add enum, we should replace string parameter to someEnum.
        public int GetReportCountForReason(string reason)
        {
            return unitOfWork.Reports.Find(x => x.Reason == reason).Count();
        }

        //It should be enum of reasons. 
        //After add enum, we should replace string parameter to someEnum.
        public List<MemoDAL.Entities.Report> GetAllReportsOnReason(string reason)
        {
            return unitOfWork.Reports.Find(x => x.Reason == reason).ToList();
        }

        public List<Report> GetAllReportsOnDate(DateTime date)
        {
            return unitOfWork.Reports.Find(x => x.Date == date).ToList();
        }

        public List<Report> GetAllReportsFromDate(DateTime date)
        {
            return unitOfWork.Reports.Find(x => x.Date >= date).ToList();
        }

        public Report GetReport(int reportId)
        {
            return unitOfWork.Reports.Get(reportId);
        }

        public List<Role> GetAllRoles()
        {
            return unitOfWork.Roles.GetAll().ToList();
        }

        public List<Role> GetRoles(int userId)
        {
            List<UserRole> userRoles = new List<UserRole>();
            userRoles = unitOfWork.UserRoles.Find(x => x.User.Id == userId).ToList();

            List<Role> roles = new List<Role>();
            userRoles.ForEach(x => roles.Add(x.Role));
            return roles;
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

        public int GetDeckStatistics(int deckId)
        {
            List<Statistic> deckStatistics = unitOfWork.Statistics.Find(x => x.Deck.Id == deckId).ToList();

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

        public int GetCourseStatistics(int courseId)
        {
            List<DeckCourse> deckCourses = unitOfWork.DeckCourses.Find(x => x.Course.Id == courseId).ToList();

            if (deckCourses.Count > 1)
            {
                double totalCoursePercent = 0.0;
                double result = 0.0;
                foreach (DeckCourse deckCourse in deckCourses)
                {
                    totalCoursePercent += GetDeckStatistics(deckCourse.Deck.Id);
                }
                result = Math.Round(totalCoursePercent / deckCourses.Count);
                return Convert.ToInt32(result);
            }
            return 0;
        }

        public int GetStatistics(int deckId, int userId)
        {
            List<Statistic> statistics = unitOfWork.Statistics.Find(x => x.Deck.Id == deckId && x.User.Id == userId).ToList();
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
        public List<User> GetAllUserOnRole(Role role)
        {
            List<UserRole> userRoles = unitOfWork.UserRoles.Find(x => x.Role == role).ToList();
            List<User> users = new List<User>();
            foreach (UserRole userRole in userRoles)
            {
                users.Add(userRole.User);
            }
            return users;
        }

        public User GetUser(int userId)
        {
            return unitOfWork.Users.Get(userId);
        }

        public List<User> GetAllBlocedUser()
        {
            return unitOfWork.Users.Find(x => x.IsBlocked == true).ToList();
        }

        //Returns all users which add some course
        //Maybe will be method that returns users whish evaluate or pass some course
        public List<User> GetAllUsersByCouse(int courseId)
        {
            List<UserCourse> userCourses = unitOfWork.UserCourses.Find(x => x.Course.Id == courseId).ToList();
            List<User> users = new List<User>();
            foreach (UserCourse userCourse in userCourses)
            {
                users.Add(userCourse.User);
            }
            return users;
        }

        //Returns all users which add some deck
        //Maybe will be method that returns users whish evaluate or pass some deck
        public List<User> GetAllUsersByDeck(int deckId)
        {
            List<Statistic> statistics = unitOfWork.Statistics.Find(x => x.Deck.Id == deckId).ToList();
            List<User> users = new List<User>();
            foreach (Statistic item in statistics)
            {
                users.Add(item.User);
            }
            return users;
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
            List<UserRole> userRoles = new List<UserRole>();
            userRoles = unitOfWork.UserRoles.Find(x => x.User.Id == userId).ToList();

            List<Role> roles = new List<Role>();
            userRoles.ForEach(x => roles.Add(x.Role));
            return roles;
        }

        public void SetUserRole(User user, Role role)
        {
            if (user != null && role != null)
            {
                if (unitOfWork.UserRoles.Find(x => x.Role == role && x.User == user).ToList().Count == 0)
                {
                    UserRole userRole = new UserRole();
                    userRole.Role = role;
                    userRole.User = user;
                    unitOfWork.UserRoles.Create(userRole);
                    unitOfWork.Save();
                }
            }
        }

        public void UpdateUserRole(User user, Role role)
        {
            if (user != null && role != null)
            {
                List<UserRole> userRoles = unitOfWork.UserRoles.Find(x => x.Role == role && x.User == user).ToList();
                if (userRoles.Count == 1)
                {
                    userRoles[0].Role = role;
                    userRoles[0].User = user;
                    unitOfWork.Save();
                }
            }
        }

        public void DeleteUserRole(User user, Role role)
        {
            if (user != null && role != null)
            {
                List<UserRole> userRoles = unitOfWork.UserRoles.Find(x => x.Role == role && x.User == user).ToList();
                if (userRoles.Count == 1)
                {
                    unitOfWork.UserRoles.Delete(userRoles[0]);
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
