// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDesireService.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the IDesireService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ArtifactAdmin.BL.Interfaces
{
    using System.Collections.Generic;
    using ModelsDTO;

    public interface IDesireService
    {
        IEnumerable<DesireDto> GetAll();

        DesireDto GetById(int? id);

        DesireDto GetByIdMapZone(int id);

        DesireDto Create(DesireDto desireDto, string fileName);

        DesireDto Update(DesireDto desireDto, string fileName);

        void UpdateDesireMapZone(int id, int[] desireMapZoneId, string[] modifiers);

        //тут має бути список значень всіх бажаннь для керіора. Можливо окремий обєкт 
        List<DesireDto> RetrieveListOfCurrentCarrierDesires(int carrierId);

        void Delete(int? id);
    }
}
