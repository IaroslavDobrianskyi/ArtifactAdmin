// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActionTemplateDto.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the ActionTemplateDto type.
// </summary>
// -------------------------------------------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;
using ValidationConstellation;

namespace ArtifactAdmin.BL.ModelsDTO
{
    public class ActionTemplateDto
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceName = "RequiredName",
    ErrorMessageResourceType = typeof(ValidationStrings))]
        [Display(Name = "Назва")]
        [StringLength(200, ErrorMessageResourceName = "StringLength",
  ErrorMessageResourceType = typeof(ValidationStrings))]
        public string Name { get; set; }

        [Display(Name = "Ймовірність блокування дії")]
        public double BlockProbability { get; set; }

        [Required(ErrorMessageResourceName = "RequiredActionResult",
    ErrorMessageResourceType = typeof(ValidationStrings))]
        public int ActionTemplateResult { get; set; }

        [Display(Name = "Результат дії")]
        public virtual ActionTemplateResultDto ActionTemplateResult1 { get; set; }
    }
}