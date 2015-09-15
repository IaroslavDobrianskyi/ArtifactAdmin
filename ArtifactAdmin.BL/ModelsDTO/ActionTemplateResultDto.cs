// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActionTemplateResultDto.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the ActionTemplateResultDto type.
// </summary>
// -------------------------------------------------------------------------------------------------------------------
namespace ArtifactAdmin.BL.ModelsDTO
{
    using System;
    using System.Collections.Generic; 
    using System.ComponentModel.DataAnnotations;

    public class ActionTemplateResultDto
    {
        public int Id { get; set; }

        [Display(Name = "Модифікатор схильності")]
        public double PredispositionResultModifier { get; set; }

        [Display(Name = "Модифікатор досвіду")]
        public double ExperienceModifier { get; set; }

        [Display(Name = "Модифікатор можливості")]
        public double ArtifactPosibility { get; set; }

        [Display(Name = "Модифікатор золота")]
        public double GoldModifier { get; set; }

        public int? QuestTemplate { get; set; }

        [Display(Name = "Введіть модифікатор схильності")]
        [RegularExpression(@"0\.\d+", ErrorMessage = "Введіть число від 0.0 до 1 !")]
        public string Predisposition { get; set; }

        [Display(Name = "Введіть модифікатор досвіду")]
        [RegularExpression(@"0\.\d+", ErrorMessage = "Введіть число від 0.0 до 1 !")]
        public string Experience { get; set; }

        [Display(Name = "Введіть модифікатор можливості")]
        [RegularExpression(@"0\.\d+", ErrorMessage = "Введіть число від 0.0 до 1 !")]
        public string Posibility { get; set; }

        [Display(Name = "Введіть модифікатор золота")]
        [RegularExpression(@"0\.\d+", ErrorMessage = "Введіть число від 0.0 до 1 !")]
        public string Gold { get; set; }

        [Display(Name = "Шаблони квестів")]
        public List<QuestTemplateDto> ListQuestTemplates { get; set; } 

        public virtual ICollection<ActionTemplateDto> ActionTemplates { get; set; }

        [Display(Name = "Назва шаблону квеста")]
        public virtual QuestTemplateDto QuestTemplate1 { get; set; }
    }
}