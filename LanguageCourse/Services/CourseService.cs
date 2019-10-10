using LanguageCourse.Dtos;
using LanguageCourse.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace LanguageCourse.Services
{
    public interface ICourseService
    {
        Task<bool> Add(CourseAddDto model);
        Task<IList<CourseGetDto>> Get(string name = null);
        Task<bool> Update(CourseUpdateDto model);
        Task<bool> Delete(Guid id);

    }
    public class CourseService:ICourseService
    {
        private LanguageCourseDBContext _context = null;
        public CourseService()
        {
            _context = new LanguageCourseDBContext();
        }

        public async Task<bool> Add(CourseAddDto model)
        {
            try
            {
                Course entity = new Course
                {
                    Id = Guid.NewGuid(),
                    Name = model.Name,
                    Comment = model.Comment,
                    LessonId = model.LessonId
                };

                _context.Course.Add(entity);
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

        public async Task<IList<CourseGetDto>> Get(string name = null)
        {
            var query = _context.Course.AsQueryable();

            if (!String.IsNullOrWhiteSpace(name))
                query = query.Where(x => x.Name.Contains(name));

            var result = await query
                .Select(s => new CourseGetDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    Comment = s.Comment,
                    LessonId = s.LessonId,
                    LessonName = s.Lesson.Name
                })
                .ToListAsync();

            return result;
        }

        public async Task<bool> Update(CourseUpdateDto model)
        {
            try
            {
                var query = _context.Course.FirstOrDefault(x => x.Id == model.Id);
                query.Name = model.Name;
                query.Comment = model.Comment;
                query.LessonId = model.LessonId;

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