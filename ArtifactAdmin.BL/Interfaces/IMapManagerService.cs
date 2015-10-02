using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ArtifactAdmin.BL.MapHelpers;

namespace ArtifactAdmin.BL.Interfaces
{
    public interface IMapManagerService
    {
        MapManager GetFirstMapManager();
        MapManager GetMapManager(int mapInfoId);
    }
}