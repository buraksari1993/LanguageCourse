using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LanguageCourse.Dtos
{
    public class CertificateAddDto
    {
        public string Name { get; set; }
    }
    public class CertificateUpdateDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CourseId { get; set; }
    }
    public class CertificateGetDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CourseId { get; set; }
    }
}