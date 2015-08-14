// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PropertyDto.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the PropertyDto type.
// </summary>
// -------------------------------------------------------------------------------------------------------------------
namespace ArtifactAdmin.BL.ModelsDTO
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Validate;

    public class PropertyDto
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

        [Required(ErrorMessageResourceName = "RequiredDeviation",
   ErrorMessageResourceType = typeof(ValidationConstellation.ValidationStrings))]
        [Display(Name = "Відхилення")]
        [StringLength(50, ErrorMessageResourceName = "StringLength",
  ErrorMessageResourceType = typeof(ValidationConstellation.ValidationStrings))]
        public string Deviation { get; set; }
    }
}