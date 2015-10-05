// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IConstellationService.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the IConstellationService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using ArtifactAdmin.BL.ModelsDTO;

namespace ArtifactAdmin.BL.Interfaces
{
    public interface IConstellationService
    {
        IEnumerable<ConstellationDto> GetAll();

        ConstellationDto GetById(int? id);
        
        ConstellationDto Create(ConstellationDto constellationDto, string fileName);

        ConstellationDto Update(ConstellationDto constellationDto, string fileName);

        void Delete(int? id);
    }
}
