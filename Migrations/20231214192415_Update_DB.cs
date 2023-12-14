using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagement.Migrations
{
    /// <inheritdoc />
    public partial class Update_DB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookingID",
                table: "room_booking_tbl",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookingID",
                table: "room_booking_tbl");
        }
    }
}
