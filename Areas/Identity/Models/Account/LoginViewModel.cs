// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Areas.Identity.Models.AccountViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Phải nhập {0}")]
        [Display(Name = "địa chỉ email")]
        public string UserNameOrEmail { get; set; }


        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Phải nhập {0}")]
        [Display(Name = "địa chỉ email")]
        public string RegisterUserName { get; set; }


        [Required(ErrorMessage = "Phải nhập {0}")]
        [Display(Name = "địa chỉ email")]
        public string RegisterUserNameOrEmail { get; set; }


        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [DataType(DataType.Password)]
        public string RegisterPassword { get; set; }


        [Display(Name = "Lưu thông tin")]
        public bool RememberMe { get; set; }
    }
}
