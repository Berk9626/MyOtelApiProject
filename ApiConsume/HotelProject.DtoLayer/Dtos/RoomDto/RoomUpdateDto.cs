using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DtoLayer.Dtos.RoomDto
{
    public class RoomUpdateDto
    {
        public int RoomId { get; set; }
        [Required(ErrorMessage = "Lütfen oda numarısını giriniz!")]//fluent validation kullanmazsak bu şekil belirteceğiz
        public string RoomNumber { get; set; }
        [Required(ErrorMessage = "Oda resmi girilmesi zorunludur!")]
        public string RoomCoverImage { get; set; }
        [Required(ErrorMessage = "Ücretin girilmesi zorunludur!")]
        public int Price { get; set; }
        [Required(ErrorMessage = "Oda başlığı ismi girilmesi zorunludur!")]
        [StringLength(100, ErrorMessage ="100 karakterden fazla veri girişi yapamazsınız!!")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Yatak sayısı girilmesi zorunludur!")]
        public string BadCount { get; set; }
        [Required(ErrorMessage = "Banyo sayısı girilmesi zorunludur!")]
        public string BathCount { get; set; }
        public string Wifi { get; set; }
        [Required(ErrorMessage = "Açıklama girilmesi zorunludur!")]
        public int Description { get; set; }

    }
}
