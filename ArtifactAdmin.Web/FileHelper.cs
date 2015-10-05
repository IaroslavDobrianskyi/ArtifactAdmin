// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileHelper.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the FileHelper type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.IO;
using System.Web;
using ArtifactAdmin.Web.App_Start;

namespace ArtifactAdmin.Web
{
    public class FileHelper
    {
        /// <summary>
        /// Save icon to server
        /// </summary>
        /// <param name="folder">folder name</param>
        /// <param name="icon">file name for save</param>
        /// <returns>
        /// fileName or string.Empty
        /// </returns>
        public static string SaveIcon(string folder, HttpPostedFileBase icon)
        {
            var fileName = Path.GetFileName(icon.FileName);
            fileName = Guid.NewGuid().ToString() + '_' + fileName;
            var pathToIcon = HttpContext.Current.Server.MapPath(ImagePath.ImPath + folder);
            try
            {
                if (!Directory.Exists(pathToIcon.ToString()))
                {
                    Directory.CreateDirectory(pathToIcon.ToString());
                }
            }
            catch (Exception)
            {
                return string.Empty;
            }

             var path = Path.Combine(pathToIcon, fileName);
            try
            {
                icon.SaveAs(path);
            }
            catch (Exception)
            {
                return string.Empty;
            }

            return fileName;
        }

        /// <summary>
        /// delete icon from folder
        /// </summary>
        /// <param name="fileName">filename for delete</param>
        /// <param name="folder">folder with file for delete</param>
        public static void DeleteIcon(string fileName, string folder)
        {
            var pathToIcon = ImagePath.ImPath;
            var path = Path.Combine(HttpContext.Current.Server.MapPath(pathToIcon + folder), fileName);
            FileInfo file = new FileInfo(path);
            if (file.Exists)
            {
                file.Delete();
            }
        }
    }
}