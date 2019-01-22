using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Agriculture.Startup))]
namespace Agriculture
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
