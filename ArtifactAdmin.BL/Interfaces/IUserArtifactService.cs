using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtifactAdmin.BL.Interfaces
{
    public interface IUserArtifactService
    {
        int GetUserArtifactPredictionRadius(int carrierId);
    }
}