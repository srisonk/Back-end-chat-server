using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A2UserCRUD.Services
{
    public interface IMenteeService
    {
        public List<Mentee> GetMentees();
        public Mentee AddMentee(Mentee mentee);

        public Mentee UpdateMentee(string id, Mentee mentee);

        public string DeleteMentee(string id);
    }
}
