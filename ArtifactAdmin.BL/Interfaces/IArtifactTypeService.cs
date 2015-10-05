// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IArtifactTypeService.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the IArtifactTypeService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ArtifactAdmin.BL.Interfaces
{
    using System.Collections.Generic;
    using ModelsDTO;

    public interface IArtifactTypeService
    {
        IEnumerable<ArtifactTypeDto> GetAll();
        
        ArtifactTypeDto GetById(int? id);

        ArtifactTypeDto Create(ArtifactTypeDto artifactTypeDto, string fileName);

        ArtifactTypeDto Update(ArtifactTypeDto artifactTypeDto, string fileName);

        void Delete(int? id);
    }
}
