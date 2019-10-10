using System;
using System.Collections.Generic;

namespace LanguageCourse.Models
{
    public class Contact
    {
        public Guid Id { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        //FK
        //User
        public virtual ICollection<User> Users { get; set; }
        public Contact()
        {
            Users = new List<User>();
        }
    }
}