using BookingService.DataAccess.DataAccess;
using BookingService.DataAccess.Dtos;
using BookingService.DataAccess.IRepository.Interfaces;
using BookingService.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingService.DataAccess.Repositories;

public class BookingRepository(BookingDbContext context) : IBookingRepository
{
    public async Task<IEnumerable<Booking>> GetAllAsync()
    {
        return await context.Set<Booking>().ToListAsync();
    }

    public async Task AddAsync(Booking booking)
    {
        await context.Set<Booking>().AddAsync(booking);
    }


}