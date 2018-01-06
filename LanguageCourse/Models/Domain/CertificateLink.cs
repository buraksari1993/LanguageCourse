using System;

namespace LanguageCourse.Models
{
    public class CertificateLink
    {
        public Guid Id { get; set; }

        //FK
        //Certificate
        public Guid CertificateId { get; set; }
        public virtual Certificate Certificate { get; set; }
        
        //User
        public string UserId { get; set; }
        public virtual User User { get; set; }
    }   
}