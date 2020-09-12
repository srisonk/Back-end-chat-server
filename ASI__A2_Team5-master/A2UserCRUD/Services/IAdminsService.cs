using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A2UserCRUD.Services
{
    public interface IAdminsService
    {
        public List<Admin> GetAdmins();

        public Admin AddAdmin(Admin admin);

        public Admin UpdateAdmin(string id, Admin admin);

        public string DeleteAdmin(string id);
    }
}
