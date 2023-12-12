using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HotelManagement.Models
{
    [Table("bookingdetail_tbl")]
    public class BookingDetail{
        [Key]
        public int BookingDetailID { get; set; }
        public int RoomID { get; set; }
        public int RoomNumber { get; set; }
        public int Price { get; set; }
        public int Time {get; set;}
    }
}