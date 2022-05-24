using System;

namespace DataLayer.Models
{
    //maqola mualliflari
    public class SubAuthor
    {
        public Guid Id { get; set; }

        public Guid ArticleId { get; set; }
        public Article Article { get; set; }

        public Guid AuthorId { get; set; }
        public Author Author { get; set; }

        public string Who { get; set; }
    }
}
