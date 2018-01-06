using System;
using static LanguageCourse.Services.Const.Enum;

namespace LanguageCourse.Dtos
{
    public class EducationAddDto
    {
        public GraduationStatus GraduationStatus { get; set; }
        public string SchoolName { get; set; }
    }
    public class EducationUpdateDto
    {
        public Guid Id { get; set; }
        public GraduationStatus GraduationStatus { get; set; }
        public string SchoolName { get; set; }
    }
    public class EducationGetDto
    {
        public Guid Id { get; set; }
        public GraduationStatus GraduationStatus { get; set; }
        public string SchoolName { get; set; }
    }
}