// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICharacteristicService.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the ICharacteristicService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using ArtifactAdmin.BL.ModelsDTO;

namespace ArtifactAdmin.BL.Interfaces
{
    public interface ICharacteristicService
    {
        IEnumerable<CharacteristicDto> GetAll();

        CharacteristicDto GetById(int? id);

        CharacteristicDto GetByPosition(int position);

        CharacteristicDto GetMaxByPosition(int position);

        CharacteristicDto GetMinByPosition(int position);

        CharacteristicDto Create(CharacteristicDto characteristicDto);

        CharacteristicDto Update(CharacteristicDto characteristicDto);

        void Delete(int id);
    }
}
