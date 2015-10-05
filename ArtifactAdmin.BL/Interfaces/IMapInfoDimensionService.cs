using System.Collections.Generic;
using ArtifactAdmin.BL.ModelsDTO;
using ArtifactAdmin.BL.Utils.GeneratingMiddlePoints;

namespace ArtifactAdmin.BL.Interfaces
{
    public interface IMapInfoDimensionService
    {
        IEnumerable<MapInfoDimensionDto> GetAll();
        MapInfoDimensionDto GetById(int? id);


        void Create(MapInfoDimensionDto mapInfoDimension);

        Dictionary<SimplePoint, List<SimplePoint>> GetMiddlePointsForDimension(int? id);
    }
}
