using BookingService.DataAccess.DataAccess;
using BookingService.DataAccess.IRepository.Interfaces;
using BookingService.DataAccess.Repositories;

namespace BookingService.DataAccess.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly BookingDbContext _bookingContext;


    public IBookingRepository BookingRepository { get; }



    public UnitOfWork(BookingDbContext bookingContext)
    {
        _bookingContext = bookingContext;

        BookingRepository = new BookingRepository(bookingContext);

    }

    public async Task CompleteAsync()
    {
        await _bookingContext.SaveChangesAsync();
    }

    public async void Dispose()
    {
        await _bookingContext.DisposeAsync();
    }
}
