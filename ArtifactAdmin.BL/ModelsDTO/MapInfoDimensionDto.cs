using System.ComponentModel.DataAnnotations;

namespace ArtifactAdmin.BL.ModelsDTO
{
    public class MapInfoDimensionDto
    {
        public int Id { get; set; }
        public int MapInfo { get; set; }
        [Display(Name = "Вимір карти")]
        public int Dimension { get; set; }

        public virtual MapInfoDto MapInfo1 { get; set; }
    }
}