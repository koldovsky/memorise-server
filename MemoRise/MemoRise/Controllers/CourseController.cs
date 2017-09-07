using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MemoRise.BLL;

namespace MemoRise.Controllers
{
    public class CourseController : ApiController
    {
        private CourseBll coursebll = new CourseBll();
        
        public IEnumerable<Course> GetAllCourses()
        {
            return coursebll.GetAllCourses();
        }

        public Course GetCategory(int id)
        {
            return coursebll.GetCourse(id);
        }

        public void PostCategory(Course item)
        {
            coursebll.AddCourse(item);
        }

        public bool PutCaregory(Course item)
        {
            return coursebll.UpdateCourse(item);
        }

        public void DeleteCaregory(int id)
        {
            coursebll.RemoveCourse(id);
        }
    }
}
