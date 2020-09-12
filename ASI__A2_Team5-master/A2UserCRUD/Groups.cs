using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace A2UserCRUD
{
    public class Groups
    {
        public int Group_id { get; set; }
        [Required]
        public Nullable<int> Group_No { get; set; }
        [Required]
        public String Group_Name { get; set; }
        [Required]
        public String Description { get; set; }
        [Required]
        public String Date_created { get; set; }
        [Required]
        public Nullable<int> Is_deleted { get; set; }

    }
}
