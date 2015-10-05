// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ViewValueCharacteristic.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the ViewValueCharacteristic type.
// </summary>
// -------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace ArtifactAdmin.BL.ModelsDTO
{
    public class ViewValueCharacteristic
    {
        public List<ViewCharacteristic> Characteristics { get; set; }

        public List<ViewCharacteristic> SelectedCharacteristics { get; set; }

        public List<ViewCharacteristic> SelectedValues { get; set; }
    }
}