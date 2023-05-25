using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Stadium : Entity
    {
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(255)]
        public string Location { get; set; }
        public int Capacity { get; set; }
        public int YearBuilt { get; set; }
        
    }
}
