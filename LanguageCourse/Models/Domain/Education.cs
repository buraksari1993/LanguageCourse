using System;
using System.Collections.Generic;
using static LanguageCourse.Services.Const.Enum;

namespace LanguageCourse.Models
{
    public class Education
    {
        public Guid Id { get; set; }
        public GraduationStatus GraduationStatus { get; set; }
        public string SchoolName { get; set; }

        //FK
        //User
        public virtual ICollection<User> Users { get; set; }
        public Education()
        {
            Users = new List<User>();
        }
    }
}