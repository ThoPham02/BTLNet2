using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Areas.Admin.Models {
    public class RoomBookingViews{
        [Display(Name = "Mã Đặt Phòng")]
        public int RoomBookingID { get; set; }

        [Display(Name = "Phòng")]
        public string RoomName { get; set; }

        [Display(Name = "Ngày nhận")]
        public int TimeStart { get; set; }

        [Display(Name = "Ngày Trả")]
        public int TimeEnd { get; set; }

        [Display(Name = "Khách")]
        public string Customer { get; set; }

        [Display(Name = "Số điện thoại")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Trạng thái")]
        public int BookingStatus { get; set; }
    }
}