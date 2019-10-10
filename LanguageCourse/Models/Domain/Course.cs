using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LanguageCourse.Models
{
    public class Course
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Comment { get; set; }

        //FK
        //Lesson
        public Guid LessonId { get; set; }
        public virtual Lesson Lesson { get; set; }

        //Certificate
        public virtual ICollection<Certificate> Certificates { get; set; }

        //Pay
        public virtual ICollection<Pay> Pays { get; set; }

        //CourseLink
        public virtual ICollection<CourseLink> CourseLinks { get; set; }

        public Course()
        {
            Certificates = new List<Certificate>();
            Pays = new List<Pay>();
            CourseLinks = new List<CourseLink>();
        }

    }
}