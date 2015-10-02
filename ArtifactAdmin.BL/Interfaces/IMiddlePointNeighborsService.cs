using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ArtifactAdmin.BL.ModelsDTO;
using ArtifactAdmin.BL.Utils.GeneratingMiddlePoints;

namespace ArtifactAdmin.BL.Interfaces
{
    public interface IMiddlePointNeighborsService
    {
        Dictionary<SimplePoint, List<SimplePoint>> GetMiddlePointNeighborsByDimentionRadius(int dimentionRadiusId);
    }
}