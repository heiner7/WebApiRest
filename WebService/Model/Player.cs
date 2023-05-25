using System.ComponentModel.DataAnnotations;

namespace WebService.Model
{
    public class Player
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string? Name { get; set; }
        [StringLength(200)]
        public string? LastName { get; set; }
        [StringLength(100)]
        public string? Position { get; set; }
        public int TeamId { get; set; }
    }
}
