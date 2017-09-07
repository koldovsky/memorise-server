using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MemoRise.DAL;

namespace MemoRise.BLL
{
    public class CourseBll
    {
        UnitOfWork unitOfWork = new UnitOfWork();

        public IEnumerable<Course> GetAllCourses()
        {
            throw new Exception();
        }
        public Course GetCourse(int courseId)
        {
            throw new Exception();
        }
        public void AddCourse(Course course)
        {
            throw new Exception();
        }
        public bool UpdateCourse(Course course)
        {
            throw new Exception();
        }
        public void RemoveCourse(int courseId)
        {
            throw new Exception();
        }
    }
}