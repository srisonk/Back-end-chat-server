using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A2UserCRUD.Services
{
    public interface IMessagesService
    {
        public List<Messages> GetMessages();

        public Messages AddMessages(Messages message);

        public Messages UpdateMessages(String id, Messages message);

        public String DeleteMessages(String id);
    }
}