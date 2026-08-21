namespace Backend.Models;

/// <summary>
/// Represents a user in the system
/// </summary>
public class User
{
    public string Id { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Role { get; set; }
    public string PasswordHash { get; set; }
    public string Salt { get; set; }
}
