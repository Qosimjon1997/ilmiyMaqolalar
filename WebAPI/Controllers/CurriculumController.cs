using AutoMapper;
using BusinessLayer.IService;
using DataLayer.Dtos.CurriculumDtos;
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
    public class CurriculumController : ControllerBase
    {
        private readonly ICurriculumService _curriculumService;
        private readonly IMapper _mapper;

        public CurriculumController(ICurriculumService curriculumService, IMapper mapper)
        {
            _curriculumService = curriculumService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetAllCurriculums")]
        public async Task<ActionResult<IEnumerable<CurriculumReadDto>>> GetAllCurriculums()
        {
            var allItems = await _curriculumService.GetAllAsync();
            List<CurriculumReadDto> newList = new List<CurriculumReadDto>();

            foreach(var item in allItems)
            {
                CurriculumReadDto newItem = new CurriculumReadDto()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Count = _curriculumService.CountArticleInCurriculum(item.Id)
                };
                newList.Add(newItem);
            }
            return Ok(newList);
        }

        [HttpGet("{id}",Name = "GetByCurriculumId")]
        public async Task<ActionResult<CurriculumReadDto>> GetByCurriculumId(Guid id)
        {
            var item = await _curriculumService.GetByCurriculumIdAsync(id);
            if (item != null)
            {
                return Ok(_mapper.Map<CurriculumReadDto>(item));
            }
            return NotFound();
        }

        [Authorize(Roles = UserRoles.Manager)]
        [HttpPost]
        [Route("CreateCurriculum")]
        public async Task<ActionResult<CurriculumReadDto>> CreateCurriculum(CurriculumCreateDto curriculumCreateDto)
        {
            var item = _mapper.Map<Curriculum>(curriculumCreateDto);
            bool answare = await _curriculumService.CreateAsync(item);
            if(answare)
            {
                var curriculumReadDto = _mapper.Map<CurriculumReadDto>(item);
                return CreatedAtRoute(nameof(GetByCurriculumId), new { Id = curriculumReadDto.Id }, curriculumReadDto);
            }
            return BadRequest();
        }

        [Authorize(Roles = UserRoles.Manager)]
        [HttpDelete("{id}", Name = "DeleteCurriculum")]
        public ActionResult DeleteCurriculum(Guid id)
        {
            var item = _curriculumService.GetByCurriculumIdAsync(id).Result;
            if(item == null)
            {
                return NotFound();
            }
            bool request = _curriculumService.Delete(item);
            return NoContent();

        }
    }
}
