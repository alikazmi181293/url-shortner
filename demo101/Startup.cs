using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(demo101.Startup))]
namespace demo101
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
