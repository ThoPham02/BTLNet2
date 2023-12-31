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
    public DbSet<BookingDetail> BookingDetail{get; set;}
    public DbSet<Booking> Booking{get; set;}
    public DbSet<Customers> Customers{get; set;}
    public DbSet<RoomBooking> RoomBooking{get; set;}
    public DbSet<Room> Room{get; set;}
    public DbSet<RoomType> RoomType{get; set;}
}
