namespace BookingService.DataAccess.IRepository.Interfaces;

public interface IRepository<TEntity, TId>
{
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task AddAsync(TEntity entity);
    
}