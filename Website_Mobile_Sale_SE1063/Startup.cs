using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Website_Mobile_Sale_SE1063.Startup))]
namespace Website_Mobile_Sale_SE1063
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
