using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A2UserCRUD.Services
{
    public class SchoolService : ISchoolService
    {
        private List<School> _schools;

        public SchoolService()
        {
            _schools = new List<School>();
        }

        public School AddSchool(School school)
        {
            string query = "INSERT INTO `mentoringacademy`.`School` (School_id, School_name, Abbreviation) VALUES(" + school.School_id + ",'" + school.School_name + "', '" + school.Abbreviation + "')";
            var con = new DBConnect();
            con.Insert(query);

            return school;
            throw new NotImplementedException();
        }

        public string DeleteSchool(string id)
        {
            string query = "DELETE FROM `mentoringacademy`.`School` WHERE School_id='" + id + "'";
            var con = new DBConnect();
            con.Delete(query);

            return id;
            throw new NotImplementedException();
        }

        public List<School> GetSchools()
        {
            string query = "SELECT * FROM `mentoringacademy`.`School`";
            var con = new DBConnect();
            var result = con.Select(query);
            List<School> _schools = result.AsEnumerable().Select(m => new School()
            {
                School_id = m.Field<Int32>("School_id"),
                School_name = m.Field<string>("School_name"),
                Abbreviation = m.Field<string>("Abbreviation")
            }).ToList();

            return _schools;
            throw new NotImplementedException();
        }

        public School UpdateSchool(string id, School school)
        {
            string query = "UPDATE `mentoringacademy`.`School` SET School_name='" + school.School_name + "', Abbreviation='" + school.Abbreviation + "' WHERE School_id='" + id + "'";
            var con = new DBConnect();
            con.Update(query);

            return school;
            throw new NotImplementedException();
        }
    }
}
