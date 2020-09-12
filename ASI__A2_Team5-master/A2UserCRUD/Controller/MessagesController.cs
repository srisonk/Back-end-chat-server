using A2UserCRUD.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using A2UserCRUD;
using System.Net;
using System.Net.Http;
using System.Web;

namespace A2UserCRUD.Controller
{

    [ApiController]
    [Route("[controller]")]
    public class MessagesController:ControllerBase
    {
        private IMessagesService _service;

        public MessagesController(IMessagesService service)
        {
            _service = service;
        }

        [HttpGet("/api/messages")]
        public ActionResult<List<Messages>> GetMessages()
        {
            return _service.GetMessages();
        }

        [HttpPost("/api/messages")]
        public HttpResponseMessage AddMessages([FromBody]Messages message)
        {
            {
                if (ModelState.IsValid)
                {
                    _service.AddMessages(message);
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
                else
                {
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);
                }
            }
        }

        [HttpPut("/api/messages/{id}")]
        public ActionResult<Messages> UpdateMessages(String id, [FromBody]Messages message)
        {
            _service.UpdateMessages(id, message);
            return message;
        }

        [HttpDelete("/api/messages/{id}")]
        public ActionResult<String> DeleteMessages(String id)
        {
            _service.DeleteMessages(id);
            return id;
        }

    }
}
