using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.ServiceDto
{
    public class UpdateServiceDto
    {
        public int ServiceId { get; set; }
        [Required(ErrorMessage = "Servis ikon linki giriniz!")]
        public string ServiceIcon { get; set; }
        [Required(ErrorMessage = "Hzimet başlığı giriniz!")]
        [StringLength(100, ErrorMessage = "Hizmet başlığı en fazla 100 karakter")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Hzimet açıklaması giriniz!")]
        [StringLength(500, ErrorMessage = "Hizmet açıklaması en fazla 500 karakter")]
        public string Description { get; set; }
    }
}
