using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Areas.Admin.Models {
    public class CustomerViews {
        [Display(Name = "Mã Khách Hàng")]
        public string CustomerID { get; set; }

        [Display(Name = "Họ và Tên")]
        public string CustomerName { get; set; }

        [Display(Name = "Số Điện Thoại")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}