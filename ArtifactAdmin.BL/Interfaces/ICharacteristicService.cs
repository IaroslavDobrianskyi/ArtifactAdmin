// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICharacteristicService.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the ICharacteristicService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ArtifactAdmin.BL.Interfaces
{
    using System.Collections.Generic;
    using ModelsDTO;

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
