using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Tarea : Entity
    {
        [StringLength(70)]
        public string Titulo { get; set; }
        [StringLength(250)]
        public string Descripción { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
        public bool TareaCompleta { get; set; } = false;
        public DateTime? FechaTerminada { get; set; }
    }
}
