using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LanguageCourse.Models
{
    public class Certificate
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        //FK
        //Course
        public Guid CourseId { get; set; }
        public virtual Course Course { get; set; }
    }
}