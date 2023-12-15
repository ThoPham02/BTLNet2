using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HotelManagement.Models
{
    public class AvailableRoomsModel
    {
        public List<object> AvailableRooms { get; set; }
    }
}