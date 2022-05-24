using System;
using System.Collections.Generic;

namespace DataLayer.Models
{
    //Fanlar nomlari
    public class Curriculum
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<Article> Articles { get; set; }
    }
}
