using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtifactAdmin.BL.ModelsDTO;

namespace ArtifactAdmin.BL.Interfaces
{
    public interface IZoneCoordinatesService
    {
        IEnumerable<ZoneCoordinatDto> GetZoneCoordinatByMapInfoId(int? id);

        void CreateZoneCoordinates(int id);

        void Delete(int id);
    }
}
