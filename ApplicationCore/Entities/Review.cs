namespace ApplicationCore.Entities;

public class Review
{
    public int MovieId { get; set; }
    public Movie Movie { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }

    public DateTime CreatedDate { get; set; }
    public decimal Rating { get; set; }
    public string ReviewText { get; set; } = string.Empty;
}
