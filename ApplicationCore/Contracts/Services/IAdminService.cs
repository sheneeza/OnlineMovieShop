using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services;

public interface IAdminService
{
    Task<IEnumerable<MovieCardModel>> GetTopMoviesAsync();
    Task<int> CreateMovieAsync(Movie movie);
}