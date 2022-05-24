using System;

namespace DataLayer.Dtos.AuthorDtos
{
    public class AuthorReadDto
    {
        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string Secondname { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
        public string Phone { get; set; }
        public string Passport { get; set; }
        public string Degree { get; set; }
    }
}
