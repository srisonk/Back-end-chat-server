using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace A2UserCRUD
{
    public class Mentee
    {
        public int Mentee_id { get; set; }
        [Required]
        public Nullable<int> User_id { get; set; }
        [Required]
        public Nullable<int> Mentor_id { get; set; }
        [Required]
        public String Qualification { get; set; }
    }
}
