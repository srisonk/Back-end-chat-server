using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A2UserCRUD.Services
{
    public class GroupService : IGroupsService
    {
        private List<Groups> _groups;
        public GroupService()
        {
            _groups = new List<Groups>();
        }

        public Groups AddGroup(Groups group)
        {
            string query = "INSERT INTO `mentoringacademy`.`Groups` (Group_id, Group_No, Group_Name, Description, Date_created, Is_deleted) VALUES(" + group.Group_id + "," + group.Group_No + ", '" + group.Group_Name + "', '" + group.Description + "', '" + group.Date_created + "', " + group.Is_deleted + ")";
            var con = new DBConnect();
            con.Insert(query);

            return group;
            throw new NotImplementedException();
        }

        public string DeleteGroup(string id)
        {
            string query = "DELETE FROM `mentoringacademy`.`Groups` WHERE Group_id='" + id + "'";
            var con = new DBConnect();
            con.Delete(query);

            return id;
            throw new NotImplementedException();
        }

        public List<Groups> GetGroups()
        {
            string query = "SELECT * FROM `mentoringacademy`.`Groups`";
            var con = new DBConnect();
            var result = con.Select(query);
            List<Groups> _groups = result.AsEnumerable().Select(m => new Groups()
            {
                Group_id = m.Field<Int32>("Group_id"),
                Group_No = m.Field<Int32>("Group_No"),
                Group_Name = m.Field<string>("Group_Name"),
                Description = m.Field<string>("Description"),
                Date_created = m.Field<string>("Date_created"),
                Is_deleted = m.Field<Int32>("Is_deleted")
            }).ToList();

            return _groups;
            throw new NotImplementedException();
        }

        public Groups UpdateGroup(string id, Groups group)
        {
            string query = "UPDATE `mentoringacademy`.`Groups` SET Group_No='" + group.Group_No + "', Group_Name='" + group.Group_Name + "', Description='" + group.Description + "', Date_created='" + group.Date_created + "', Is_deleted='" + group.Is_deleted + "' WHERE Group_id='" + id + "'";
            var con = new DBConnect();
            con.Update(query);

            return group;
            throw new NotImplementedException();
        }

    }
}
