using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HotelManagement.Models
{
    [Table("roomtype_tbl")]
    public class RoomType{
        [Key]
        public int RoomTypeID { get; set; }
        public int RoomID { get; set; }
        public string TypeName { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
    }
}