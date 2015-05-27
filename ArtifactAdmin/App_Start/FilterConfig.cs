// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FilterConfig.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//  Defines the FilterConfig type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ArtifactAdmin
{
    using System.Web.Mvc;

    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
