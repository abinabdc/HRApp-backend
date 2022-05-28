namespace Roomie.Dtos
{
    public class UserDto
    {
        public string Username { get; set; }
        public string Token { get; set; }
        public List<string> Roles { get; set; }
    }
}
