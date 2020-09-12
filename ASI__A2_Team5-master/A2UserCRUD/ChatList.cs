using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace A2UserCRUD
{
    public class ChatList
    {
        public int CL_id { get; set; }
        [Required]
        public Nullable<int> Id_sender { get; set; }
        [Required]
        public Nullable<int> Id_receiver { get; set; }
    }
}
