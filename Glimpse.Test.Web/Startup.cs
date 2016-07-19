using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Glimpse.Test.Web.Startup))]
namespace Glimpse.Test.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
