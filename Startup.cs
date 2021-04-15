using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OsobyZaginioneFinal.Startup))]
namespace OsobyZaginioneFinal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
