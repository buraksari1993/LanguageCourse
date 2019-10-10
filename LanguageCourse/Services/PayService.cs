using LanguageCourse.Dtos;
using LanguageCourse.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace LanguageCourse.Services
{
    public interface IPayService
    {
        Task<bool> Add(PayAddDto model);
        Task<IList<PayGetDto>> Get();
        Task<bool> Update(PayUpdateDto model);
        Task<bool> Delete(Guid id);
    }
    public class PayService : IPayService
    {
        private LanguageCourseDBContext _context = null;
        public PayService()
        {
            _context = new LanguageCourseDBContext();
        }
        public async Task<bool> Add(PayAddDto model)
        {
            try
            {
                Pay entity = new Pay
                {
                    Id = Guid.NewGuid(),
                    PayType = model.PayType,
                    Total = model.Total,
                    CourseId = model.CourseId,
                    UserId = model.UserId
                };

                _context.Pay.Add(entity);
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
                var query = _context.Pay.FirstOrDefault(x => x.Id == id);
                _context.Pay.Remove(query);

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IList<PayGetDto>> Get()
        {
            var query = _context.Pay.AsQueryable();

            var result = await query
                .Select(s => new PayGetDto
                {
                    Id = s.Id,
                    PayType = s.PayType,
                    Total = s.Total,
                    CourseId = s.CourseId,
                    CourseName = s.Course.Name,
                    UserId = s.UserId,
                    UserName = s.User.UserName
                })
                .ToListAsync();

            return result;
        }

        public async Task<bool> Update(PayUpdateDto model)
        {
            try
            {
                var query = _context.Pay.FirstOrDefault(x => x.Id == model.Id);
                query.Total = model.Total;
                query.CourseId = model.CourseId;
                query.UserId = model.UserId;

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