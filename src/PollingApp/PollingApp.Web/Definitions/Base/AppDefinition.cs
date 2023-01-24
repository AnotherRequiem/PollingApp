namespace PollingApp.Web.Definitions.Base;

public class AppDefinition: IAppDefinition
{
    public virtual void ConfigureServices(IServiceCollection services, IConfiguration configuration) 
    { 

    }

    public virtual void ConfigureApplication(WebApplication app, IWebHostEnvironment environment) 
    {

    }
}