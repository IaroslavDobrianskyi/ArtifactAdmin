// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ViewDesireActionResultDto.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the ViewDesireActionResultDto type.
// </summary>
// -------------------------------------------------------------------------------------------------------------------

namespace ArtifactAdmin.BL.ModelsDTO
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ViewDesireActionResultDto
    {
        public int ActionResultId { get; set; }

        [Display(Name = "Назва дії")]
        public string ActionName { get; set; }

        [Display(Name = "Всі бажання")]
        public List<DesireDto> DesiresDto { get; set; }

        [Display(Name = "Вибрані бажання")]
        public List<DesireActionTemplateResultDto> DesireResultsDto { get; set; }

        public List<double> Modifiers { get; set; }

        [Display(Name = "Введіть швидкість зміни бажання")]
        [RegularExpression(@"0\.\d+", ErrorMessage = "Введіть число від 0.0 до 1 !")]
        public string OneModifier { get; set; }
    }
}