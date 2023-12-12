using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HotelManagement.Models;

namespace HotelManagement.Data;

public class ApplicationDbContext : IdentityDbContext<User>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Bỏ tiền tố AspNet của các bảng: mặc định
        foreach (var entityType in builder.Model.GetEntityTypes())
        {
            var tableName = entityType.GetTableName();
            if (tableName.StartsWith("AspNet"))
            {
                entityType.SetTableName(tableName.Substring(6));
            }
        }
    }
    public DbSet<BookingDetail> BookingDetail{get; set;}
    public DbSet<Booking> Booking{get; set;}
    public DbSet<Customers> CustomersModels{get; set;}
    public DbSet<RoomBooking> RoomBooking{get; set;}
    public DbSet<Room> Room{get; set;}
    public DbSet<RoomType> RoomType{get; set;}
}