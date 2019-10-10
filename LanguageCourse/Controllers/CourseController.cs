using LanguageCourse.Dtos;
using LanguageCourse.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace LanguageCourse.Controllers
{
    [RoutePrefix("api/Course")]
    public class CourseController : ApiController
    {
        private ICourseService _courseService = null;
        public CourseController()
        {
            _courseService = new CourseService();
        }

        [Route("Add")]
        public async Task<IHttpActionResult> Add(CourseAddDto model)
        {
            bool result = await _courseService.Add(model);

            if (!result)
                return BadRequest();

            return Ok();
        }

        [Route("Get"), ResponseType(typeof(IEnumerable<CourseGetDto>))]
        public async Task<IHttpActionResult> Get(string name = null)
        {
            var result = await _courseService.Get(name);

            return Ok(result);
        }

        [Route("Update"), HttpPut]
        public async Task<IHttpActionResult> Update(CourseUpdateDto model)
        {
            var result = await _courseService.Update(model);

            if (!result)
                return BadRequest();

            return Ok();
        }

        [Route("Delete")]
        public async Task<IHttpActionResult> Delete(Guid id)
        {
            var result = await _courseService.Delete(id);

            if (!result)
                return BadRequest();

            return Ok();
        }
    }
}
