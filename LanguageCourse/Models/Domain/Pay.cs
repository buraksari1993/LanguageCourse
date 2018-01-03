using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static LanguageCourse.Services.Const.Enum;

namespace LanguageCourse.Models
{
    public class Pay
    {
        public Guid Id { get; set; }
        public PayType PayType { get; set; }
        public double Total { get; set; }

        //FK
        //Course
        public Guid CourseId { get; set; }
        public virtual Course Course { get; set; }

        //User
        //eklenecek

    }
}