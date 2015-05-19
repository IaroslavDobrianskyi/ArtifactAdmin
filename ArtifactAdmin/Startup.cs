using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ArtifactAdmin.Startup))]

namespace ArtifactAdmin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
