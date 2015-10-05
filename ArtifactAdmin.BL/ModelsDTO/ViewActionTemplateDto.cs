// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ViewActionTemplateDto.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the ViewActionTemplateDto type.
// </summary>
// -------------------------------------------------------------------------------------------------------------------
namespace ArtifactAdmin.BL.ModelsDTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations; 

    public class ViewActionTemplateDto
    {
        public ActionTemplateDto ActionTemplateDto { get; set; }

        public List<ActionTemplateResultDto> ActionTemplateResults { get; set; }

        [Display(Name = "Введіть ймовірність")]
        [RegularExpression(@"0\.\d+", ErrorMessage = "Введіть число від 0.0 до 1 !")]
        public string OneProbability { get; set; }

        public string NameResult { get; set; }

        [Display(Name = "Характеристики")]
        public List<CharacteristicDto> Characteristics { get; set; }

        [Display(Name = "Вибрані характеристики")]
        public List<ActionTemplateCharacteristicDto> SelectedCharacteristics { get; set; }

        [Display(Name = "Схильності")]
        public List<PredispositionDto> Predispositions { get; set; }

        [Display(Name = "Вибрані схильності")]
        public List<ActionTemplatePredispositionDto> SelectedPredispositions { get; set; }

        public List<int> Lows { get; set; }

        public List<int> Highs { get; set; }

        [Display(Name = "Значення від")]
        public int OneLow { get; set; }

        [Display(Name = "Значення до")]
        public int OneHigh { get; set; }

        [Display(Name = "Властивості")]
        public List<PropertyDto> Properties { get; set; }

        [Display(Name = "Вибрані властивості")]
        public List<ActionTemplatePropertyDto> SelectedProperties { get; set; }

        public List<bool> Appearances { get; set; }

        public bool OneAppearance { get; set; }
    }
}