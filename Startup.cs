using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Cashflow.Startup))]
namespace Cashflow
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
