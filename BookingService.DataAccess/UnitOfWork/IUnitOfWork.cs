using BookingService.DataAccess.IRepository.Interfaces;

namespace BookingService.DataAccess.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    IBookingRepository BookingRepository { get; }

    Task CompleteAsync();
}