namespace PollingApp.Web.Definitions.Base;

public interface IAppDefinition
{
    void ConfigureServices(IServiceCollection services, IConfiguration configuration) { }

    void ConfigureApplication(WebApplication app, IWebHostEnvironment environment) { }
}