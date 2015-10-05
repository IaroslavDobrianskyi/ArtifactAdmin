using System.Collections.Generic;
using ArtifactAdmin.BL.Utils.GeneratingMiddlePoints;

namespace ArtifactAdmin.BL.Interfaces
{
    public interface IMiddlePointNeighborsService
    {
        Dictionary<SimplePoint, List<SimplePoint>> GetMiddlePointNeighborsByDimentionRadius(int dimentionRadiusId);
    }
}