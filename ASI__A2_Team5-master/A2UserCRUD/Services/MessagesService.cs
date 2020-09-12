using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A2UserCRUD.Services
{
    public class MessagesService : IMessagesService
    {
        private List<Messages> _messages;

        public MessagesService()
        {
            _messages = new List<Messages>();
        }

        public Messages AddMessages(Messages message)
        {
            string query = "INSERT INTO `mentoringacademy`.`Messages` (Msg_id, Id_sender, Id_receiver, Content, TimeStamp, Url) VALUES(" + message.Msg_id + "," + message.Id_sender + ", " + message.Id_receiver + ", '" + message.Content + "', '" + message.TimeStamp + "', '" + message.Url + "')";
            var con = new DBConnect();
            con.Insert(query);

            return message;
            throw new NotImplementedException();
        }

        public String DeleteMessages(String id)
        {
            string query = "DELETE FROM `mentoringacademy`.`Messages` WHERE Msg_id='" + id + "'";
            var con = new DBConnect();
            con.Delete(query);

            return id;
            throw new NotImplementedException();
        }
        public List<Messages> GetMessages()
        {
            string query = "SELECT * FROM `mentoringacademy`.`Messages`";
            var con = new DBConnect();
            var result = con.Select(query);
            List<Messages> _messages = result.AsEnumerable().Select(m => new Messages()
            {
                Msg_id = m.Field<Int32>("Msg_id"),
                Id_sender = m.Field<Int32>("Id_sender"),
                Id_receiver = m.Field<Int32>("Id_receiver"),
                Content = m.Field<string>("Content"),
                TimeStamp = m.Field<string>("TimeStamp"),
                Url = m.Field<string>("Url")
            }).ToList();

            return _messages;
            throw new NotImplementedException();
        }

        public Messages UpdateMessages(String id, Messages message)
        {
            string query = "UPDATE `mentoringacademy`.`Messages` SET Id_sender='" + message.Id_sender + "', Id_receiver='" + message.Id_receiver + "', Content='" + message.Content + "', TimeStamp='" + message.TimeStamp + "', Url='" + message.Url + "' WHERE Msg_id='" + id + "'";
            var con = new DBConnect();
            con.Update(query);

            return message;
            throw new NotImplementedException();
        }


        
    }
}
