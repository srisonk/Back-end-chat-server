using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A2UserCRUD.Services
{
    public interface IUserGroups
    {
        public List<UserGroups> GetUserGroups();

        public UserGroups AddUserGroup(UserGroups UG);

        public UserGroups UpdateUserGroup(string id, UserGroups UG);

        public string DeleteUserGroup(string id);
    }
}
