using System;
using System.Collections.Generic;
using System.Linq;
using MemoDAL;
using MemoDAL.Entities;
using MemoDAL.EF;
using MemoDTO;

namespace MemoBll
{
    public class Administration
    {
        IUnitOfWork unitOfWork;
        IConverterToDTO converterToDto;

        public Administration()
        {
            this.unitOfWork = new UnitOfWork(new MemoContext());
            this.converterToDto = new ConverterToDto();
        }

        public Administration(IUnitOfWork unitOfWork, IConverterToDTO converterToDto)
        {
            this.unitOfWork = unitOfWork;
            this.converterToDto = converterToDto;
        }

        #region ForRoles

        public List<Role> GetAllRoles()
        {
            return unitOfWork.Roles.GetAll().ToList();
        }

        public List<RoleDTO> GetRoles(int userId)
        {
            List<RoleDTO> roles = new List<RoleDTO>();
            User user;
            user = unitOfWork.Users.Get(userId); //.GetAll().First(x => x.Id == userId);
            if (user != null)
            {
                foreach (Role role in user.Roles)
                {
                    roles.Add(converterToDto.ConvertToRoleDTO(role));
                }
            }
            else
            {
                throw new ArgumentNullException();
            }

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

        #endregion

        #region ForStatistics

        public int GetDeckStatistics(int deckId)
        {
            List<Statistics> deckStatistics = unitOfWork.Statistics
                .GetAll().Where(x => x.Deck.Id == deckId).ToList();

            if (deckStatistics != null && deckStatistics.Count > 0)
            {
                double totalDeckPercent = 0.0;
                double averageDeckPercent = 0.0;

                foreach (Statistics statistic in deckStatistics)
                {
                    totalDeckPercent += statistic.SuccessPercent;
                }
                averageDeckPercent = Math.Round(totalDeckPercent / deckStatistics.Count);

                return Convert.ToInt32(averageDeckPercent);
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public int GetCourseStatistics(int courseId)
        {
            List<StatisticDTO> statisticDTO = new List<StatisticDTO>();
            Course course = unitOfWork.Courses.Get(courseId);

            if (course != null)
            {
                double totalCoursePercent = 0.0;
                double averageCoursePercent = 0.0;
                foreach (Deck deck in course.Decks)
                {
                    totalCoursePercent += GetDeckStatistics(deck.Id);
                }
                averageCoursePercent = Math.Round(totalCoursePercent / course.Decks.Count);
                return Convert.ToInt32(averageCoursePercent);
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public int GetStatistics(int deckId, int userId)
        {
            List<Statistics> statistics = unitOfWork.Statistics
                .GetAll().Where(x => 
                x.Deck.Id == deckId && x.User.Id == userId).ToList();
            if (statistics != null && statistics.Count > 1)
            {
                return statistics[0].SuccessPercent;
            }
            else
            {
                throw new Exception();
            }
        }

        public void DeleteStatistics(Statistics statistics)
        {
            unitOfWork.Statistics.Delete(statistics);
            unitOfWork.Save();
        }

        #endregion

        #region ForUsers

        public List<UserDTO> GetAllUsersOnRole(string roleName)
        {
            Role currentRole = unitOfWork.Roles
                .GetAll().FirstOrDefault(x => x.Name == roleName);

            return currentRole != null
                ? converterToDto.ConvertToUserListDTO(currentRole.Users.ToList())
                : throw new ArgumentNullException();
        }

        public User GetUser(int userId)
        {
            return unitOfWork.Users.Get(userId);
        }

        public List<User> GetAllBlocedUser()
        {
            return unitOfWork.Users
                .GetAll().Where(x => x.IsBlocked == true).ToList();
        }

        public void BlockUser(int userId)
        {
            unitOfWork.Users.Get(userId).IsBlocked = true;
            unitOfWork.Save();
        }

        public void UnBlockUser(int userId)
        {
            unitOfWork.Users.Get(userId).IsBlocked = false;
            unitOfWork.Save();
        }

        public void DeleteUser(User user)
        {
            unitOfWork.Users.Delete(user);
            unitOfWork.Save();
        }

        public List<Role> GetUserRoles(int userId)
        {
            User currentUser = unitOfWork.Users
                .GetAll().First(x => x.Id == userId);
            List<Role> roles = currentUser.Roles.ToList();

            return roles;
        }

        public void SetUserRole(User user, Role role)
        {
            if (user != null && role != null)
            {
                User currentUser = unitOfWork.Users
                    .GetAll().First(x => x.Id == user.Id);
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

        #endregion

        #region ForAnswers

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
            return unitOfWork.Answers.GetAll()
                .Where(x => x.Card.Id == cardId && x.IsCorrect).ToList();
        }

        #endregion

        #region ForCategories

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

        #endregion

        #region ForCourses

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

        #endregion

    }
}
