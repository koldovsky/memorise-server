using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using MemoDAL.Entities;
using MemoDAL.EF;
using System;
using MemoDAL.Repositories.Interfaces;

namespace MemoDAL.Repositories
{
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        public CourseRepository(MemoContext context) : base(context)
        {
        }

        public IEnumerable<Course> GetSomeAmount(
            int previousNumbersOfCourses,
            int numbersOfCoursesOnPage)
        {
            return MemoContext.Courses.OrderBy(course => course.Id)
                .Skip(previousNumbersOfCourses).Take(numbersOfCoursesOnPage)
                .ToList();
        }

        public Course GetCourseWithDecks(Func<Course, Boolean> predicate)
        {
            return MemoContext.Set<Course>().Include("Decks")
                .FirstOrDefault(predicate);
        }
    }
}