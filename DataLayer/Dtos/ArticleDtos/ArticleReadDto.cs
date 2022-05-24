using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Dtos.ArticleDtos
{
    public class ArticleReadDto
    {
        public Guid Id { get; set; }
        public string Topic { get; set; }
        public Guid CurriculumId { get; set; }
    }
}
