using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtifactAdmin.BL.ModelsDTO;
using ArtifactAdmin.BL.Utils.GeneratingMiddlePoints;

namespace ArtifactAdmin.BL.Interfaces
{
    public interface IZoneCoordinatesService
    {
        Dictionary<string, List<SimplePoint>> GetZoneValuesCoordinatByMapInfoId(int? id);

        Dictionary<int, List<SimplePoint>> GetZoneIdCoordinatByMapInfoId(int? id);

        void CreateZoneCoordinates(int id);

        void Delete(int id);
    }
}
