using LanguageCourse.Dtos;
using LanguageCourse.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace LanguageCourse.Services
{
    public interface ICertificateService
    {
        Task<bool> Add(CertificateAddDto model);
        Task<IList<CertificateGetDto>> Get();
        Task<bool> Update(CertificateUpdateDto model);
        Task<bool> Delete(Guid id);
    }
    public class CertificateService : ICertificateService
    {
        private LanguageCourseDBContext _context = null;
        public CertificateService()
        {
            _context = new LanguageCourseDBContext();
        }

        public async Task<bool> Add(CertificateAddDto model)
        {
            try
            {
                Certificate entity = new Certificate
                {
                    Id = Guid.NewGuid(),
                    Name = model.Name,
                    CourseId = model.CourseId
                };

                _context.Certificate.Add(entity);
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
                var query = _context.Course.FirstOrDefault(x => x.Id == id);
                _context.Course.Remove(query);

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IList<CertificateGetDto>> Get()
        {
            var query = _context.Certificate.AsQueryable();

            var result = await query
                .Select(s => new CertificateGetDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    CourseId = s.CourseId,
                    CourseName = s.Course.Name
                })
                .ToListAsync();

            return result;
        }

        public async Task<bool> Update(CertificateUpdateDto model)
        {
            try
            {
                var query = _context.Certificate.FirstOrDefault(x => x.Id == model.Id);
                query.Name = model.Name;
                query.CourseId = model.CourseId;

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