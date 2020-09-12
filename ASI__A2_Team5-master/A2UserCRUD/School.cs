using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace A2UserCRUD
{
    public class School
    {
        public int School_id { get; set; }
        [Required]
        public String School_name { get; set; }
        [Required]
        public String Abbreviation { get; set; }
    }
}
