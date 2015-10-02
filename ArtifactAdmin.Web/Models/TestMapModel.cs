using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArtifactAdmin.Web.Models
{
    public class TestMapModel
    {
        [Display(Name = "Назва карти")]
        public string MapName { get; set; }
        [Display(Name = "Ширина карти")]
        public int Width { get; set; }
        [Display(Name = "Висота карти")]
        public int Height { get; set; }
        [Display(Name = "Доступні виміри та радіуси")]
        public Dictionary<int, List<int>> AlaivableDimentionsAndRadiuses { get; set; }
        [Display(Name = "Час в мілісекундах")]
        public int MilisecondsToLoadMap { get; set; }
        
    }
}
