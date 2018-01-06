using LanguageCourse.Dtos;
using LanguageCourse.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace LanguageCourse.Controllers
{
    [RoutePrefix("api/Contact")]
    public class ContactController : ApiController
    {
        private IContactService _contactService = null;
        public ContactController()
        {
            _contactService = new ContactService();
        }

        [Route("Add")]
        public async Task<IHttpActionResult> Add(ContactAddDto model)
        {
            bool result = await _contactService.Add(model);

            if (!result)
                return BadRequest();

            return Ok();
        }

        [Route("Get"), ResponseType(typeof(IEnumerable<ContactGetDto>))]
        public async Task<IHttpActionResult> Get()
        {
            var result = await _contactService.Get();

            return Ok(result);
        }

        [Route("Update"), HttpPut]
        public async Task<IHttpActionResult> Update(ContactUpdateDto model)
        {
            bool result = await _contactService.Update(model);

            if (!result)
                return BadRequest();

            return Ok();
        }

        [Route("Delete")]
        public async Task<IHttpActionResult> Delete(Guid id)
        {
            bool result = await _contactService.Delete(id);

            if (!result)
                return BadRequest();

            return Ok();
        }
    }
}
