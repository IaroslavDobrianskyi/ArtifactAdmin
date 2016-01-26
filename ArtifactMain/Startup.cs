using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ArtifactMain.Startup))]
namespace ArtifactMain
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
