using LanguageCourse.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LanguageCourse.Dtos
{
    public class LessonAddDto
    {
        [Required]
        public string Name { get; set; }
    }
    public class LessonUpdateDto
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
    public class LessonGetDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}