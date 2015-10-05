// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActionTemplatePredispositionDto.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the ActionTemplatePredispositionDto type.
// </summary>
// -------------------------------------------------------------------------------------------------------------------using System;using System;
namespace ArtifactAdmin.BL.ModelsDTO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class ActionTemplatePredispositionDto
    {
        public int Id { get; set; }

        public int ActionTemplate { get; set; }

        public int Predisposition { get; set; }

        public int RequirementLow { get; set; }

        public int RequirementHigh { get; set; }

        public virtual ActionTemplateDto ActionTemplate1 { get; set; }

        public virtual PredispositionDto Predisposition1 { get; set; }
    }
}