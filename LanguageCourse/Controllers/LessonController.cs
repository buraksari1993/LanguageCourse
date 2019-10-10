using LanguageCourse.Dtos;
using LanguageCourse.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace LanguageCourse.Controllers
{
    [RoutePrefix("api/Lesson")]
    public class LessonController : ApiController
    {
        private ILessonService _lessonService = null;
        public LessonController()
        {
            _lessonService = new LessonService();
        }

        [Route("Add")]
        public async Task<IHttpActionResult> Add(LessonAddDto model)
        {
            bool result = await _lessonService.Add(model);

            if (!result)
                return BadRequest();

            return Ok();
        }

        [Route("Get"), ResponseType(typeof(IEnumerable<LessonGetDto>))]
        public async Task<IHttpActionResult> Get(string name = null)
        {
            var result = await _lessonService.Get(name);

            return Ok(result);
        }

        [Route("Update"), HttpPut]
        public async Task<IHttpActionResult> Update(LessonUpdateDto model)
        {
            var result = await _lessonService.Update(model);

            if (!result)
                return BadRequest();

            return Ok();
        }

        [Route("Delete")]
        public async Task<IHttpActionResult> Delete(Guid id)
        {
            var result = await _lessonService.Delete(id);

            if (!result)
                return BadRequest();

            return Ok();
        }
    }
}
