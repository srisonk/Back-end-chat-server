using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace A2UserCRUD
{
    public class UserGroups
    {
        public int UG_id { get; set; }
        [Required]
        public Nullable<int> User_id { get; set; }
        [Required]
        public Nullable<int> Group_id { get; set; }
    }
}
