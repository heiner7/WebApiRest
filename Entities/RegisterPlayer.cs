using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class RegisterPlayer : Entity
    {
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(200)]
        public string LastName { get; set; }
        [StringLength(100)]
        public string Position { get; set; }
        public int TeamId { get; set; }
        public FootballTeam Team { get; set; }
    }
}
