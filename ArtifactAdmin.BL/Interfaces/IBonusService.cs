// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IBonusService.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the IBonusService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ArtifactAdmin.BL.Interfaces
{
    using System;
    using System.Collections.Generic;
    using ModelsDTO;

    public interface IBonusService
    {
        IEnumerable<BonusDto> GetAll();

        BonusDto GetById(int? id);
        
        BonusDto Create(BonusDto bonusDto);

        BonusDto Update(BonusDto bonusDto);

        void Delete(int id);
    }
}