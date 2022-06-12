using System;

namespace DataLayer.Dtos.ArticleDtos
{
    public class ArticleCreateDto
    {
        //Maqola nomi
        public string Topic { get; set; }

        //Muallif 
        public Guid AuthorId { get; set; }

        public string FileName { get; set; }
        public string PhotoPath { get; set; }
        public string Anotation { get; set; }

        public Guid CurriculumId { get; set; }
    }
}
