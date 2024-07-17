using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AuthenticationController : ControllerBase
{
    private readonly FormManagementContext _context;

    public AuthenticationController(FormManagementContext context)
    {
        _context = context;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] User loginData)
    {
        var user = _context.Users
            .FirstOrDefault(u => u.Username == loginData.Username && u.Password == loginData.Password);

        if (user == null)
        {
            return Unauthorized(new { success = false, message = "Invalid username or password" });
        }

        return Ok(new { success = true });
    }
}
