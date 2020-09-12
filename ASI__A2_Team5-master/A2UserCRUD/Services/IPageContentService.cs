using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A2UserCRUD.Services
{
    public interface IPageContentService
    {
        public List<PageContent> GetPages();

        public PageContent AddPage(PageContent PC);

        public PageContent UpdatePage(string id, PageContent PC);

        public string DeletePage(string id);
    }
}
