    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace A2UserCRUD
{
    public class User
    {
        public int User_id { get; set; }

        [StringLength(50)]
        public String Username { get; set; }

        [RegularExpression("Male|Female|Other")]
        public String Gender { get; set; }

        [StringLength(50)]
        public String Nationality { get; set; }

        [StringLength(50)]
        public String Password { get; set; }

        [StringLength(10)] 
        public string Birthdate { get; set; }

        public Nullable<int> Course_id { get; set; }

        public String Profile { get; set; }

        public String Cover { get; set; }
    }
}
