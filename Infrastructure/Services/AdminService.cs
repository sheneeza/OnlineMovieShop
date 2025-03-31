using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using ApplicationCore.Repositories;

namespace Infrastructure.Services;

public class AdminService : IAdminService
{
    private readonly IMovieRepository _movieRepository;

    public AdminService(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    public async Task<IEnumerable<MovieCardModel>> GetTopMoviesAsync()
    {
        var movies = _movieRepository.GetTopRatedMovies().Take(24);

        var result = movies.Select(m => new MovieCardModel
        {
            Id = m.Id,
            Title = m.Title,
            PosterUrl = m.PosterUrl
        });

        return await Task.FromResult(result);
    }

    public async Task<int> CreateMovieAsync(Movie movie)
    {
        return await Task.FromResult(_movieRepository.Insert(movie));
    }
}
