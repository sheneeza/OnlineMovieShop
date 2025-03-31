using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace MovieMVCApp.Controllers;

public class MoviesController : Controller
{
    private readonly IMovieService _movieService;

    public MoviesController(IMovieService movieService)
    {
        _movieService = movieService;
    }

    [HttpGet("movies/genre/{genreId}")]
    public async Task<IActionResult> ByGenre(int genreId, int page = 1, string sortBy = "title")
    {
        int pageSize = 30;
        
        var allMovies = await _movieService.GetMoviesByGenreSortedAsync(genreId, sortBy);
        var totalMovies = allMovies.Count();

        
        var pagedMovies = allMovies
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        
        ViewBag.GenreId = genreId;
        ViewBag.CurrentPage = page;
        ViewBag.SortBy = sortBy;
        ViewBag.TotalPages = (int)Math.Ceiling(totalMovies / (double)pageSize);
        ViewBag.TotalMovies = totalMovies;

        return View("ByGenre", pagedMovies);
    }

}

