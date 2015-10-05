// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITalentService.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the ITalentService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using ArtifactAdmin.BL.ModelsDTO;

namespace ArtifactAdmin.BL.Interfaces
{
    public interface ITalentService
    {
        IEnumerable<TalentDto> GetAll();

        TalentDto GetById(int? id);

        TalentDto Create(TalentDto talentDto, string fileName);

        TalentDto Update(TalentDto talentDto, string fileName);

        void Delete(int? id);
    }
}
