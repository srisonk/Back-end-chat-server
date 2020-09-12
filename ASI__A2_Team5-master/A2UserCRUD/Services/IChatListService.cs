using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A2UserCRUD.Services
{
    public interface IChatListService
    {
        public ChatList AddChatList(ChatList chatlist);

        public String DeleteChatList(String id);

        public List<ChatList> GetChatList();

        public ChatList UpdateChatList(String id, ChatList chatlist);

        public List<ChatList> GetChatListBySender(string id);
    }
}