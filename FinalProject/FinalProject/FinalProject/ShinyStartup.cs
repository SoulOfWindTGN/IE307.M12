using Microsoft.Extensions.DependencyInjection;
using Shiny;

namespace FinalProject
{
    public class ShinyStartup : Shiny.ShinyStartup
    {
        public override void ConfigureServices(IServiceCollection services, IPlatform platform) => services.UseNotifications();
    }
}
