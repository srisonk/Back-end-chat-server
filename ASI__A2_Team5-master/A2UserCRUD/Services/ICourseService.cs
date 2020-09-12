using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A2UserCRUD.Services
{
    public interface ICourseService
    {
        public List<Course> GetCourses();

        public Course AddCourse(Course course);

        public Course UpdateCourse(string id, Course course);

        public string DeleteCourse(string id);
    }
}
