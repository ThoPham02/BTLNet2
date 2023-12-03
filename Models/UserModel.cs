using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HotelManagement.Models
{
    [Table("user_tbl")]
    public class User{
        [Key]
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string  Password { get; set; }
        public string  Birthday { get; set; }
        public string  Address { get; set; }
        public int Role { get; set; }
    }
}