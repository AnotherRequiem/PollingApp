using PollingApp.Contracts;
using PollingApp.Web.Definitions.Base;
using PollingApp.Web.Infrastructure;

namespace PollingApp.Web.Definitions.DependencyContainer;

public class DependencyContainer: AppDefinition
{
    public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IPollService, PollService>();
    }
}