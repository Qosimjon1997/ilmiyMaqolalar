using System;
using System.Collections.Generic;

namespace DataLayer.Models
{
    //Maqolalar
    public class Article
    {
        public Guid Id { get; set; }
        
        //Maqola nomi
        public string Topic { get; set; }

        //Muallif 
        public Guid AuthorId { get; set; }
        public Author Author { get; set; }

        public string Anotation { get; set; }

        public string FileName { get; set; }

        public DateTime PublishedTime { get; set; }
        
        public Guid CurriculumId { get; set; }
        public Curriculum Curriculum { get; set; }

        public string PhotoPath { get; set; }
    }
}
