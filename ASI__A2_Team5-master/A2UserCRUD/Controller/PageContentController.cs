using A2UserCRUD.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Web;

namespace A2UserCRUD.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class PageContentController : ControllerBase
    {

        private ILogger _logger;
        private IPageContentService _service;


        public PageContentController(ILogger<PageContentController> logger, IPageContentService service)
        {
            _logger = logger;
            _service = service;

        }

        [HttpGet("/api/pagecontent")]
        public ActionResult<List<PageContent>> GetPages()
        {
            return _service.GetPages();
        }

        [HttpPost("/api/pagecontent")]
        public HttpResponseMessage AddPage([FromBody]PageContent page)
        {
            {
                if (ModelState.IsValid)
                {
                    _service.AddPage(page);
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
                else
                {
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);
                }
            }
        }

        [HttpPut("/api/pagecontent/{id}")]
        public ActionResult<PageContent> UpdatePage(string id, [FromBody]PageContent page)
        {
            _service.UpdatePage(id, page);
            return page;
        }

        [HttpDelete("/api/pagecontent/{id}")]
        public ActionResult<string> DeletePage(string id)
        {
            _service.DeletePage(id);
            return id;
        }
    }
}
