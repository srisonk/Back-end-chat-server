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
    public class SchoolController : ControllerBase
    {

        private ILogger _logger;
        private ISchoolService _service;


        public SchoolController(ILogger<SchoolController> logger, ISchoolService service)
        {
            _logger = logger;
            _service = service;

        }

        [HttpGet("/api/school")]
        public ActionResult<List<School>> Getschools()
        {
            return _service.GetSchools();
        }

        [HttpPost("/api/school")]
        public HttpResponseMessage AddSchool([FromBody]School school)
        {
            {
                if (ModelState.IsValid)
                {
                    _service.AddSchool(school);
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
                else
                {
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);
                }
            }
        }

        [HttpPut("/api/school/{id}")]
        public ActionResult<School> UpdateSchool(string id, [FromBody]School school)
        {
            _service.UpdateSchool(id, school);
            return school;
        }

        [HttpDelete("/api/school/{id}")]
        public ActionResult<string> DeleteSchool(string id)
        {
            _service.DeleteSchool(id);
            return id;
        }
    }
}
