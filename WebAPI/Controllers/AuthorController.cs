using AutoMapper;
using BusinessLayer.IService;
using DataLayer.Dtos.AuthorDtos;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;

        public AuthorController(IAuthorService authorService, IMapper mapper)
        {
            _authorService = authorService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetAllAuthors")]
        public async Task<ActionResult<IEnumerable<AuthorReadDto>>> GetAllAuthors()
        {
            var allItems = await _authorService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<AuthorReadDto>>(allItems));
        }

        [HttpGet("{id}", Name = "GetByAuthorId")]
        public async Task<ActionResult<AuthorReadDto>> GetByAuthorId(Guid id)
        {
            var item = await _authorService.GetByAuthorIdAsync(id);
            if (item != null)
            {
                return Ok(_mapper.Map<AuthorReadDto>(item));
            }
            return NotFound();
        }

        [HttpGet]
        [Route("CountOfArticle")]
        public ActionResult<int> CountOfArticle(Guid id)
        {
            return Ok(_authorService.CountOfArticle(id));
        }

        [HttpPost]
        [Route("CreateAuthor")]
        public async Task<ActionResult<AuthorReadDto>> CreateAuthor(AuthorCreateDto entity)
        {
            var item = _mapper.Map<Author>(entity);
            bool answare = await _authorService.CreateAsync(item);
            if (answare)
            {
                var articleReadDto = _mapper.Map<AuthorReadDto>(item);
                return CreatedAtRoute(nameof(GetByAuthorId), new { Id = articleReadDto.Id }, articleReadDto);
            }
            return BadRequest();
        }

        [HttpDelete("{id}", Name = "DeleteAuthor")]
        public ActionResult DeleteAuthor(Guid id)
        {
            var item = _authorService.GetByAuthorIdAsync(id).Result;
            if (item == null)
            {
                return NotFound();
            }
            bool request = _authorService.Delete(item);
            return NoContent();

        }

    }
}
