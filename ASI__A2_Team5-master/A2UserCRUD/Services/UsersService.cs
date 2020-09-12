using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using A2UserCRUD;
using System.Linq.Expressions;
using MySql.Data.MySqlClient;

namespace A2UserCRUD.Services
{
    public class UsersService : IUsersService
    {
        private List<User> _users;

        public UsersService()
        {
            _users = new List<User>();
        }

        public User AddUser(User user)
        {
            string query = "INSERT INTO `mentoringacademy`.`User` (Username, Gender, Nationality, Password, Birthdate, Course_id, Profile, Cover) VALUES('" + user.Username + "', '" + user.Gender + "', '" + user.Nationality + "', '" + user.Password + "', '" + user.Birthdate + "', '" + user.Course_id + "', '" + user.Profile + "', '" + user.Cover + "')";
            var con = new DBConnect();
            try {
                con.Insert(query);
                return user;
            }
            catch (MySqlException e)
            {
                System.Console.WriteLine(e.Message);
                return null;
            }
        }

        public string DeleteUser(string id)
        {
            string query = "DELETE FROM `mentoringacademy`.`User` WHERE User_id='" + id + "'";
            var con = new DBConnect();
            con.Delete(query);

            return id;
            throw new NotImplementedException();
        }

        public List<User> GetUsers()
        {
            string query = "SELECT * FROM `mentoringacademy`.`User`";
            var con = new DBConnect();
            var result = con.Select(query);
            List<User> _users = result.AsEnumerable().Select(m => new User()
            {
                User_id = m.Field<Int32>("User_id"),
                Username = m.Field<string>("Username"),
                Gender = m.Field<string>("Gender"),
                Nationality = m.Field<string>("Nationality"),
                Password = m.Field<string>("Password"),
                Birthdate = m.Field<string>("Birthdate"),
                Course_id = m.Field<Int32>("Course_id"),
                Profile = m.Field<string>("Profile"),
                Cover = m.Field<string>("Cover"),
            }).ToList();

            return _users;
            throw new NotImplementedException();
        }
        public List<User> GetUserById(string id)
        {
            string query = "SELECT * FROM `mentoringacademy`.`User` WHERE User_id='" + id + "'";
            var con = new DBConnect();
            var result = con.Select(query);
            List<User> _users = result.AsEnumerable().Select(m => new User()
            {
                User_id = m.Field<Int32>("User_id"),
                Username = m.Field<string>("Username"),
                Gender = m.Field<string>("Gender"),
                Nationality = m.Field<string>("Nationality"),
                Password = m.Field<string>("Password"),
                Birthdate = m.Field<string>("Birthdate"),
                Course_id = m.Field<Int32>("Course_id"),
                Profile = m.Field<string>("Profile"),
                Cover = m.Field<string>("Cover"),
            }).ToList();

            return _users;
            throw new NotImplementedException();
        }

        public User UpdateUser(string id, User user)
        {
            string query = "UPDATE `mentoringacademy`.`User` SET Username='" + user.Username + "', Gender='" + user.Gender + "', Nationality='" + user.Nationality + "', Password='" + user.Password + "', Birthdate='" + user.Birthdate + "', Course_id='" + user.Course_id + "', Profile='" + user.Profile + "', Cover='" + user.Cover + "' WHERE User_id='" + id + "'";
            var con = new DBConnect();
            con.Update(query);

            return user;
            throw new NotImplementedException();
        }

        public Nullable<int> AuthUser(User user)
        {
            Nullable<int> res;
            string query = "SELECT User_id FROM `mentoringacademy`.`User` WHERE Username='" + user.Username + "' AND Password='" + user.Password + "'";
            var con = new DBConnect();
            res = (Nullable<Int32>)con.RunSQL(query);
            if(res == null)
            {
                return 0;
            }
            else
            {
                return res;
            }
        }
    }
}
