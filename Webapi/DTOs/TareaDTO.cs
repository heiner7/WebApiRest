using ApiRest.Abstraction;
using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebServices
{
    public class TareaDTO
    {
        public int Id { get; set; }
        [StringLength(70)]
        public string Titulo { get; set; }
        [StringLength(250)]
        public string Descripción { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
        public bool TareaCompleta { get; set; } = false;
        public DateTime? FechaTerminada { get; set; }
    }
}
