using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class FootballTeam : Entity
    {
        [StringLength(70)]
        public string Name { get; set; }
        public int Foundation { get; set; }
        [StringLength(100)]
        public string City { get; set; }
        [StringLength(80)]
        public string Coach { get; set; }
    }
}
