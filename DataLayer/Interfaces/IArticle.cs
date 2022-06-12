using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface IArticle
    {
        public Task<IEnumerable<Article>> GetAllArticlesByAuthorId(Guid authorId);
        public Task<IEnumerable<Article>> GetAllArticlesByCurriculumId(Guid curriculumId);
    }
}
