using ApplicationCore.Entities;

namespace ApplicationCore.Repositories;

public interface IPurchaseRepository: IRepository<Purchase>
{
    Task<IEnumerable<Purchase>> GetPurchasesByUserAsync(int userId);

    Task<bool> IsMoviePurchasedByUserAsync(int movieId, int userId);
}