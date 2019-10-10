using System;
using System.Collections.Generic;

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

        //CertificateLink
        public virtual ICollection<CertificateLink> CertificateLinks { get; set; }

        public Certificate()
        {
            CertificateLinks = new List<CertificateLink>();
        }

    }
}