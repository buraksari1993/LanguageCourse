using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LanguageCourse.Models
{
    public class CertificateLink
    {
        public Guid Id { get; set; }

        //FK
        //Certificate
        public Guid CertificateId { get; set; }
        public virtual Certificate Certificate { get; set; }
        public virtual ICollection<Certificate> Certificates { get; set; }

        //User
        //eklenecek

        public CertificateLink()
        {
            Certificates = new List<Certificate>();
        }
    }
}