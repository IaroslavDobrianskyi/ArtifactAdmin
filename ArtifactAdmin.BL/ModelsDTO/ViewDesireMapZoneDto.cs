// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ViewDesireMapZoneDto.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the ViewDesireMapZoneDto type.
// </summary>
// -------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ArtifactAdmin.DAL.Models;

namespace ArtifactAdmin.BL.ModelsDTO
{
    public class ViewDesireMapZoneDto
    {
        public int ItemId { get; set; }

        public string ItemName { get; set; }

        public List<DesireMapZone> ListDesireMapZone { get; set; } 

        public List<double> Modifiers { get; set; }

        [Display(Name = "Введіть швидкість зростання бажання")]
        [RegularExpression(@"0\.\d+", ErrorMessage = "Введіть число від 0.0 до 1 !")]
        public string OneModifier { get; set; }
    }
}