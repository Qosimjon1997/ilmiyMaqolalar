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
        public IEnumerable<SubAuthor> SubAuthors { get; set; }
        
        public Guid CurriculumId { get; set; }
        public Curriculum Curriculum { get; set; }
    }
}
