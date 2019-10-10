using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LanguageCourse.Models
{
    public class Lesson
    {
        public Guid Id { get; set; }
        [Required]
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