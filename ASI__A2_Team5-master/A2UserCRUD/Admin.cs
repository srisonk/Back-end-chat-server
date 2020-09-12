using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace A2UserCRUD
{
    public class Admin
    {
        public int Admin_id { get; set; }
        [Required]
        public Nullable<int> User_id { get; set; }
    }
}
