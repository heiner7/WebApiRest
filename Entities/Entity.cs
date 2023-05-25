using ApiRest.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public abstract class Entity : IEntity
    {
        public int Id { get; set; }
        public bool TareaCompleta { get; set; }
    }
}
