using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A2UserCRUD.Services
{
    public interface ISchoolService
    {
        public List<School> GetSchools();

        public School AddSchool(School user);

        public School UpdateSchool(string id, School school);

        public string DeleteSchool(string id);
    }
}
