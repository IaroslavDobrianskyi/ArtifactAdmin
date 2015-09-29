using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ArtifactAdmin.BL.ModelsDTO;

namespace ArtifactAdmin.BL.Interfaces
{
    public interface IMiddlePointNeighborsService
    {
        List<MiddlePointNeighborDto> GetMiddlePointNeighborsByDimentionRadius(int dimentionRadiusId);
    }
}