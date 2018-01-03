using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static LanguageCourse.Services.Const.Enum;

namespace LanguageCourse.Models
{
    public class Education
    {
        public Guid Id { get; set; }
        public GraduationStatus GraduationStatus { get; set; }
        public string SchoolName { get; set; }

        //FK
        //User
        //Icollection eklenecek
    }
}