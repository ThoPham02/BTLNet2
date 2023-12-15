using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Areas.Admin.Models {
    public class RoomViews {
        [Display(Name = "Mã Phòng")]
        public string RoomID { get; set; }

        [Display(Name = "Phòng")]
        public string RoomName { get; set; }

        [Display(Name = "Loại Phòng")]
        public string RoomType { get; set; }

        [Display(Name = "Trạng Thái")]
        public string State { get; set; }
    }
}