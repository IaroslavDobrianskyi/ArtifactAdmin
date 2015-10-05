// <copyright file="FilterConfig.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the FilterConfig type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Web.Mvc;

namespace ArtifactAdmin.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
