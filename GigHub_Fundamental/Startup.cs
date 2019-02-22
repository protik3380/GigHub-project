using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GigHub_Fundamental.Startup))]
namespace GigHub_Fundamental
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
