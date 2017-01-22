using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCBiblioteka.Startup))]
namespace MVCBiblioteka
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
