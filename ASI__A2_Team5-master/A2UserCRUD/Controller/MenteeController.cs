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
    public class MenteeController : ControllerBase
    {

        private ILogger _logger;
        private IMenteeService _service;


        public MenteeController(ILogger<MenteeController> logger, IMenteeService service)
        {
            _logger = logger;
            _service = service;

        }

        [HttpGet("/api/mentee")]
        public ActionResult<List<Mentee>> GetMentees()
        {
            return _service.GetMentees();
        }

        [HttpPost("/api/mentee")]
        public HttpResponseMessage AddMentee([FromBody]Mentee mentee)
        {
            {
                if (ModelState.IsValid)
                {
                    _service.AddMentee(mentee);
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
                else
                {
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);
                }
            }
        }

        [HttpPut("/api/mentee/{id}")]
        public ActionResult<Mentee> UpdateMentee(string id, [FromBody]Mentee mentee)
        {
            _service.UpdateMentee(id, mentee);
            return mentee;
        }

        [HttpDelete("/api/mentee/{id}")]
        public ActionResult<string> DeleteMentee(string id)
        {
            _service.DeleteMentee(id);
            return id;
        }
    }
}
