using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using ApplicationCore.Repositories;

namespace Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        

        public async Task<IEnumerable<MovieCardModel>> GetTopMoviesAsync()
        {
            var movies = _movieRepository.GetTopRatedMovies(); 

            return movies
                .Take(24) 
                .Select(m => new MovieCardModel
                {
                    Id = m.Id,
                    Title = m.Title,
                    PosterUrl = string.IsNullOrEmpty(m.PosterUrl) ? "/images/default.jpg" : m.PosterUrl
                });
        }
        
        public Task<IEnumerable<MovieCardModel>> GetTopRatedMoviesAsync()
        {
            var movies = _movieRepository.GetTopRatedMovies().Take(24);

            var result = movies.Select(m => new MovieCardModel
            {
                Id = m.Id,
                Title = m.Title,
                PosterUrl = m.PosterUrl
            });

            return Task.FromResult(result);
        }

        public Task<IEnumerable<MovieCardModel>> GetMoviesByGenreAsync(int genreId)
        {
            var movies = _movieRepository.GetMoviesByGenre(genreId);

            var result = movies.Select(m => new MovieCardModel
            {
                Id = m.Id,
                Title = m.Title,
                PosterUrl = m.PosterUrl
            });

            return Task.FromResult(result);
        }
        
        public async Task<IEnumerable<MovieCardModel>> GetMoviesByGenreSortedAsync(int genreId, string sortBy)
        {
            var movies = _movieRepository.GetMoviesByGenre(genreId);

            movies = sortBy switch
            {
                "releaseDate" => movies.OrderByDescending(m => m.ReleaseDate),
                _ => movies.OrderBy(m => m.Title)
            };

            return await Task.FromResult(
                movies.Select(m => new MovieCardModel
                {
                    Id = m.Id,
                    Title = m.Title,
                    PosterUrl = m.PosterUrl
                })
            );
        }


    }
    
    
}