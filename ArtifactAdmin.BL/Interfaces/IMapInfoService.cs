using System.Collections.Generic;
using ArtifactAdmin.BL.ModelsDTO;

namespace ArtifactAdmin.BL.Interfaces
{
    public interface IMapInfoService
    {
        MapInfoDto Create(MapInfoDto mapInfo);

        IEnumerable<MapInfoDto> GetAll();

        MapInfoDto GetById(int? id);
        MapInfoDto Update(MapInfoDto mapInfo);

        void Delete(int? id);
    }
}
