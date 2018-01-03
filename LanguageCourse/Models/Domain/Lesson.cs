using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LanguageCourse.Models
{
    public class Lesson
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        //FK
        //Course
        public virtual ICollection<Course> Courses { get; set; }
        public Lesson()
        {
            Courses = new List<Course>();
        }
    }
}