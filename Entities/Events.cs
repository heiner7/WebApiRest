using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Events : Entity
    {
        public DateTime Date { get; set; }
        public int StadiumId { get; set; }
        public int TeamId1 { get; set; }
        public int TeamId2 { get; set; }
        public FootballTeam Team { get; set; }
        public Stadium Stadium { get; set; }
    }
}
