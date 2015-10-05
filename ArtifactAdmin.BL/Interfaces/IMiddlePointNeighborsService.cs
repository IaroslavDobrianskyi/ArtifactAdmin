namespace ArtifactAdmin.BL.Interfaces
{
    using System.Collections.Generic;
    using Utils.GeneratingMiddlePoints;

    public interface IMiddlePointNeighborsService
    {
        Dictionary<SimplePoint, List<SimplePoint>> GetMiddlePointNeighborsByDimentionRadius(int dimentionRadiusId);
    }
}