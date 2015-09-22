using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtifactAdmin.BL.ModelsDTO;

namespace ArtifactAdmin.BL.Interfaces
{
    public interface IMapInfoService
    {
        MapInfoDto Create(ModelsDTO.MapInfoDto mapInfo);

        IEnumerable<MapInfoDto> GetAll();

        MapInfoDto GetById(int? id);
        MapInfoDto Update(MapInfoDto mapInfo);

        void Delete(int? id);
    }
}
