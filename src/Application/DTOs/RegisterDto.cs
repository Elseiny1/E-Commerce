using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class RegisterDto
    {
        public required string Phone { get; set; }

        public required string Email { get; set; }

        public required string Password { get; set; }

        public required string CheckPassword { get; set; }

        public string? Message { get; set; }
    }
}
