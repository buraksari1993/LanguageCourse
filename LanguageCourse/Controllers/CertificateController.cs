using LanguageCourse.Dtos;
using LanguageCourse.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace LanguageCourse.Controllers
{
    [RoutePrefix("api/Certificate")]
    public class CertificateController : ApiController
    {
        private ICertificateService _certificateService = null;
        public CertificateController()
        {
            _certificateService = new CertificateService();
        }
        [Route("Add")]
        public async Task<IHttpActionResult> Add(CertificateAddDto model)
        {
            bool result = await _certificateService.Add(model);

            if (!result)
                return BadRequest();

            return Ok();
        }

        [Route("Get"), ResponseType(typeof(IEnumerable<CertificateGetDto>))]
        public async Task<IHttpActionResult> Get()
        {
            var result = await _certificateService.Get();

            return Ok(result);
        }

        [Route("Update"), HttpPut]
        public async Task<IHttpActionResult> Update(CertificateUpdateDto model)
        {
            var result = await _certificateService.Update(model);

            if (!result)
                return BadRequest();

            return Ok();
        }

        [Route("Delete")]
        public async Task<IHttpActionResult> Delete(Guid id)
        {
            var result = await _certificateService.Delete(id);

            if (!result)
                return BadRequest();

            return Ok();
        }
    }
}
