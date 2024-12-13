using BookingService.DataAccess.Dtos;
using BookingService.DataAccess.Models;

namespace BookingService.DataAccess.IRepository.Interfaces;

public interface IBookingRepository : IRepository<Booking, int>
{
    

}