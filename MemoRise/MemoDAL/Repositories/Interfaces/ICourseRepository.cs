using System;
using System.Collections.Generic;
using MemoDAL.Entities;

namespace MemoDAL.Repositories.Interfaces
{
    interface ICourseRepository: IRepository<Course>
    {
        IEnumerable<Course> GetSomeAmount(
            int previousNumbersOfCourses,
            int numbersOfCoursesOnPage);

        Course GetCourseWithDecks(Func<Course, Boolean> predicate);
    }
}
