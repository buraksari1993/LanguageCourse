using LanguageCourse.Dtos;
using LanguageCourse.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace LanguageCourse.Controllers
{
    [RoutePrefix("api/Pay")]
    public class PayController : ApiController
    {
        private IPayService _payService = null;
        public PayController()
        {
            _payService = new PayService();
        }

        [Route("Add")]
        public async Task<IHttpActionResult> Add(PayAddDto model)
        {
            bool result = await _payService.Add(model);

            if (!result)
                return BadRequest();

            return Ok();
        }

        [Route("Get"), ResponseType(typeof(IEnumerable<PayGetDto>))]
        public async Task<IHttpActionResult> Get()
        {
            var result = await _payService.Get();

            return Ok(result);
        }

        [Route("Update"), HttpPut]
        public async Task<IHttpActionResult> Update(PayUpdateDto model)
        {
            bool result = await _payService.Update(model);

            if (!result)
                return BadRequest();

            return Ok();
        }

        [Route("Delete")]
        public async Task<IHttpActionResult> Add(Guid id)
        {
            bool result = await _payService.Delete(id);

            if (!result)
                return BadRequest();

            return Ok();
        }

    }
}
