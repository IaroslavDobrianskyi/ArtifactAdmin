// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ViewCharacteristic.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the ViewCharacteristic type.
// </summary>
// -------------------------------------------------------------------------------------------------------------------
namespace ArtifactAdmin.BL.ModelsDTO
{
    using System;

    public class ViewCharacteristic
    {
        public string Name { get; set; }

        public string PositionLength { get; set; }

        public int Value { get; set; }
    }
}