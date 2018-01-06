using System;
using static LanguageCourse.Services.Const.Enum;

namespace LanguageCourse.Dtos
{
    public class PayAddDto
    {
        public PayType PayType { get; set; }
        public double Total { get; set; }
        public Guid CourseId { get; set; }
        public string UserId { get; set; }
    }
    public class PayUpdateDto
    {
        public Guid Id { get; set; }
        public double Total { get; set; }
        public Guid CourseId { get; set; }
        public string UserId { get; set; }
    }
    public class PayGetDto
    {
        public Guid Id { get; set; }
        public PayType PayType { get; set; }
        public double Total { get; set; }
        public Guid CourseId { get; set; }
        public string CourseName { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
    }
}