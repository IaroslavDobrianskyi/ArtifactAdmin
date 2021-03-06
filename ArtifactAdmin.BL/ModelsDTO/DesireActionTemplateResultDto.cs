﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DesireActionTemplateResultDto.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the DesireActionTemplateResultDto type.
// </summary>
// -------------------------------------------------------------------------------------------------------------------
namespace ArtifactAdmin.BL.ModelsDTO
{
    public class DesireActionTemplateResultDto
    {
        public int Id { get; set; }

        public int Desire { get; set; }

        public int ActionTemplateResult { get; set; }

        public double Modifier { get; set; }

        public virtual ActionTemplateResultDto ActionTemplateResult1 { get; set; }
       
        public virtual DesireDto Desire1 { get; set; }
    }
}