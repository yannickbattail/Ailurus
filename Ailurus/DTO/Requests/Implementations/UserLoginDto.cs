using System.ComponentModel.DataAnnotations;

namespace Ailurus.DTO.Requests.Implementations
{
    public class UserLoginDto
    {
        [Required]
        public string PlayerName { get; set; }
        
        [Required]
        public string Pass { get; set; }
    }
}