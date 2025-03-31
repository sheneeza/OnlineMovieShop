using ApplicationCore.Entities;

namespace ApplicationCore.Repositories;

public interface IPurchaseRepository: IRepository<Purchase>
{
    Task<IEnumerable<Movie>> GetMoviesPurchasedByUser(int userId);
}