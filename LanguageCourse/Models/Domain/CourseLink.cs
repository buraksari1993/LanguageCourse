using System;

namespace LanguageCourse.Models
{
    public class CourseLink
    {
        public Guid Id { get; set; }

        //FK
        //Course
        public Guid CourseId { get; set; }
        public virtual Course Course { get; set; }

        //User
        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}