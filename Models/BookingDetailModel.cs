using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HotelManagement.Models
{
    [Table("booking_detail_tbl")]
    public class BookingDetail{
        [Key]
        public int BookingDetailID{ get; set; }
        public int BookingID { get; set; }
        public int RoomID { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}