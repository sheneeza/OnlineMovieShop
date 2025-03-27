namespace ApplicationCore.Entities;

public class Movie
{
    public int Id { get; set; }
    public string BackdropUrl { get; set; } = string.Empty;
    public decimal Budget { get; set; }
    public string CreatedBy { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; }
    public string ImdbUrl { get; set; } = string.Empty;
    public string OriginalLanguage { get; set; } = string.Empty;
    public string Overview { get; set; } = string.Empty;
    public string PosterUrl { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string ReleaseDate { get; set; } = string.Empty;
    public decimal Revenue { get; set; }
    public int Runtime { get; set; }
    public string TagLine { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string TmdbUrl { get; set; } = string.Empty;
    public string UpdatedBy { get; set; } = string.Empty;
    public DateTime UpdatedDate { get; set; }
}