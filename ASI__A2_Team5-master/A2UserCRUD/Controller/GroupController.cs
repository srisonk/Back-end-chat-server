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
    public class GroupController : ControllerBase
    {

        private ILogger _logger;
        private IGroupsService _service;


        public GroupController(ILogger<GroupController> logger, IGroupsService service)
        {
            _logger = logger;
            _service = service;

        }

        [HttpGet("/api/groups")]
        public ActionResult<List<Groups>> GetGroups()
        {
            return _service.GetGroups();
        }

        [HttpPost("/api/groups")]
        public HttpResponseMessage AddGroup([FromBody]Groups group)
        {
            {
                if (ModelState.IsValid)
                {
                    _service.AddGroup(group);
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
                else
                {
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);
                }
            }
        }

        [HttpPut("/api/groups/{id}")]
        public ActionResult<Groups> UpdateGroup(string id, [FromBody]Groups group)
        {
            _service.UpdateGroup(id, group);
            return group;
        }

        [HttpDelete("/api/groups/{id}")]
        public ActionResult<string> DeleteGroup(string id)
        {
            _service.DeleteGroup(id);
            return id;
        }
    }
}
