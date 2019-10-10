using LanguageCourse.Dtos;
using LanguageCourse.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace LanguageCourse.Services
{
    public interface IEducationService
    {
        Task<bool> Add(EducationAddDto model);
        Task<IList<EducationGetDto>> Get();
        Task<bool> Update(EducationUpdateDto model);
        Task<bool> Delete(Guid id);

    }
    public class EducationService : IEducationService
    {
        private LanguageCourseDBContext _context = null;
        public EducationService()
        {
            _context = new LanguageCourseDBContext();
        }
        public async Task<bool> Add(EducationAddDto model)
        {
            try
            {
                Education entity = new Education
                {
                    Id = Guid.NewGuid(),
                    GraduationStatus=model.GraduationStatus,
                    SchoolName=model.SchoolName
                };

                _context.Education.Add(entity);
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
                var query = _context.Education.FirstOrDefault(x => x.Id == id);
                _context.Education.Remove(query);

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IList<EducationGetDto>> Get()
        {
            var query = _context.Education.AsQueryable();

            var result = await query
                .Select(s => new EducationGetDto
                {
                    Id = s.Id,
                    GraduationStatus = s.GraduationStatus,
                    SchoolName = s.SchoolName
                })
                .ToListAsync();

            return result;
        }

        public async Task<bool> Update(EducationUpdateDto model)
        {
            try
            {
                var query = _context.Education.FirstOrDefault(x => x.Id == model.Id);
                query.GraduationStatus = model.GraduationStatus;
                query.SchoolName = model.SchoolName;

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