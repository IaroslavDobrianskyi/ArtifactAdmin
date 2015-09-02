// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRaceDesireService.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the IRaceDesireService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ArtifactAdmin.BL.Interfaces
{
    using System;
    using System.Collections.Generic;
    using ModelsDTO;

    public interface IRaceDesireService
    {
        IEnumerable<ViewRaceDesireDto> GetAll();

        ViewRaceDesireDto GetViewById(int? id);

        void Update(int id, int[] selectedDesires, string[] probabilities, int[] defaultValues, string[] deviations);

        void Delete(int? id);
    }
}
