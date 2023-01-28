using Calabonga.UnitOfWork;
using PollingApp.Web.Definitions.Base;

namespace PollingApp.Web.Definitions.UnitOfWork;

public class UnitOfWorkDefinition :AppDefinition
{
    public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddUnitOfWork<ApplicationDbContext>();
    }
}