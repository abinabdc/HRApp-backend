using System.ComponentModel.DataAnnotations;

namespace Roomie.Dtos
{
    public class RegisterDto
    {
        [Required] public string Username { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 6)]
        public string Password { get; set; }
        public string Gender { get; set; }
        public string ContactNumber { get; set; }
        public int DepartmentId { get; set; }
        public string Position { get; set; }


    }
}
