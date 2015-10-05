// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ImagePath.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the ImagePath type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Web.Configuration;

namespace ArtifactAdmin.Web.App_Start
{
    public static class ImagePath
    {
        static ImagePath() 
        {
            ImPath = WebConfigurationManager.AppSettings["ImagesPath"];
        }
       
        public static string ImPath { get; set; }
    }
}