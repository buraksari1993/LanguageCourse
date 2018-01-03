using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LanguageCourse.Models
{
    public class CourseLink
    {
        public Guid Id { get; set; }

        //FK
        //Course
        public Guid CourseId { get; set; }
        public virtual Course Course { get; set; }
        public virtual ICollection<Course> Courses { get; set; }

        //User
        //eklenecek

        public CourseLink()
        {
            Courses = new List<Course>();
        }
    }
}