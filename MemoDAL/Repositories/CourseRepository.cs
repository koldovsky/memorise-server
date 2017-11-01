using MemoDAL.EF;
using MemoDAL.Entities;
using MemoDAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

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
            return MemoContext.Courses
                .OrderBy(course => course.Id)
                .Skip(previousNumbersOfCourses)
                .Take(numbersOfCoursesOnPage)
                .ToList();
        }

        public Course GetCourseWithDecks(Func<Course, bool> predicate)
        {
            return MemoContext.Set<Course>().Include("Decks")
                .FirstOrDefault(predicate);
        }
    }
}