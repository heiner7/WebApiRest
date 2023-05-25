using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ResultEvent : Entity
    {
        [StringLength(7)]
        public string Result { get; set; }
        public int EventId { get; set; }
        public Events Event { get; set; }
    }
}
