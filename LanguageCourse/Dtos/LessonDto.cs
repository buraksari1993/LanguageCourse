using System;
using System.ComponentModel.DataAnnotations;

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