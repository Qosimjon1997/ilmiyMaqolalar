using System;

namespace DataLayer.Dtos.SubAuthorDtos
{
    public class SubAuthorCreateDto
    {
        public Guid ArticleId { get; set; }

        public Guid AuthorId { get; set; }

        public string Who { get; set; }
    }
}
