namespace ArtifactAdmin.Web.Models
{
    using System.Collections.Generic;
    using BL.ModelsDTO;

    public class MapInfoDimensionCreateModel
    {
        public MapInfoDimensionDto MapInfoDimensionDto { get; set; }
        public IEnumerable<MapInfoDto> AvailableMapInfos { get; set; }
    }
}