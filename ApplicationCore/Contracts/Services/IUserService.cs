using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services
{
    public interface IUserService
    {
        Task<IEnumerable<MovieCardModel>> GetPurchasedMoviesAsync(int userId);
        Task<IEnumerable<MovieCardModel>> GetFavoriteMoviesAsync(int userId);
        Task<UserProfileModel> GetUserProfileAsync(int userId);
    }
}