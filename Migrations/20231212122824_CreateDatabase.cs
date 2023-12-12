using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagement.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "booking_detail_tbl",
                columns: table => new
                {
                    BookingDetailID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BookingID = table.Column<int>(type: "INTEGER", nullable: false),
                    RoomTypeID = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_booking_detail_tbl", x => x.BookingDetailID);
                });

            migrationBuilder.CreateTable(
                name: "booking_tbl",
                columns: table => new
                {
                    BookingID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomerID = table.Column<int>(type: "INTEGER", nullable: false),
                    TimeStart = table.Column<int>(type: "INTEGER", nullable: false),
                    TimeEnd = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_booking_tbl", x => x.BookingID);
                });

            migrationBuilder.CreateTable(
                name: "customers_tbl",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserID = table.Column<int>(type: "INTEGER", nullable: false),
                    FullName = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers_tbl", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "room_booking_tbl",
                columns: table => new
                {
                    RoomBookingID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoomID = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderID = table.Column<int>(type: "INTEGER", nullable: false),
                    TimeStart = table.Column<int>(type: "INTEGER", nullable: false),
                    TimeEnd = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_room_booking_tbl", x => x.RoomBookingID);
                });

            migrationBuilder.CreateTable(
                name: "room_tbl",
                columns: table => new
                {
                    RoomID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoomTypeID = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    State = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_room_tbl", x => x.RoomID);
                });

            migrationBuilder.CreateTable(
                name: "roomtype_tbl",
                columns: table => new
                {
                    RoomTypeID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoomID = table.Column<int>(type: "INTEGER", nullable: false),
                    TypeName = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roomtype_tbl", x => x.RoomTypeID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "booking_detail_tbl");

            migrationBuilder.DropTable(
                name: "booking_tbl");

            migrationBuilder.DropTable(
                name: "customers_tbl");

            migrationBuilder.DropTable(
                name: "room_booking_tbl");

            migrationBuilder.DropTable(
                name: "room_tbl");

            migrationBuilder.DropTable(
                name: "roomtype_tbl");
        }
    }
}
