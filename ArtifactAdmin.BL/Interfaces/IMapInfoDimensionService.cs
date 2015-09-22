using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtifactAdmin.BL.ModelsDTO;

namespace ArtifactAdmin.BL.Interfaces
{
    public interface IMapInfoDimensionService
    {
        IEnumerable<MapInfoDimensionDto> GetAll();
        MapInfoDimensionDto GetById(int? id);


        void Create(MapInfoDimensionDto mapInfoDimension);

        IEnumerable<MiddlePointDto> GetMiddlePointsForDimension(int? id);
    }
}
