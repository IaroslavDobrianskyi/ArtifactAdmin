// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDesireService.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the IDesireService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using ArtifactAdmin.BL.ModelsDTO;

namespace ArtifactAdmin.BL.Interfaces
{
    public interface IDesireService
    {
        IEnumerable<DesireDto> GetAll();

        DesireDto GetById(int? id);

        DesireDto GetByIdMapZone(int id);

        DesireDto Create(DesireDto desireDto, string fileName);

        DesireDto Update(DesireDto desireDto, string fileName);

        void UpdateDesireMapZone(int id, int[] desireMapZoneId, string[] modifiers);

        void Delete(int? id);
    }
}
