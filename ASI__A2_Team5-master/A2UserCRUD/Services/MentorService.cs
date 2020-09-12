using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A2UserCRUD.Services
{
    public class MentorService : IMentorService
    {
        private List<Mentor> _mentors;

        public MentorService()
        {
            _mentors = new List<Mentor>();
        }
        public Mentor AddMentor(Mentor mentor)
        {
            string query = "INSERT INTO `mentoringacademy`.`Mentor` (Mentor_id, User_id, Qualification, Year_attended, Application_Motivation) VALUES(" + mentor.Mentor_id + ",'" + mentor.User_id + "', '" + mentor.Qualification + "', '" + mentor.Year_attended + "', '" + mentor.Application_Motivation + "')";
            var con = new DBConnect();
            con.Insert(query);

            return mentor;
            throw new NotImplementedException();
        }

        public string DeleteMentor(string id)
        {
            string query = "DELETE FROM `mentoringacademy`.`Mentor` WHERE Mentor_id='" + id + "'";
            var con = new DBConnect();
            con.Delete(query);

            return id;
            throw new NotImplementedException();
        }

        public List<Mentor> GetMentors()
        {
            string query = "SELECT * FROM `mentoringacademy`.`Mentor`";
            var con = new DBConnect();
            var result = con.Select(query);
            List<Mentor> _mentors = result.AsEnumerable().Select(m => new Mentor()
            {
                Mentor_id = m.Field<Int32>("Mentor_id"),
                User_id = m.Field<Int32>("User_id"),
                Qualification = m.Field<string>("Qualification"),
                Year_attended = m.Field<Int16>("Year_attended"),
                Application_Motivation = m.Field<string>("Application_Motivation")
            }).ToList();

            return _mentors;
            throw new NotImplementedException();
        }

        public Mentor UpdateMentor(string id, Mentor mentor)
        {
            string query = "UPDATE `mentoringacademy`.`Mentor` SET User_id='" + mentor.User_id + "', Qualification='" + mentor.Qualification + "', Year_attended='" + mentor.Year_attended + "', Application_Motivation='" + mentor.Application_Motivation + "' WHERE Mentor_id='" + id + "'";
            var con = new DBConnect();
            con.Update(query);

            return mentor;
            throw new NotImplementedException();
        }


    }
}
