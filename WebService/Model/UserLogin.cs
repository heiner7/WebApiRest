namespace WebService.Model
{
    public class UserLogin
    {
        public string? Token { get; set; }
        public bool Login { get; set; }
        public string? Rol { get; set; }
        public List<string>? Errors { get; set; }
    }
}
