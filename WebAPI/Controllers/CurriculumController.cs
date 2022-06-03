using AutoMapper;
using BusinessLayer.IService;
using DataLayer.Dtos.CurriculumDtos;
using DataLayer.Models;
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
            return Ok(_mapper.Map<IEnumerable<CurriculumReadDto>>(allItems));
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
