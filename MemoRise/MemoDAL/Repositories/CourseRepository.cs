using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using MemoDAL.Entities;
using MemoDAL.EF;
using System;

namespace MemoDAL.Repositories
{
    public class CourseRepository : BaseRepository<Course>
    {
        public CourseRepository(MemoContext context) : base(context)
        {

        }
        public IEnumerable<Course> GetSomeAmount(int previousNumbersOfCourses, int numbersOfCoursesOnPage)
        {
            return MemoContext.Courses.OrderBy(course => course.Id).Skip(previousNumbersOfCourses).Take(numbersOfCoursesOnPage).ToList();
        }

        public Course GetCourseWithDecks(Func<Course, Boolean> predicate)
        {
            return MemoContext.Set<Course>().FirstOrDefault(predicate);
        }

    }
}