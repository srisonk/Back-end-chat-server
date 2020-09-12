using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace A2UserCRUD
{
    public class Course
    {
        public int Course_id { get; set; }
        [Required]
        public String Course_name { get; set; }
        [Required]
        public Nullable<int> School_id { get; set; }
    }
}
