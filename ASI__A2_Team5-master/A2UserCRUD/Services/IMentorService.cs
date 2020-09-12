using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A2UserCRUD.Services
{
    public interface IMentorService
    {
        public List<Mentor> GetMentors();

        public Mentor AddMentor(Mentor mentor);

        public Mentor UpdateMentor(string id, Mentor mentor);

        public string DeleteMentor(string id);
    }
}
