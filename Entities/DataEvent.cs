using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class DataEvent : Entity
    {
        [StringLength(70)]
        public string TeamLocal { get; set; }
        [StringLength(70)]
        public string TeamVisit { get; set; }
        public string StadiumName { get; set; }
        public DateTime Date { get; set; }
        public string Result { get; set; }

    }
}
