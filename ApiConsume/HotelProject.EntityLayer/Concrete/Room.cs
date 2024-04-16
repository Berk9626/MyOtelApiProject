using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelProject.EntityLayer.Concrete
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }
        public string RoomNumber { get; set; }
        public string RoomCoverImage { get; set; }
        public int Price { get; set; }
        public string Title { get; set; }
        public string BadCount { get; set; }
        public string BathCount { get; set; }
        public string Wifi { get; set; }
        public string Description { get; set; }

        


    }
}
