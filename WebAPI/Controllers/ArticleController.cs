using AutoMapper;
using BusinessLayer.IService;
using DataLayer.Dtos.ArticleDtos;
using DataLayer.Models;
using DataLayer.Models.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Document = Microsoft.Office.Interop.Word.Document;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _articleService;
        private readonly IMapper _mapper;

        public ArticleController(IArticleService articleService, IMapper mapper)
        {
            _articleService = articleService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetAllArticles")]
        public async Task<ActionResult<IEnumerable<ArticleReadDto>>> GetAllArticles()
        {
            var allItems = await _articleService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<ArticleReadDto>>(allItems));
        }

        [HttpGet("{id}", Name = "GetByArticleId")]
        public async Task<ActionResult<ArticleReadDto>> GetByArticleId(Guid id)
        {
            var item = await _articleService.GetByArticleIdAsync(id);
            if (item != null)
            {
                return Ok(_mapper.Map<ArticleReadDto>(item));
            }
            return NotFound();
        }

        [HttpGet]
        [Route("GetAllArticlesByAuthorId")]
        public async Task<ActionResult<IEnumerable<ArticleReadDto>>> GetAllArticlesByAuthorId(Guid id)
        {
            var itemList = await _articleService.GetAllArticlesByAuthorIdAsync(id);
            return Ok(_mapper.Map<IEnumerable<ArticleReadDto>>(itemList));
        }


        [HttpGet]
        [Route("GetAllArticlesByCurriculumId")]
        public async Task<ActionResult<IEnumerable<ArticleReadDto>>> GetAllArticlesByCurriculumId(Guid id)
        {
            var itemList = await _articleService.GetAllArticlesByCurriculumIdAsync(id);
            return Ok(_mapper.Map<IEnumerable<ArticleReadDto>>(itemList));
        }

        [Authorize(Roles = UserRoles.Manager)]
        [HttpPost]
        [Route("CreateArticle")]
        public async Task<ActionResult<ArticleReadDto>> CreateArticle(ArticleCreateDto entity)
        {
            Article article = new Article()
            {
                Topic = entity.Topic,
                FileName = entity.FileName,
                AuthorId = entity.AuthorId,
                CurriculumId = entity.CurriculumId,
                Anotation = entity.Anotation,
                PhotoPath = entity.PhotoPath,
                PublishedTime = DateTime.Now
            };

            bool answare = await _articleService.CreateAsync(article);
            if (answare)
            {
                var articleReadDto = _mapper.Map<ArticleReadDto>(article);
                return CreatedAtRoute(nameof(GetByArticleId), new { Id = articleReadDto.Id }, articleReadDto);
            }
            return BadRequest();
        }

        [Authorize(Roles = UserRoles.Manager)]
        [HttpDelete("{id}", Name = "DeleteArticle")]
        public ActionResult DeleteArticle(Guid id)
        {
            var item = _articleService.GetByArticleIdAsync(id).Result;
            if (item == null)
            {
                return NotFound();
            }
            bool request = _articleService.Delete(item);
            return NoContent();

        }


    }
}
