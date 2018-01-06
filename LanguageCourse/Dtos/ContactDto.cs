using System;

namespace LanguageCourse.Dtos
{
    public class ContactAddDto
    {
        public string Phone { get; set; }
        public string Address { get; set; }
    }
    public class ContactUpdateDto
    {
        public Guid Id { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
    public class ContactGetDto
    {
        public Guid Id { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}