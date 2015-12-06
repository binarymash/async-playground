using BinaryMash.Playground.Async.AspNetHost;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Startup))]
namespace BinaryMash.Playground.Async.AspNetHost
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
