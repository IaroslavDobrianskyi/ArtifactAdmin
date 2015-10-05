namespace ArtifactAdmin.BL.Interfaces
{
    using System.Collections.Generic;
    using ModelsDTO;

    public interface IMapInfoService
    {
        MapInfoDto Create(MapInfoDto mapInfo);

        IEnumerable<MapInfoDto> GetAll();

        MapInfoDto GetById(int? id);
        MapInfoDto Update(MapInfoDto mapInfo);

        void Delete(int? id);
    }
}
