using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

[ApiController]
[Route("api/[controller]")]
public class FormController : ControllerBase
{
    private readonly FormManagementContext _context;

    public FormController(FormManagementContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetForms()
    {
        var forms = _context.FormModels.ToList();
        return Ok(forms);
    }

    [HttpPost]
    public IActionResult CreateForm([FromBody] FormModel form)
    {
        if (ModelState.IsValid)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized(new { success = false, message = "User ID not found" });
            }

            form.CreatedAt = DateTime.Now;
            form.UserId = int.Parse(userId);
            _context.FormModels.Add(form);
            _context.SaveChanges();
            return Ok(form);
        }
        return BadRequest(ModelState);
    }

}
