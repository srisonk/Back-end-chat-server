using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace A2UserCRUD
{
    public class Mentor
    {
        public int Mentor_id { get; set; }
        [Required]
        public Nullable<int> User_id { get; set; }
        [Required]
        public String Qualification { get; set; }
        [Required]
        public Nullable<int> Year_attended { get; set; }
        [Required]
        public String Application_Motivation { get; set; }
    }
}
