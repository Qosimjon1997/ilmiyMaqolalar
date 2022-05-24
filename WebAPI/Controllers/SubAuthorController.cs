using AutoMapper;
using BusinessLayer.IService;
using DataLayer.Dtos.SubAuthorDtos;
using DataLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubAuthorController : ControllerBase
    {
        private readonly ISubAuthorService _subAuthorService;
        private readonly IMapper _mapper;

        public SubAuthorController(ISubAuthorService subAuthorService, IMapper mapper)
        {
            _subAuthorService = subAuthorService;
            _mapper = mapper;
        }

        
        [HttpGet]
        [Route("GetByArticleId")]
        public async Task<ActionResult<SubAuthorReadDto>> GetByArticleId(Guid id)
        {
            var item = await _subAuthorService.GetByAuthorIdAsync(id);
            if (item != null)
            {
                return Ok(_mapper.Map<SubAuthorReadDto>(item));
            }
            return NotFound();
        }

        [HttpGet]
        [Route("GetByAuthorId")]
        public async Task<ActionResult<SubAuthorReadDto>> GetByAuthorId(Guid id)
        {
            var item = await _subAuthorService.GetByAuthorIdAsync(id);
            if (item != null)
            {
                return Ok(_mapper.Map<SubAuthorReadDto>(item));
            }
            return NotFound();
        }

        [HttpPost(Name = "CreateSubAuthor")]
        public async Task<ActionResult<SubAuthorReadDto>> CreateSubAuthor(IEnumerable<SubAuthorCreateDto> entity)
        {
            var item = _mapper.Map<IEnumerable<SubAuthor>>(entity);
            bool answare = await _subAuthorService.CreateRangeAsync(item);
            if (answare)
            {
                var articleReadDto = _mapper.Map<SubAuthorReadDto>(item);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete(Name = "DeleteListSubAuthorById")]
        public ActionResult DeleteListSubAuthorById(IEnumerable<Guid> entity)
        {
            List<SubAuthor> subAuthors = new List<SubAuthor>();
            foreach (var item in entity)
            {
                subAuthors.Add(_subAuthorService.GetByIdAsync(item).Result);
            }

            if (subAuthors == null)
            {
                return NotFound();
            }
            bool request = _subAuthorService.Delete(subAuthors);

            return NoContent();
        }


    }
}
