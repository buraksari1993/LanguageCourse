using System;
using static LanguageCourse.Services.Const.Enum;

namespace LanguageCourse.Dtos
{
    public class UserAddDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserType UserType { get; set; }
        public Guid EducationId { get; set; }
        public Guid ContactId { get; set; }
    }
    public class UserUpdateDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public Guid EducationId { get; set; }
        public Guid ContactId { get; set; }

    }
    public class UserGetDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public UserType UserType { get; set; }
        public Guid EducationId { get; set; }
        public Guid ContactId { get; set; }

    }
}