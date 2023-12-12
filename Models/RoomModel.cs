using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HotelManagement.Models
{
    [Table("room_tbl")]
    public class Room{
        [Key]
        public int RoomID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int State { get; set; }
    }
}