namespace BookingService.DataAccess.IEntity.Interfaces;

public interface IEntity<T>
{
    T Id { get; set; }
}