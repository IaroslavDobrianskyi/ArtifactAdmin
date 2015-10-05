using System.ComponentModel.DataAnnotations;

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