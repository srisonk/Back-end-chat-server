using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A2UserCRUD.Services
{
    public class ChatListService : IChatListService
    {
        private List<ChatList> _chatlists;

        public ChatListService()
        {
            _chatlists = new List<ChatList>();
        }

        public ChatList AddChatList(ChatList chatlist)
        {
            string query = "INSERT INTO `mentoringacademy`.`ChatList` (Id_sender, Id_receiver) VALUES(" + chatlist.Id_sender + ", " + chatlist.Id_receiver + ")";
            var con = new DBConnect();
            con.Insert(query);

            return chatlist;
            throw new NotImplementedException();
        }

        public String DeleteChatList(String id)
        {
            string query = "DELETE FROM `mentoringacademy`.`ChatList` WHERE CL_id='" + id + "'";
            var con = new DBConnect();
            con.Delete(query);

            return id;
            throw new NotImplementedException();
        }
        public List<ChatList> GetChatList()
        {
            string query = "SELECT * FROM `mentoringacademy`.`ChatList`";
            var con = new DBConnect();
            var result = con.Select(query);
            List<ChatList> _chatlists = result.AsEnumerable().Select(m => new ChatList()
            {
                CL_id = m.Field<Int32>("CL_id"),
                Id_sender = m.Field<Int32>("Id_sender"),
                Id_receiver = m.Field<Int32>("Id_receiver")
            }).ToList();

            return _chatlists;
            throw new NotImplementedException();
        }

        public ChatList UpdateChatList(String id, ChatList chatlist)
        {
            string query = "UPDATE `mentoringacademy`.`ChatList` SET Id_sender='" + chatlist.Id_sender + "', Id_receiver='" + chatlist.Id_receiver + "' WHERE CL_id='" + id + "'";
            var con = new DBConnect();
            con.Update(query);

            return chatlist;
            throw new NotImplementedException();
        }

        public List<ChatList> GetChatListBySender(string id)
        {
            string query = "SELECT DISTINCT Id_receiver, Id_sender FROM `mentoringacademy`.`ChatList` WHERE Id_sender='" + id + "'";
            var con = new DBConnect();
            var result = con.Select(query);
            List<ChatList> _chatlists = result.AsEnumerable().Select(m => new ChatList()
            {
                Id_sender = m.Field<Int32>("Id_sender"),
                Id_receiver = m.Field<Int32>("Id_receiver")
            }).ToList();

            return _chatlists;
            throw new NotImplementedException();
        }

    }
}
