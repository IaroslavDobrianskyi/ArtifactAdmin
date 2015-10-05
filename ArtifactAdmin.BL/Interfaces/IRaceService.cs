// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRaceService.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the IRaceService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ArtifactAdmin.BL.Interfaces
{
    using System.Collections.Generic;
    using ModelsDTO;

    public interface IRaceService
    {
        IEnumerable<RaceDto> GetAll();

        RaceDto GetById(int? id);

        RaceDto GetViewById(int? id);

        RaceDto Create(RaceDto raceDto, string fileName);

        RaceDto Update(RaceDto raceDto, string fileName);

        void Delete(int? id);
    }
}
