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
    public class UsersController : ControllerBase
    {

        private ILogger _logger;
        private IUsersService _service;


        public UsersController(ILogger<UsersController> logger, IUsersService service)
        {
            _logger = logger;
            _service = service;

        }

        [HttpGet("/api/users")]
        public ActionResult<List<User>> GetUsers()
        {
            return _service.GetUsers();
        }

        [HttpGet("/api/users/{id}")]
        public ActionResult<List<User>> GetUserById(string id)
        {
            return _service.GetUserById(id);
        }

        [HttpPost("/api/users")]
        //public HttpResponseMessage AddUser([FromBody]User user)
        public string AddUser([FromBody]User user)
        {
            if (user.Username == null || user.Password == null)
            {
                return "0";
            }
            else
            {
                //return new HttpResponseMessage(HttpStatusCode.BadRequest);
                if (_service.AddUser(user) == null)
                {
                    //return new HttpResponseMessage(HttpStatusCode.BadRequest);
                    return "2";
                }
                else
                {
                    //return new HttpResponseMessage(HttpStatusCode.OK);
                    return "1";
                }
            }
        }

        [HttpPut("/api/users/{id}")]
        public ActionResult<User> UpdateUser(string id, [FromBody]User user)
        {
            _service.UpdateUser(id, user);
            return user;
        }

        [HttpDelete("/api/users/{id}")]
        public ActionResult<string> DeleteUser(string id)
        {
            _service.DeleteUser(id);
            return id;
        }
        
        [HttpPost("/api/users/auth/")]
        public ActionResult<Nullable<Int32>> AuthUser([FromBody]User user)
        {
            return _service.AuthUser(user);
        }
    }
}
