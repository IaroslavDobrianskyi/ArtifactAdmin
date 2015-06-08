// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ImagePath.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the ImagePath type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ArtifactAdmin.Web.App_Start
{
    using System;
    using System.Web.Configuration;

    public static class ImagePath
    {
        static ImagePath() 
        {
            ImPath = WebConfigurationManager.AppSettings["ImagesPath"];
        }
       
        public static string ImPath { get; set; }
    }
}