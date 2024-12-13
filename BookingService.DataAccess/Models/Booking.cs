using BookingService.DataAccess.IEntity.Interfaces;

namespace BookingService.DataAccess.Models;

public class Booking : IEntity<int>
{
    public int Id { get; set; }
    public int RoomId { get; set; } // the room booked
    public int CustomerId { get; set; } // the customer who booked
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }

}