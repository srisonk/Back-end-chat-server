using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A2UserCRUD.Services
{
    public interface IGroupsService
    {
        public List<Groups> GetGroups();
        public Groups AddGroup(Groups group);
        public Groups UpdateGroup(string id, Groups group);
        public string DeleteGroup(string id);
    }
}
