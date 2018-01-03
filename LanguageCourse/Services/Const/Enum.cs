using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LanguageCourse.Services.Const
{
    public class Enum
    {
        public enum GraduationStatus : byte
        {
            PrimaryEducation = 1,
            SecondaryEducation = 2,
            HighSchool = 3,
            University = 4,
            PostGraduate = 5,
            Doctorate = 6
        }
        public enum PayType : byte
        {
            Cash = 1,
            Transfer = 2,
            CreditCard = 3
        }
    }
}