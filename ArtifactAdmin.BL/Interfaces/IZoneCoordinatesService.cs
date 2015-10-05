namespace ArtifactAdmin.BL.Interfaces
{
    using System.Collections.Generic;
    using Utils.GeneratingMiddlePoints;

    public interface IZoneCoordinatesService
    {
        Dictionary<string, List<SimplePoint>> GetZoneValuesCoordinatByMapInfoId(int? id);

        Dictionary<int, List<SimplePoint>> GetZoneIdCoordinatByMapInfoId(int? id);

        void CreateZoneCoordinates(int id);

        void Delete(int id);
    }
}
