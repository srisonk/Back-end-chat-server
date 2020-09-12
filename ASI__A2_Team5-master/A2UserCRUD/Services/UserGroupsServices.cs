using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A2UserCRUD.Services
{
    public class UserGroupsServices : IUserGroups
    {
        private List<UserGroups> _UGs;

        public UserGroupsServices()
        {
            _UGs = new List<UserGroups>();
        }

        public UserGroups AddUserGroup(UserGroups userGroup)
        {
            string query = "INSERT INTO `mentoringacademy`.`UserGroups` (UG_id, User_id, Group_id) VALUES(" + userGroup.UG_id + "," + userGroup.User_id + "," + userGroup.Group_id + ")";
            var con = new DBConnect();
            con.Insert(query);

            return userGroup;
            throw new NotImplementedException();
        }

        public string DeleteUserGroup(string id)
        {
            string query = "DELETE FROM `mentoringacademy`.`UserGroups` WHERE UG_id='" + id + "'";
            var con = new DBConnect();
            con.Delete(query);

            return id;
            throw new NotImplementedException();
        }

        public List<UserGroups> GetUserGroups()
        {
            string query = "SELECT * FROM `mentoringacademy`.`UserGroups`";
            var con = new DBConnect();
            var result = con.Select(query);
            List<UserGroups> _UGs = result.AsEnumerable().Select(m => new UserGroups()
            {
                UG_id = m.Field<Int32>("UG_id"),
                User_id = m.Field<Int32>("User_id"),
                Group_id = m.Field<Int32>("Group_id")
            }).ToList();

            return _UGs;
            throw new NotImplementedException();
        }

        public UserGroups UpdateUserGroup(string id, UserGroups userGroups)
        {
            string query = "UPDATE `mentoringacademy`.`UserGroups` SET User_id='" + userGroups.User_id + "', Group_id='" + userGroups.Group_id + "' WHERE UG_id='" + id + "'";
            var con = new DBConnect();
            con.Update(query);

            return userGroups;
            throw new NotImplementedException();
        }
    }
}
