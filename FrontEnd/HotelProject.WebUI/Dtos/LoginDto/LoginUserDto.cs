using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.LoginDto
{
    public class LoginUserDto
    {
        [Required(ErrorMessage ="Username boş geçilemez")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Parola boş geçilemez")]
        public string Password { get; set; }
    }
}
