using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArtifactAdmin.Web.Models
{
    public class ZoneCoordinatesInfoModel
    {
        public int MapInfoId { get; set; }
        public string MapName { get; set; }
        [Display(Name = "Кількість ліній")]
        public int LinesCount { get; set; }
        

    }
}