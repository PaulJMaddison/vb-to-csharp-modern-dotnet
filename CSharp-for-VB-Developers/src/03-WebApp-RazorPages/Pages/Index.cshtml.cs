using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebAppRazorPages.Pages;

public class IndexModel : PageModel
{
    public DateTime Now { get; private set; } = DateTime.UtcNow;
    public string Message { get; private set; } = "Hello from Razor Pages!";

    public void OnGet()
    {
        Now = DateTime.UtcNow;
    }

    public IActionResult OnPost([FromForm] string? message)
    {
        Now = DateTime.UtcNow;
        Message = string.IsNullOrWhiteSpace(message) ? "Hello from Razor Pages!" : message.Trim();
        return Page();
    }
}
