using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace A2UserCRUD
{
    public class PageContent
    {
        public int Page_id { get; set; }
        [Required]
        public Nullable<int> User_id { get; set; }
        [Required]
        public String Text { get; set; }
        [Required]
        public Nullable<int> Type { get; set; }
        [Required]
        public String Date { get; set; }
        [Required]
        public Nullable<int> Is_deleted { get; set; }
    }

}