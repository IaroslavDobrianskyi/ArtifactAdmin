// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IConstellationService.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the IConstellationService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ArtifactAdmin.BL.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Web;
    using ModelsDTO;

    public interface IRaceService
    {
        IEnumerable<RaceDto> GetAll();

        RaceDto GetById(int? id);

        RaceDto Create(RaceDto raceDto, string fileName);

        RaceDto Update(RaceDto raceDto, string fileName);

        void Delete(int? id);

    }
}
