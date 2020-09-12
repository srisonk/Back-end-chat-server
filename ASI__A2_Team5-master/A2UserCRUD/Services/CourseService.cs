using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using A2UserCRUD;


namespace A2UserCRUD.Services
{
    public class CourseService : ICourseService
    {
        private List<Course> _courses;

        public CourseService()
        {
            _courses = new List<Course>();
        }

        public Course AddCourse(Course course)
        {
            string query = "INSERT INTO `mentoringacademy`.`Course` (Course_id, Course_name, School_id) VALUES(" + course.Course_id + ",'" + course.Course_name + "', '" + course.School_id + "')";
            var con = new DBConnect();
            con.Insert(query);

            return course;
            throw new NotImplementedException();
        }

        public string DeleteCourse(string id)
        {
            string query = "DELETE FROM `mentoringacademy`.`Course` WHERE Course_id='" + id + "'";
            var con = new DBConnect();
            con.Delete(query);

            return id;
            throw new NotImplementedException();
        }

        public List<Course> GetCourses()
        {
            string query = "SELECT * FROM `mentoringacademy`.`Course`";
            var con = new DBConnect();
            var result = con.Select(query);
            List<Course> _courses = result.AsEnumerable().Select(m => new Course()
            {
                Course_id = m.Field<Int32>("Course_id"),
                Course_name = m.Field<string>("Course_name"),
                School_id = m.Field<Int32>("School_id")
            }).ToList();

            return _courses;
            throw new NotImplementedException();
        }

        public Course UpdateCourse(string id, Course course)
        {
            string query = "UPDATE `mentoringacademy`.`Course` SET Course_name='" + course.Course_name + "', School_id='" + course.School_id + "' WHERE Course_id='" + id + "'";
            var con = new DBConnect();
            con.Update(query);

            return course;
            throw new NotImplementedException();
        }
    }
}
