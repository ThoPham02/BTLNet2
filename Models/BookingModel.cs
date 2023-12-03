using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HotelManagement.Models
{
    [Table("booking_tbl")]
    public class Booking{
        [Key]
        public int BookingID { get; set; }
        public int CustomerID { get; set; }
        public int TimeStart { get; set; }
        public int TimeEnd { get; set; }
        public int Status { get; set; }
    }
}