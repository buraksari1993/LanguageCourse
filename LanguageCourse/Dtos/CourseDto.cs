using System;
using System.ComponentModel.DataAnnotations;

namespace LanguageCourse.Dtos
{
    public class CourseAddDto
    {
        [Required]
        public string Name { get; set; }
        public string Comment { get; set; }
        public Guid LessonId { get; set; }
    }
    public class CourseUpdateDto
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Comment { get; set; }
        public Guid LessonId { get; set; }
    }
    public class CourseGetDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public Guid LessonId { get; set; }
        public string LessonName { get; set; }
    }   
}