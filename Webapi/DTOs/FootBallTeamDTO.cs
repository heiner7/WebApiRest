using ApiRest.Abstraction;
using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebServices
{
    public class FootBallTeamDTO
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
