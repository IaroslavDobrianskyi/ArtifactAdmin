// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Startup.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the Startup type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using ArtifactAdmin.Web;
using Microsoft.Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace ArtifactAdmin.Web
{
    using BL;
    using LightInject;
    using Owin;

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
