using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BinaryMash.AsyncPlayground.AspNetHost.Startup))]
namespace BinaryMash.AsyncPlayground.AspNetHost
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
