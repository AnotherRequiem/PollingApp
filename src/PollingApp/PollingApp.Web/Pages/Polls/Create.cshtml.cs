using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PollingApp.Web.Pages.Polls;

[Authorize]
public class CreateModel : PageModel
{
    public void NoGet()
    {

    }
}
