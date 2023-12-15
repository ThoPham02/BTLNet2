using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using HotelManagement.Models;

namespace HotelManagement.Models {
    public class BookingDetailViews {
        [Display(Name = "UserID")]
        public int UserID { get; set; }

        [Display(Name = "Họ và Tên")]
        public string FullName { get; set; }

        [Display(Name = "Số Điện Thoại")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Mã Loại Phòng")]
        public int RoomTypeID { get; set; }

        [Display(Name = "Loại Phòng")]
        public string RoomType { get; set; }

        [Display(Name = "Số Lượng")]
        public int Quantity { get; set; }

        [Display(Name = "Giá")]
        public int Price { get; set; }

        [Display(Name = "Check-In")]
        public DateTime TimeStart { get; set; }

        [Display(Name = "Check-Out")]
        public DateTime TimeEnd { get; set; }
    }
}