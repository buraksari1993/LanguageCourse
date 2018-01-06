using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using static LanguageCourse.Services.Const.Enum;

namespace LanguageCourse.Models
{
    public class User : IdentityUser
    {
        public UserType UserType { get; set; }

        //FK
        //Education
        public Guid EducationId { get; set; }
        public Education Education { get; set; }

        //Contact
        public Guid ContactId { get; set; }
        public virtual Contact Contact { get; set; }

        //Pay
        public virtual ICollection<Pay> Pays { get; set; }

        //CourseLink
        public virtual ICollection<CourseLink> CourseLinks { get; set; }

        //CertificateLink
        public virtual ICollection<CertificateLink> CertificateLinks { get; set; }

        public User()
        {
            Pays = new List<Pay>();
            CourseLinks = new List<CourseLink>();
            CertificateLinks = new List<CertificateLink>();
        }
    }
}