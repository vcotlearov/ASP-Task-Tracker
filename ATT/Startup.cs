using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ATT.Startup))]
namespace ATT
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
