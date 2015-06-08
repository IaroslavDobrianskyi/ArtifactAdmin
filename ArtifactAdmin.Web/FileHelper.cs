﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileHelper.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the FileHelper type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ArtifactAdmin.Web
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web;
    public class FileHelper
    {
        /// <summary>
        /// Save icon to server
        /// </summary>
        /// <param name="fileName">icon name from db</param>
        /// <param name="folder">folder name</param>
        /// <param name="icon">file name for save</param>
        public static string SaveIcon(string fileName, string folder, HttpPostedFileBase icon)
        {
            var pathToIcon = App_Start.ImagePath.ImPath;
            var path = Path.Combine(HttpContext.Current.Server.MapPath(pathToIcon + folder), fileName);
            try
            {
                icon.SaveAs(path);
            }
            catch(Exception)
            {
                return string.Empty;
            }
            return path;
        }
        /// <summary>
        /// delete icon from folder
        /// </summary>
        /// <param name="fileName">filename for delete</param>
        /// <param name="folder">folder with file for delete</param>
        public static void DeleteIcon(string fileName, string folder)
        {
            var pathToIcon = App_Start.ImagePath.ImPath;
            var path = Path.Combine(HttpContext.Current.Server.MapPath(pathToIcon + folder), fileName);
            FileInfo file = new FileInfo(path);
            if (file.Exists)
            {
                file.Delete();
            }
        }

    }
}