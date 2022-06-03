using AutoMapper;
using BusinessLayer.IService;
using DataLayer.Dtos.ArticleDtos;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        [HttpPost]
        [Route("CreateArticle")]
        public async Task<ActionResult<ArticleReadDto>> CreateArticle(ArticleCreateDto entity)
        {
            var item = _mapper.Map<Article>(entity);
            bool answare = await _articleService.CreateAsync(item);
            if (answare)
            {
                var articleReadDto = _mapper.Map<ArticleReadDto>(item);
                return CreatedAtRoute(nameof(GetByArticleId), new { Id = articleReadDto.Id }, articleReadDto);
            }
            return BadRequest();
        }

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
