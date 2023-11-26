using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.ServiceDto
{
    public class CreateServiceDto
    {
        //public int ServiceId { get; set; }
        [Required(ErrorMessage ="Servis ikon linki giriniz!")]
        public string ServiceIcon { get; set; }
        [Required(ErrorMessage = "Hzimet başlığı giriniz!")]
        [StringLength(100, ErrorMessage ="Hizmet başlığı en fazla 100 karakter")]
        public string Title { get; set; }
        
        public string Description { get; set; }
    }
}
