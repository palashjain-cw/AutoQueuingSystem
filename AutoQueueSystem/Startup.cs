using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AutoQueueSystem.Startup))]
namespace AutoQueueSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
