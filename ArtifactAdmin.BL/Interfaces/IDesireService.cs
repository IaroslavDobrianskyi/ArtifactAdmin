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

    using ArtifactAdmin.BL.ModelsDTO.FlowItems;

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
        List<CarrierDesireDto> RetrieveListOfCurrentCarrierDesires(int carrierId);

        void Delete(int? id);
    }
}
