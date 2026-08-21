using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly UserService _userService;
    private readonly ILogger<UserController> _logger;

    public UserController(UserService userService, ILogger<UserController> logger)
    {
        _userService = userService;
        _logger = logger;
    }

    /// <summary>
    /// Get current authenticated user's profile
    /// Extracts email from JWT claims and returns user details
    /// </summary>
    [HttpGet("profile")]
    public IActionResult GetProfile()
    {
        try
        {
            // Get email from JWT claims
            var emailClaim = User.FindFirst(ClaimTypes.Email);
            if (emailClaim == null)
            {
                _logger.LogWarning("Email claim not found in token");
                return Unauthorized(new { message = "Email claim not found in token" });
            }

            var email = emailClaim.Value;
            _logger.LogInformation($"Getting profile for user: {email}");

            // Find user by email
            var user = _userService.GetUserByEmail(email);
            if (user == null)
            {
                _logger.LogWarning($"User not found: {email}");
                return NotFound(new { message = "User not found" });
            }

            // Return user profile (without password hash/salt)
            return Ok(new
            {
                id = user.Id,
                email = user.Email,
                firstName = user.FirstName,
                lastName = user.LastName,
                role = user.Role
            });
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error in GetProfile: {ex.Message}");
            return StatusCode(500, new { message = "Internal server error" });
        }
    }
}
