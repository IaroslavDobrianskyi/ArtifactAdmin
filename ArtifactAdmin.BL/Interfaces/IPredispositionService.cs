// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPredispositionService.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the IPredispositionService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using ArtifactAdmin.BL.ModelsDTO;

namespace ArtifactAdmin.BL.Interfaces
{
    public interface IPredispositionService
    {
        IEnumerable<PredispositionDto> GetAll();

        PredispositionDto GetById(int? id);

        PredispositionDto GetByPosition(int position);

        PredispositionDto GetMaxByPosition(int position);

        PredispositionDto GetMinByPosition(int position);

        PredispositionDto Create(PredispositionDto predispositinDto);

        PredispositionDto Update(PredispositionDto predispositionDto);

        void Delete(int id);
    }
}
