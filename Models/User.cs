using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace HotelManagement.Models {

    public class User : IdentityUser {

        [MaxLength (100)]
        public string FullName { set; get; }

        [MaxLength (255)]
        public string Address { set; get; }

    }
}