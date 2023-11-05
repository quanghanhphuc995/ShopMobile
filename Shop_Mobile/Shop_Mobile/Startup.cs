using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Shop_Mobile.Startup))]
namespace Shop_Mobile
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
