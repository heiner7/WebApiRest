using System.ComponentModel.DataAnnotations;

namespace WebService.Model
{
    public class Login
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
