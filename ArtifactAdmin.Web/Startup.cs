// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Startup.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the Startup type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Microsoft.Owin;
using ArtifactAdmin.Web;

[assembly: OwinStartup(typeof(ArtifactAdmin.Web.Startup))]

namespace ArtifactAdmin.Web
{
    using System;
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
