using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PollingApp.Web.Pages.Admin;

public class LogoutModel : PageModel
{
    private readonly ILogger<LogoutModel> _logger;

    public LogoutModel(ILogger<LogoutModel> logger) => _logger = logger;

    public async Task<IActionResult> OnPost(string? returnUrl = null)
    {
        returnUrl ??= Url.Content("~/");
        await HttpContext.SignOutAsync();
        _logger.LogInformation("User logged out.");
        if (returnUrl != null)
        {
            return LocalRedirect(returnUrl);
        }

        return RedirectToPage();
    }
}
