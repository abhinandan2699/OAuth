using Backend.Models;
using System.Text.Json;

namespace Backend.Services;

/// <summary>
/// Service for reading user data from JSON files
/// </summary>
public class UserService
{
    private readonly string _usersFilePath;
    private List<User> _users;

    public UserService(IConfiguration configuration)
    {
        // Get the database path from configuration or use default
        var databasePath = configuration["DatabasePath"] ?? "../../../database";
        _usersFilePath = Path.Combine(databasePath, "users.json");
        _users = new List<User>();
        LoadUsers();
    }

    /// <summary>
    /// Load users from JSON file
    /// </summary>
    private void LoadUsers()
    {
        try
        {
            if (File.Exists(_usersFilePath))
            {
                var json = File.ReadAllText(_usersFilePath);
                _users = JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading users: {ex.Message}");
            _users = new List<User>();
        }
    }

    /// <summary>
    /// Get user by email
    /// </summary>
    public User GetUserByEmail(string email)
    {
        return _users.FirstOrDefault(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>
    /// Get user by ID
    /// </summary>
    public User GetUserById(string id)
    {
        return _users.FirstOrDefault(u => u.Id == id);
    }

    /// <summary>
    /// Get all users
    /// </summary>
    public List<User> GetAllUsers()
    {
        return _users;
    }
}
