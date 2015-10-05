// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActionTemplatePropertyDto.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the ActionTemplatePropertyDto type.
// </summary>
// -------------------------------------------------------------------------------------------------------------------using System;using System;
namespace ArtifactAdmin.BL.ModelsDTO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    public class ActionTemplatePropertyDto
    {
        public int Id { get; set; }
        public int ActionTemplate { get; set; }
        public int Properties { get; set; }
        public bool Appearance { get; set; }

        public virtual ActionTemplateDto ActionTemplate1 { get; set; }
        public virtual PropertyDto Property { get; set; }
    }
}