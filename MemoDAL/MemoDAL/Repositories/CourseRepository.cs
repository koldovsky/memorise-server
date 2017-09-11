using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MemoDAL.Entities;
using MemoDAL.EF;

namespace MemoDAL.Repositories
{
    public class CourseRepository : BaseRepository<Course>
    {
        public CourseRepository(MemoContext context):base(context)
        {

        }
        public IEnumerable<Course> GetSomeAmount(int previousNumbersOfCourses, int numbersOfCoursesOnPage)
        {
            return MemoContext.Courses.OrderBy(course=>course.Id).Skip(previousNumbersOfCourses).Take(numbersOfCoursesOnPage).ToList();
        }
    }
}