using LanguageCourse.Dtos;
using LanguageCourse.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace LanguageCourse.Controllers
{
    [RoutePrefix("api/Education")]
    public class EducationController : ApiController
    {
        private IEducationService _educationService = null;
        public EducationController()
        {
            _educationService = new EducationService();
        }

        [Route("Add")]
        public async Task<IHttpActionResult> Add(EducationAddDto model)
        {
            bool result = await _educationService.Add(model);

            if (!result)
                return BadRequest();

            return Ok();
        }

        [Route("Get"), ResponseType(typeof(IEnumerable<EducationGetDto>))]
        public async Task<IHttpActionResult> Get()
        {
            var result = await _educationService.Get();

            return Ok(result);
        }

        [Route("Update"), HttpPut]
        public async Task<IHttpActionResult> Update(EducationUpdateDto model)
        {
            var result = await _educationService.Update(model);

            if (!result)
                return BadRequest();

            return Ok();
        }

        [Route("Delete")]
        public async Task<IHttpActionResult> Delete(Guid id)
        {
            var result = await _educationService.Delete(id);

            if (!result)
                return BadRequest();

            return Ok();
        }
    }
}
