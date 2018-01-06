using LanguageCourse.Dtos;
using LanguageCourse.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace LanguageCourse.Services
{
    public interface IUserService
    {
        Task<bool> Register(UserAddDto model);
        Task<IList<UserGetDto>> Get();
        Task<bool> Update(UserUpdateDto model);
        Task<bool> Delete(string id);
    }
    public class UserService : IUserService
    {
        private LanguageCourseDBContext _context = null;
        public UserService()
        {
            _context = new LanguageCourseDBContext();
        }

        public async Task<bool> Register(UserAddDto model)
        {
            try
            {
                User entity = new User
                {
                    UserName = model.Name,
                    Email = model.Email,
                    PasswordHash = model.Password,
                    UserType = model.UserType,
                    EducationId = model.EducationId,
                    ContactId = model.ContactId
                };

                _context.Users.Add(entity);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Delete(string id)
        {
            try
            {
                var query = _context.Users.FirstOrDefault(x => x.Id == id);
                _context.Users.Remove(query);

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IList<UserGetDto>> Get()
        {
            var query = _context.Users.AsQueryable();

            var result = await query
                .Select(s => new UserGetDto
                {
                    Id = s.Id,
                    Name = s.UserName,
                    Email = s.Email,
                    UserType = s.UserType,
                    EducationId = s.EducationId,
                    ContactId = s.ContactId
                })
                .ToListAsync();

            return result;
        }

        public async Task<bool> Update(UserUpdateDto model)
        {
            try
            {
                var query = _context.Users.FirstOrDefault(x => x.Id == model.Id);
                query.UserName = model.Name;
                query.PasswordHash = model.Password;
                query.EducationId = model.EducationId;
                query.ContactId = model.ContactId;

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