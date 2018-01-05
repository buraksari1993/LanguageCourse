using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static LanguageCourse.Services.Const.Enum;

namespace LanguageCourse.Dtos
{
    public class PayAddDto
    {
        public PayType PayType { get; set; }
        public double Total { get; set; }

        public class PayUpdateDto
        {
            public Guid Id { get; set; }
            public PayType PayType { get; set; }
            public double Total { get; set; }
            public Guid CourseId { get; set; }
            //UserId
        }
        public class PayGetDto
        {
            public Guid Id { get; set; }
            public PayType PayType { get; set; }
            public double Total { get; set; }
            public Guid CourseId { get; set; }
            //UserId
        }
    }
}