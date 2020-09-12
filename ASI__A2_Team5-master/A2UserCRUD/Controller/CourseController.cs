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
    public class CourseController : ControllerBase
    {

        private ILogger _logger;
        private ICourseService _service;


        public CourseController(ILogger<CourseController> logger, ICourseService service)
        {
            _logger = logger;
            _service = service;

        }

        [HttpGet("/api/course")]
        public ActionResult<List<Course>> GetCourses()
        {
            return _service.GetCourses();
        }

        [HttpPost("/api/course")]
        public HttpResponseMessage AddCourse([FromBody]Course course)
        {
            {
                if (ModelState.IsValid)
                {
                    _service.AddCourse(course);
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
                else
                {
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);
                }
            }
        }

        [HttpPut("/api/course/{id}")]
        public ActionResult<Course> UpdateCourse(string id, [FromBody]Course course)
        {
            _service.UpdateCourse(id, course);
            return course;
        }

        [HttpDelete("/api/course/{id}")]
        public ActionResult<string> DeleteCourse(string id)
        {
            _service.DeleteCourse(id);
            //_logger.LogInformation("products", _products);
            return id;
        }
    }
}
