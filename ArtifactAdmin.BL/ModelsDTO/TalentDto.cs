// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TalentDto.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the TalentDto type.
// </summary>
// -------------------------------------------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;
using ValidationConstellation;

namespace ArtifactAdmin.BL.ModelsDTO
{
    public class TalentDto
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceName = "RequiredDescription",
        ErrorMessageResourceType = typeof(ValidationStrings))]
        [Display(Name = "Опис")]
        [StringLength(500, ErrorMessageResourceName = "StringLength",
  ErrorMessageResourceType = typeof(ValidationStrings))]
        public string Description { get; set; }

        [Required(ErrorMessageResourceName = "RequiredName",
    ErrorMessageResourceType = typeof(ValidationStrings))]
        [Display(Name = "Назва")]
        [StringLength(50, ErrorMessageResourceName = "StringLength",
  ErrorMessageResourceType = typeof(ValidationStrings))]
        public string Name { get; set; }

        [Required(ErrorMessageResourceName = "RequiredLevel",
            ErrorMessageResourceType = typeof(ValidationStrings))]
        [Display(Name = "Максимальний рівень")]
        [Range(0, int.MaxValue, ErrorMessage = "Введіть додатнє число!")]
        public int MaxLevel { get; set; }

        [Display(Name = "Модифікатор")]
        [RegularExpression(@"0\.\d+", ErrorMessage = "Введіть число від 0.0 до 1 !")]
        public double Modifier { get; set; }

        [Display(Name = "Базове значення")]
        [RegularExpression(@"0\.\d+", ErrorMessage = "Введіть число від 0.0 до 1 !")]
        public double BaseValue { get; set; }

        [Display(Name = "Базовий модифікатор")]
        [RegularExpression(@"0\.\d+", ErrorMessage = "Введіть число від 0.0 до 1 !")]
        public double BaseModifier { get; set; }

        [Required(ErrorMessageResourceName = "RequiredIcon",
         ErrorMessageResourceType = typeof(ValidationStrings))]
        [Display(Name = "Іконка")]
        public string Icon { get; set; }

        public string NewIcon { get; set; }
    }
}