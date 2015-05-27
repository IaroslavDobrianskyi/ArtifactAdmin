// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RouteConfig.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the RouteConfig type.
// </summary>
// -------------------------------------------------------------------------------------------------------------------

namespace ArtifactAdmin
{
    using System;
    using System.Web.Mvc;
    using System.Web.Routing;

    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional });
        }
    }
}
