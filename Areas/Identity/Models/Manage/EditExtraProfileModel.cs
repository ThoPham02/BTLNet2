using System;
using System.ComponentModel.DataAnnotations;

namespace HotelManagement.Areas.Identity.Models.ManageViewModels
{
  public class EditExtraProfileModel
  {
      [Display(Name = "Tên tài khoản")]
      public string UserName { get; set; }

      [Display(Name = "Địa chỉ email")]
      public string UserEmail { get; set; }

      [Display(Name = "Số điện thoại")]
      public string PhoneNumber { get; set; }

      [Display(Name = "Tên đầy đủ")]
      [StringLength(100)]
      public string FullName { get; set; }

      [Display(Name = "Địa chỉ")]
      [StringLength(400)]
      public string Address { get; set; }


  }
}