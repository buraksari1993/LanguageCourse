using LanguageCourse.Dtos;
using LanguageCourse.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace LanguageCourse.Services
{
    public interface IContactService
    {
        Task<bool> Add(ContactAddDto model);
        Task<IList<ContactGetDto>> Get();
        Task<bool> Update(ContactUpdateDto model);
        Task<bool> Delete(Guid id);
    }
    public class ContactService : IContactService
    {
        private LanguageCourseDBContext _context = null;
        public ContactService()
        {
            _context = new LanguageCourseDBContext();
        }
        public async Task<bool> Add(ContactAddDto model)
        {
            try
            {
                Contact entity = new Contact
                {
                    Id = Guid.NewGuid(),
                    Phone = model.Phone,
                    Address = model.Address
                };

                _context.Contact.Add(entity);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Delete(Guid id)
        {
            try
            {
                var query = _context.Contact.FirstOrDefault(x => x.Id == id);
                _context.Contact.Remove(query);

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IList<ContactGetDto>> Get()
        {
            var query = _context.Contact.AsQueryable();

            var result = await query
                .Select(s => new ContactGetDto
                {
                    Id = s.Id,
                    Phone = s.Phone,
                    Address = s.Address
                })
                .ToListAsync();

            return result;
        }

        public async Task<bool> Update(ContactUpdateDto model)
        {
            try
            {
                var query = _context.Contact.FirstOrDefault(x => x.Id == model.Id);
                query.Phone = model.Phone;
                query.Address = model.Address;

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}