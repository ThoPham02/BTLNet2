using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Areas.Admin.Models {
    public class RoomBookingViews{
        [Display(Name = "Phòng")]
        public string RoomName { get; set; }

        [Display(Name = "Ngày nhận")]
        public string TimeStart { get; set; }

        [Display(Name = "Ngày Trả")]
        public string TimeEnd { get; set; }

        [Display(Name = "Khách")]
        public string CustomerName { get; set; }

        [Display(Name = "Số điện thoại")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Trạng thái")]
        public string BookingStatus { get; set; }
    }
}