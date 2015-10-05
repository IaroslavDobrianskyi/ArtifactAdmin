// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RouteConfig.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the RouteConfig type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Web.Mvc;
using System.Web.Routing;

namespace ArtifactAdmin.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional });

            // will allow for Products/Item/2/1
            routes.MapRoute(
                    "withParams",
                    "{controller}/{action}/{id}/{p1}",
                    new { }
            );
        }
    }
}
