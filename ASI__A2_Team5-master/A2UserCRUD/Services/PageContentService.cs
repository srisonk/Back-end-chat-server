using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A2UserCRUD.Services
{
    public class PageContentService : IPageContentService
    {

        private List<PageContent> _PC;

        public PageContentService()
        {
            _PC = new List<PageContent>();
        }

        public PageContent AddPage(PageContent PC)
        {
            string query = "INSERT INTO `mentoringacademy`.`PageContent` (Page_id, User_id, Text, Type, Date, Is_deleted) VALUES(" + PC.Page_id + ",'" + PC.User_id + "', '" + PC.Text + "', '" + PC.Type + "', '" + PC.Date + "', '" + PC.Is_deleted + "')";
            var con = new DBConnect();
            con.Insert(query);

            _PC.Add(PC);
            return PC;
            throw new NotImplementedException();
        }

        public string DeletePage(string id)
        {
            string query = "DELETE FROM `mentoringacademy`.`PageContent` WHERE Page_id='" + id + "'";
            var con = new DBConnect();
            con.Delete(query);

            return id;
            throw new NotImplementedException();
        }

        public List<PageContent> GetPages()
        {
            string query = "SELECT * FROM `mentoringacademy`.`PageContent`";
            var con = new DBConnect();
            var result = con.Select(query);
            List<PageContent> _PC = result.AsEnumerable().Select(m => new PageContent()
            {
                Page_id = m.Field<Int32>("Page_id"),
                User_id = m.Field<Int32>("User_id"),
                Text = m.Field<string>("Text"),
                Type = m.Field<Int32>("Type"),
                Date = m.Field<string>("Date"),
                Is_deleted = m.Field<Int32>("Is_deleted")
            }).ToList();

            return _PC;
            throw new NotImplementedException();
        }

        public PageContent UpdatePage(string id, PageContent PC)
        {
            string query = "UPDATE `mentoringacademy`.`PageContent` SET User_id='" + PC.User_id + "', Text='" + PC.Text + "', Type='" + PC.Type + "', Date='" + PC.Date + "', Is_deleted='" + PC.Is_deleted + "' WHERE Page_id='" + id + "'";
            var con = new DBConnect();
            con.Update(query);

            return PC;
            throw new NotImplementedException();
        }
    }
}
