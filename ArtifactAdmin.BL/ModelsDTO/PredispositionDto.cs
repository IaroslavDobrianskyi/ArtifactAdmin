// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PredispositionDto.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the PredispositionDto type.
// </summary>
// -------------------------------------------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;
using ArtifactAdmin.BL.Validate;
using ValidationConstellation;

namespace ArtifactAdmin.BL.ModelsDTO
{
    public class PredispositionDto
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
        [StringLength(500, ErrorMessageResourceName = "StringLength",
  ErrorMessageResourceType = typeof(ValidationStrings))]
        public string Description { get; set; }

        [Required(ErrorMessageResourceName = "RequiredMask",
       ErrorMessageResourceType = typeof(ValidationStrings))]
        [Display(Name = "Маска")]
        public long Mask { get; set; }

        [Required(ErrorMessageResourceName = "RequiredLength",
      ErrorMessageResourceType = typeof(ValidationStrings))]
        [Display(Name = "Довжина рядка")]
        [Range(1, 50)]
        [AcceptableLength]
        public int Length { get; set; }

        [Required(ErrorMessageResourceName = "RequiredPosition",
      ErrorMessageResourceType = typeof(ValidationStrings))]
        [Display(Name = "Початкова позиція")]
        [Range(0, 49)]
        [UniquePosition]
        [AcceptablePosition]
        public int Position { get; set; }
    }
}