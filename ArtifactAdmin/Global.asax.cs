// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Global.asax.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the MvcApplication type.
// </summary>
// -------------------------------------------------------------------------------------------------------------------

namespace ArtifactAdmin
{
    using System;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
