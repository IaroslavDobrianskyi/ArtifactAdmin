﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BonusDto.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the BonusDto type.
// </summary>
// -------------------------------------------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;
using ValidationConstellation;

namespace ArtifactAdmin.BL.ModelsDTO
{
    public class BonusDto
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceName = "RequiredName",
    ErrorMessageResourceType = typeof(ValidationStrings))]
        [Display(Name = "Назва")]
        [StringLength(50, ErrorMessageResourceName = "StringLength",
  ErrorMessageResourceType = typeof(ValidationStrings))]
        public string Name { get; set; }
        [Required(ErrorMessageResourceName = "RequiredDescription",
        ErrorMessageResourceType = typeof(ValidationStrings))]
        [Display(Name = "Опис")]
        [StringLength(50, ErrorMessageResourceName = "StringLength",
  ErrorMessageResourceType = typeof(ValidationStrings))]
        public string Description { get; set; }
    }
}