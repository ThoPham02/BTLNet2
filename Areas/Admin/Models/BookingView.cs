using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using HotelManagement.Models;

namespace HotelManagement.Areas.Admin.Models {
    public class BookingViews {
        [Display(Name = "Mã Đặt Phòng")]
        public string BookingID { get; set; }

        [Display(Name = "Khách Hàng")]
        public string Name { get; set; }

        [Display(Name = "Số Điện Thoại")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Ngày nhận")]
        public string TimeStart { get; set; }

        [Display(Name = "Ngày Trả")]
        public string TimeEnd { get; set; }

        [Display(Name = "Chi tiết đơn")]
        public List<BookingDetail> BookingDetails { get; set; }

        [Display(Name = "Trạng thái")]
        public string BookingStatus { get; set; }
    }
}