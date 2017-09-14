using System.Collections.Generic;
using System.Linq;
using MemoDAL;
using MemoDAL.Entities;
using MemoDAL.EF;
using MemoDTO;
using System;

namespace MemoBll
{
    public class UserProfileBll
    {
        UnitOfWork unitOfWork = new UnitOfWork(new MemoContext());
        ConverterToDto converterToDto = new ConverterToDto();

        public List<CourseDTO> GetCoursesByUser(string userEmail)
        {
            List<MemoDTO.CourseDTO> courses = new List<CourseDTO>();
            IEnumerable<UserCourse> userCourses = unitOfWork.UserCourses.GetCollectionByPredicate(x => x.User.Email == userEmail);
            if (userCourses != null && userCourses.ToList().Count > 0)
            {
                foreach (UserCourse userCourse in userCourses)
                {
                    courses.Add(converterToDto.ConvertToCourseDTO(userCourse.Course));
                }
            }
            return courses;
        }

        //public List<DeckDTO> GetDecksByUser(string login) 
        //{
        //    List<DeckDTO> decks = new List<DeckDTO>();
        //    IEnumerable<UserCourse> userCourses = unitOfWork.UserCourses.GetCollectionByPredicate(x => x.User.Login == login);

        //    if (userCourses != null && userCourses.ToList().Count > 0)
        //    {
        //        List<DeckCourse> deckCourses = new List<DeckCourse>();
        //        foreach (UserCourse userCourse in userCourses)
        //        {
        //            deckCourses.AddRange(unitOfWork.DeckCourses.GetCollectionByPredicate(x => x.Course.Id == userCourse.Course.Id));
        //        }

        //        if (deckCourses.Count > 0)
        //        {
        //            foreach (DeckCourse deckCourse in deckCourses)
        //            {
        //                decks.Add(converterToDto.ConvertToDeckDTO(deckCourse.Deck));
        //            }
        //        }
        //    }
        //    return decks;
        //}

        public UserDTO GetUser(int userId)
        {
            User user = unitOfWork.Users.GetOneElementOrDefault(x => x.Id == userId);

            UserDTO userDTO;
            if (user != null)
            {
                userDTO = converterToDto.ConvertToUserDTO(user);
                return userDTO;
            }
            else
            {
                throw new ArgumentNullException();
            }
        }
    }
}
