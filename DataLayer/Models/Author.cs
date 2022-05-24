using System;
using System.Collections.Generic;

namespace DataLayer.Models
{
    //Avtor ma'lumotlari
    public class Author
    {
        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string Secondname { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
        public string Phone { get; set; }
        public string Passport { get; set; }
        public string Degree { get; set; }

        public IEnumerable<SubAuthor> SubAuthors { get; set; }

    }
}
