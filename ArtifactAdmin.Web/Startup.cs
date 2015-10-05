// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Startup.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the Startup type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using ArtifactAdmin.BL;
using ArtifactAdmin.Web;
using LightInject;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace ArtifactAdmin.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            AutoMapperConfiguration.Configure();
            var container = InjectionConfig.RegisterAllDependencies();
            container.RegisterControllers();
            container.EnableMvc();
        }
    }
}
