using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HotelManagement.Models
{
    [Table("bill_tbl")]
    public class Bill{
        [Key]
        public int BillID { get; set; }
        public int BookingID { get; set; }
        public int CustomerID { get; set; }
        public double IncludeExpense { get; set; }
        public double Total { get; set; }
    }
}