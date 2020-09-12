using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A2UserCRUD.Services
{
    public class MenteeService : IMenteeService
    {
        private List<Mentee> _mentees;

        public MenteeService()
        {
            _mentees = new List<Mentee>();
        }
        public Mentee AddMentee(Mentee mentee)
        {
            string query = "INSERT INTO `mentoringacademy`.`Mentee` (Mentee_id, User_id, Mentor_id, Qualification) VALUES(" + mentee.Mentee_id + "," + mentee.User_id + ", " + mentee.Mentor_id + ", '" + mentee.Qualification + "')";
            var con = new DBConnect();
            con.Insert(query);

            return mentee;
            throw new NotImplementedException();
        }
        public string DeleteMentee(string id)
        {
            string query = "DELETE FROM `mentoringacademy`.`Mentee` WHERE Mentee_id='" + id + "'";
            var con = new DBConnect();
            con.Delete(query);

            return id;
            throw new NotImplementedException();
        }

        public List<Mentee> GetMentees()
        {
            string query = "SELECT * FROM `mentoringacademy`.`Mentee`";
            var con = new DBConnect();
            var result = con.Select(query);
            List<Mentee> _mentees = result.AsEnumerable().Select(m => new Mentee()
            {
                Mentee_id = m.Field<Int32>("Mentee_id"),
                User_id = m.Field<Int32>("User_id"),
                Mentor_id = m.Field<Int32>("Mentor_id"),
                Qualification = m.Field<string>("Qualification")
            }).ToList();

            return _mentees;
            throw new NotImplementedException();
        }

        public Mentee UpdateMentee(string id, Mentee mentee)
        {
            string query = "UPDATE `mentoringacademy`.`Mentee` SET User_id='" + mentee.User_id + "', Mentor_id='" + mentee.Mentor_id + "', Qualification='" + mentee.Qualification + "' WHERE Mentee_id='" + id + "'";
            var con = new DBConnect();
            con.Update(query);

            return mentee;
            throw new NotImplementedException();
        }
    }
}
