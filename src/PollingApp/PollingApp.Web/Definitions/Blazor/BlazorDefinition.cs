using PollingApp.Web.Definitions.Base;

namespace PollingApp.Web.Definitions.Blazor;

public class CommonDefinition : AppDefinition
{
    public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddServerSideBlazor();
    }

    public override void ConfigureApplication(WebApplication app, IWebHostEnvironment environment)
    {
        app.MapBlazorHub();
    }
}