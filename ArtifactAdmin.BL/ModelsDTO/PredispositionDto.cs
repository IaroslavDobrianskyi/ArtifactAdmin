// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PredispositionDto.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the PredispositionDto type.
// </summary>
// -------------------------------------------------------------------------------------------------------------------
namespace ArtifactAdmin.BL.ModelsDTO
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Validate;

    public class PredispositionDto
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceName = "RequiredName",
    ErrorMessageResourceType = typeof(ValidationConstellation.ValidationStrings))]
        [Display(Name = "Назва")]
        [StringLength(50, ErrorMessageResourceName = "StringLength",
  ErrorMessageResourceType = typeof(ValidationConstellation.ValidationStrings))]
        public string Name { get; set; }

        [Required(ErrorMessageResourceName = "RequiredDescription",
        ErrorMessageResourceType = typeof(ValidationConstellation.ValidationStrings))]
        [Display(Name = "Опис")]
        [StringLength(500, ErrorMessageResourceName = "StringLength",
  ErrorMessageResourceType = typeof(ValidationConstellation.ValidationStrings))]
        public string Description { get; set; }

        [Required(ErrorMessageResourceName = "RequiredMask",
       ErrorMessageResourceType = typeof(ValidationConstellation.ValidationStrings))]
        [Display(Name = "Маска")]
        public long Mask { get; set; }

        [Required(ErrorMessageResourceName = "RequiredLength",
      ErrorMessageResourceType = typeof(ValidationConstellation.ValidationStrings))]
        [Display(Name = "Довжина рядка")]
        [Range(1, 50)]
        [AcceptableLength]
        public int Length { get; set; }

        [Required(ErrorMessageResourceName = "RequiredPosition",
      ErrorMessageResourceType = typeof(ValidationConstellation.ValidationStrings))]
        [Display(Name = "Початкова позиція")]
        [Range(0, 49)]
        [UniquePosition]
        [AcceptablePosition]
        public int Position { get; set; }
    }
}