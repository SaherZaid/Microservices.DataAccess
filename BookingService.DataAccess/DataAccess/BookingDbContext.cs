using BookingService.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingService.DataAccess.DataAccess;

public class BookingDbContext : DbContext
{
    public DbSet<Booking> Bookings { get; set; }


    public BookingDbContext(DbContextOptions options) : base(options)
    {
    }
}