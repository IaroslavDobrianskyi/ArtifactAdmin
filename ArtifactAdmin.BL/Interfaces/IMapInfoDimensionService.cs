namespace ArtifactAdmin.BL.Interfaces
{
    using System.Collections.Generic;
    using ModelsDTO;
    using Utils.GeneratingMiddlePoints;

    public interface IMapInfoDimensionService
    {
        IEnumerable<MapInfoDimensionDto> GetAll();
        MapInfoDimensionDto GetById(int? id);


        void Create(MapInfoDimensionDto mapInfoDimension);

        Dictionary<SimplePoint, List<SimplePoint>> GetMiddlePointsForDimension(int? id);
    }
}
