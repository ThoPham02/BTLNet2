using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HotelManagement.Models
{
    [Table("Customers_tbl")]
    public class Customers{
        [Key]
        public int CustomerID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string UserName{ get; set; }
        public string Passwork{ get; set; }
        public int Role{ get; set; }
    }
}