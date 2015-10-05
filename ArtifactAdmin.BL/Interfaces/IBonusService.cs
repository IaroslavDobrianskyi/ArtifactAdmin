// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IBonusService.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the IBonusService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using ArtifactAdmin.BL.ModelsDTO;

namespace ArtifactAdmin.BL.Interfaces
{
    public interface IBonusService
    {
        IEnumerable<BonusDto> GetAll();

        BonusDto GetById(int? id);
        
        BonusDto Create(BonusDto bonusDto);

        BonusDto Update(BonusDto bonusDto);

        void Delete(int id);
    }
}