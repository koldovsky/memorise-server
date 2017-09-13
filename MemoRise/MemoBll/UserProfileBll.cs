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
    public class UserProfileBll
    {
        UnitOfWork unitOfWork = new UnitOfWork(new MemoContext());
        ConverterToDto converterToDto = new ConverterToDto();

        public List<MemoDTO.CourseDTO> GetCoursesByUser(string userEmail)
        {
            List<MemoDTO.CourseDTO> courses = new List<MemoDTO.CourseDTO>();
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

        public List<MemoDTO.DeckDTO> GetDecksByUser(string login) 
        {
            List<MemoDTO.DeckDTO> decks = new List<MemoDTO.DeckDTO>();
            IEnumerable<UserCourse> userCourses = unitOfWork.UserCourses.GetCollectionByPredicate(x => x.User.Login == login);

            if (userCourses != null && userCourses.ToList().Count > 0)
            {
                List<DeckCourse> deckCourses = new List<DeckCourse>();
                foreach (UserCourse userCourse in userCourses)
                {
                    deckCourses.AddRange(unitOfWork.DeckCourses.GetCollectionByPredicate(x => x.Course.Id == userCourse.Course.Id));
                }

                if (deckCourses.Count > 0)
                {
                    foreach (DeckCourse deckCourse in deckCourses)
                    {
                        decks.Add(converterToDto.ConvertToDeckDTO(deckCourse.Deck));
                    }
                }
            }
            return decks;
        }
        
    }
}
