using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Areas.Admin.Models {
    public class RoomViews {
        [Display(Name = "Mã Phòng")]
        public int RoomID { get; set; }

        [Display(Name = "Phòng")]
        public string RoomName { get; set; }

        [Display(Name = "Loại Phòng")]
        public string RoomType { get; set; }

        [Display(Name = "Giá")]
        public int Price { get; set; }

        [Display(Name = "Trạng Thái")]
        public int State { get; set; }
    }
}