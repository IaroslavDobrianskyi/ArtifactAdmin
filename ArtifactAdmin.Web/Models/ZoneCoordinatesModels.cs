namespace ArtifactAdmin.Web.Models
{
    using System.ComponentModel.DataAnnotations;

    public class ZoneCoordinatesInfoModel
    {
        public int MapInfoId { get; set; }
        public string MapName { get; set; }
        [Display(Name = "Кількість ліній")]
        public int LinesCount { get; set; }
        

    }
}