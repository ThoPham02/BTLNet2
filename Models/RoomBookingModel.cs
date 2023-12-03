using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HotelManagement.Models
{
    [Table("room_booking_tbl")]
    public class RoomBooking{
        [Key]
        public int RoomBookingID { get; set; }
        public int RoomID { get; set; }
        public int BookingID { get; set; }
        public int TimeStart { get; set; }
        public int TimeEnd { get; set; }
    }
}