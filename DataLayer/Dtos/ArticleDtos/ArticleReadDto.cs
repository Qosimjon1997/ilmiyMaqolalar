using System;

namespace DataLayer.Dtos.ArticleDtos
{
    public class ArticleReadDto
    {
        public Guid Id { get; set; }

        //Maqola nomi
        public string Topic { get; set; }

        //Muallif 
        public Guid AuthorId { get; set; }
        public string AuthorFirstname { get; set; }
        public string AuthorSecondname { get; set; }

        public DateTime PublishedTime { get; set; }

        public string FileName { get; set; }
        public string PhotoPath { get; set; }
        public string Anotation { get; set; }

        public Guid CurriculumId { get; set; }
        public string CurriculumName { get; set; }
    }
}
