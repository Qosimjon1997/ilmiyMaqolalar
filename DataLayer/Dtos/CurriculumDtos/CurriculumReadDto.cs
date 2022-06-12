using System;

namespace DataLayer.Dtos.CurriculumDtos
{
    public class CurriculumReadDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
    }
}
