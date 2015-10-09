// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActionTemplateCharacteristicDto.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the ActionTemplateCharacteristicDto type.
// </summary>
// -------------------------------------------------------------------------------------------------------------------using System;
namespace ArtifactAdmin.BL.ModelsDTO
{
    public class ActionTemplateCharacteristicDto
    {
        public int Id { get; set; }

        public int ActionTemplate { get; set; }

        public int Characteristics { get; set; }

        public virtual ActionTemplateDto ActionTemplate1 { get; set; }

        public virtual CharacteristicDto Characteristic { get; set; }
    }
}