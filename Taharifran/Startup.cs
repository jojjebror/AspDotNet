using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Taharifran.Startup))]
namespace Taharifran
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
