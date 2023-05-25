using System.ComponentModel.DataAnnotations;

namespace WebService.Model
{
    public class Tarea
    {
        public int Id { get; set; }
        [StringLength(70)]
        public string Titulo { get; set; }
        [StringLength(250)]
        public string Descripción { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
        public bool TareaCompleta { get; set; }
        public DateTime? FechaTerminada { get; set; }
    }
}
