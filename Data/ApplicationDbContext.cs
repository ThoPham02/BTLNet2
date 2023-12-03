using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HotelManagement.Models;

namespace HotelManagement.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<User> User{get; set;}
    public DbSet<Booking> Booking{get; set;}
    public DbSet<Room> Room{get; set;}
    public DbSet<Bill> Bill{get; set;}
    public DbSet<RoomBooking> RoomBooking{get; set;}
    public DbSet<BookingDetail> BookingDetail{get; set;}
}
