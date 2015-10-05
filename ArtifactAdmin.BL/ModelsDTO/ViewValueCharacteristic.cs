// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ViewValueCharacteristic.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the ViewValueCharacteristic type.
// </summary>
// -------------------------------------------------------------------------------------------------------------------

namespace ArtifactAdmin.BL.ModelsDTO
{
    using System.Collections.Generic;

    public class ViewValueCharacteristic
    {
        public List<ViewCharacteristic> Characteristics { get; set; }

        public List<ViewCharacteristic> SelectedCharacteristics { get; set; }

        public List<ViewCharacteristic> SelectedValues { get; set; }
    }
}