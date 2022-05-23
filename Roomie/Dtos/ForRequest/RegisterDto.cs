using System.ComponentModel.DataAnnotations;

namespace Roomie.Dtos
{
    public class RegisterDto
    {
        [Required] public string Username { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 6)]
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string ContactNumber { get; set; }
        public string EsewaNumber { get; set; }
    }
}
