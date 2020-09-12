using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace A2UserCRUD
{
    public class Messages
    {
        public int Msg_id { get; set; }
        [Required]
        public Nullable<int> Id_sender { get; set; }
        [Required]
        public Nullable<int> Id_receiver { get; set; }
        [Required]
        public String Content { get; set; }
        [Required]
        public String TimeStamp { get; set; }
        public String Url { get; set; } 
    }
}
