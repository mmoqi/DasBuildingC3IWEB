using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DasBuildingWeb.Startup))]
namespace DasBuildingWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
