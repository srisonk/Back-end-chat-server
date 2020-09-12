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
    public class ChatListController : ControllerBase
    {
        private IChatListService _service;

        public ChatListController(IChatListService service)
        {
            _service = service;
        }

        [HttpGet("/api/chatlist")]
        public ActionResult<List<ChatList>> GetChatList()
        {
            return _service.GetChatList();
        }

        [HttpPost("/api/chatlist")]
        public HttpResponseMessage AddChatList([FromBody] ChatList chatlist)
        {
            {
                if (ModelState.IsValid)
                {
                    _service.AddChatList(chatlist);
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
                else
                {
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);
                }
            }
        }

        [HttpPut("/api/chatlist/{id}")]
        public ActionResult<ChatList> UpdateChatList(String id, [FromBody] ChatList chatlist)
        {
            _service.UpdateChatList(id, chatlist);
            return chatlist;
        }

        [HttpDelete("/api/chatlist/{id}")]
        public ActionResult<String> DeleteChatList(String id)
        {
            _service.DeleteChatList(id);
            return id;
        }

        [HttpGet("/api/chatlist/{id}")]
        public ActionResult<List<ChatList>> GetChatListBySender(string id)
        {
            return _service.GetChatListBySender(id);
        }

    }
}