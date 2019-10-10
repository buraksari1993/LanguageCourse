using LanguageCourse.Dtos;
using LanguageCourse.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace LanguageCourse.Services
{
    public interface ILessonService
    {
        Task<bool> Add(LessonAddDto model);
        Task<IList<LessonGetDto>> Get(string name = null);
        Task<bool> Update(LessonUpdateDto model);
        Task<bool> Delete(Guid id);
    }
    public class LessonService:ILessonService
    {
        private LanguageCourseDBContext _context = null;

        public LessonService()
        {
            _context = new LanguageCourseDBContext();
        }

        public async Task<bool> Add(LessonAddDto model)
        {
            try
            {
                Lesson entity = new Lesson
                {
                    Id = Guid.NewGuid(),
                    Name = model.Name
                };

                _context.Lesson.Add(entity);
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
                var query = _context.Lesson.FirstOrDefault(x => x.Id == id);
                _context.Lesson.Remove(query);

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IList<LessonGetDto>> Get(string name = null)
        {
            var query = _context.Lesson.AsQueryable();

            if (!String.IsNullOrWhiteSpace(name))
                query = query.Where(x => x.Name.Contains(name));

            var result = await query
                .Select(s => new LessonGetDto
                {
                    Id = s.Id,
                    Name = s.Name
                })
                .ToListAsync();

            return result;
        }

        public async Task<bool> Update(LessonUpdateDto model)
        {
            try
            {
                var query = _context.Lesson.FirstOrDefault(x => x.Id == model.Id);
                query.Name = model.Name;

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