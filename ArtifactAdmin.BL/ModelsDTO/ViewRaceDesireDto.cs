// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ViewRaceDesireDto.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the ViewRaceDesireDto type.
// </summary>
// -------------------------------------------------------------------------------------------------------------------
namespace ArtifactAdmin.BL.ModelsDTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ViewRaceDesireDto
    {
        public int Id { get; set; }

        [Display(Name = "Опис")]
        public string Description { get; set; }

        [Display(Name = "Іконка")]
        public string Icon { get; set; }

        [Display(Name = "Бажання раси")]
        public virtual ICollection<RaceDesireDto> RaceDesires { get; set; }

        [Display(Name = "Всі бажання")]
        public List<DesireDto> AllDesires { get; set; }

        [Display(Name = "Бажання")]
        public List<DesireDto> SelectedDesires { get; set; }

        [Display(Name = "Ймовірності")]
        public List<double> Probabilities { get; set; }

        [Display(Name = "Базові значення")]
        public List<int> DefaultValues { get; set; }

        [Display(Name = "Відхилення")]
        public List<double> Deviations { get; set; }

        [Display(Name = "Введіть ймовірність")]
        [RegularExpression(@"0.\d+", ErrorMessage = "Введіть число від 0 до 1 !")]
        public string OneProbability { get; set; }

         [Display(Name = "Введіть базове значення")]
        public int DefaultValue { get; set; }

        [Display(Name = "Введіть  відхилення")]
        [RegularExpression(@"0.\d+", ErrorMessage = "Введіть число від 0.0 до 1 !")]
        public string Deviation { get; set; }
    }
}