using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LanguageCourse.Models
{
    public class Contact
    {
        public Guid Id { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        //FK
        //User
        //Icollection eklenecek
    }
}