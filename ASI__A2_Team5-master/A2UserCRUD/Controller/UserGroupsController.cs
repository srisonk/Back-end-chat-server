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
    public class UserGroupsController : ControllerBase
    {

        private ILogger _logger;
        private IUserGroups _service;


        public UserGroupsController(ILogger<UserGroupsController> logger, IUserGroups service)
        {
            _logger = logger;
            _service = service;

        }

        [HttpGet("/api/usergroups")]
        public ActionResult<List<UserGroups>> GetUserGroup()
        {
            return _service.GetUserGroups();
        }

        [HttpPost("/api/usergroups")]
        public HttpResponseMessage AddUserGroup([FromBody]UserGroups UG)
        {
            {
                if (ModelState.IsValid)
                {
                    _service.AddUserGroup(UG);
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
                else
                {
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);
                }
            }
        }

        [HttpPut("/api/usergroups/{id}")]
        public ActionResult<UserGroups> UpdateUserGroup(string id, [FromBody]UserGroups UG)
        {
            _service.UpdateUserGroup(id, UG);
            return UG;
        }

        [HttpDelete("/api/usergroups/{id}")]
        public ActionResult<string> DeleteUserGroup(string id)
        {
            _service.DeleteUserGroup(id);
            return id;
        }
    }
}
