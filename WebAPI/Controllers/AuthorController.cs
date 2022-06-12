using AutoMapper;
using BusinessLayer.IService;
using DataLayer.Dtos.AuthorDtos;
using DataLayer.Models;
using DataLayer.Models.Auth;
using Microsoft.AspNetCore.Authorization;
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
            List<AuthorReadDto> newList = new List<AuthorReadDto>();

            foreach (var item in allItems)
            {
                AuthorReadDto newItem = new AuthorReadDto()
                {
                    Id = item.Id,
                    Degree = item.Degree,
                    Email = item.Email,
                    Firstname = item.Firstname,
                    Passport = item.Passport,
                    Phone = item.Phone,
                    Secondname = item.Secondname,
                    Count = _authorService.CountArticleInAuthor(item.Id)
                };
                newList.Add(newItem);
            }
            return Ok(newList);
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

        [Authorize(Roles = UserRoles.Manager)]
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

        [Authorize(Roles = UserRoles.Manager)]
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
