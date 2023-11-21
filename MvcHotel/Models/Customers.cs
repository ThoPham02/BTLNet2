using System.ComponentModel.DataAnnotations;

namespace MvcHotel.Models 
{
    public class Customers {
        [Key]
        public int Customer_id { get; set; }
        public string Full_name { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string Username { get; set; }
        public string Passwork { get; set; }

        //mặc định cho khách hàng là 2
        public int Role { get; set; } = 2;
    }
}