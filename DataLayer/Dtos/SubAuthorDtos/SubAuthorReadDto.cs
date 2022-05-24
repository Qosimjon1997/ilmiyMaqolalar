﻿using System;

namespace DataLayer.Dtos.SubAuthorDtos
{
    public class SubAuthorReadDto
    {
        public Guid Id { get; set; }

        public Guid ArticleId { get; set; }

        public Guid AuthorId { get; set; }

        public string Who { get; set; }
    }
}
