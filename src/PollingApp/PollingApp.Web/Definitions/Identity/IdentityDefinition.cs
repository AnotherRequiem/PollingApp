using Microsoft.AspNetCore.Authentication.Cookies;
using PollingApp.Web.Definitions.Base;

namespace PollingApp.Web.Definitions.Identity;

public class IdentityDefinition : AppDefinition
{
	public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
	{
		services
			.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
			.AddCookie(config =>
			{
				config.LoginPath = "/admin/login";
			});
	}
}