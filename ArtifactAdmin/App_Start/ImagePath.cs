using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace ArtifactAdmin.App_Start
{
    public static class ImagePath
    {
        static public string ImPath { get; set; }
        static ImagePath() 
        {
            //ImPath = WebConfigurationManager
            //    .AppSettings["ImagesPath"];
            ImPath = WebConfigurationManager.AppSettings["ImagesPath"];
        }
    }
}