namespace ApplicationCore.Entities;

public class User
{
    public int Id { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Email { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string HashedPassword { get; set; } = string.Empty;
    public bool IsLocked { get; set; }
    public string LastName { get; set; } = string.Empty;
    public int PhoneNumber { get; set; }
    public string ProfilePictureUrl { get; set; } = string.Empty;
    public string Salt { get; set; } = string.Empty;
}