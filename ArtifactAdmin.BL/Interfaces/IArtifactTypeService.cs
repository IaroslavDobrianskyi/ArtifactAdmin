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
    using System;
    using System.Collections.Generic;
    using System.Web;
    using ModelsDTO;

    public interface IArtifactTypeService
    {
        IEnumerable<ArtifactTypeDto> GetAll();
        
        ArtifactTypeDto GetById(int? id);

        ArtifactTypeDto Create(ArtifactTypeDto artifactTypeDto, HttpPostedFileBase icon);

        ArtifactTypeDto Update(ArtifactTypeDto artifactTypeDto);

        void Delete(int? id);
    }
}
