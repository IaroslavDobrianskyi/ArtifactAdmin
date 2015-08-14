// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RaceDto.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the RaceDto type.
// </summary>
// -------------------------------------------------------------------------------------------------------------------
namespace ArtifactAdmin.BL.ModelsDTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class RaceDto
    {
        [Required(ErrorMessageResourceName = "RequiredDescription",
           ErrorMessageResourceType = typeof(ValidationConstellation.ValidationStrings))]
        [Display(Name = "Опис")]
        [StringLength(500, ErrorMessageResourceName = "StringLength",
            ErrorMessageResourceType = typeof(ValidationConstellation.ValidationStrings))]
        public string Description { get; set; }

        public int Id { get; set; }

        [Required(ErrorMessageResourceName = "RequiredList",
           ErrorMessageResourceType = typeof(ValidationConstellation.ValidationStrings))]
        [Display(Name = "Характеристики")]
        public string Characreristics { get; set; }

        public List<ViewCharacteristic> AllCharacteristics { get; set; }

        public List<ViewCharacteristic> SelectedCharacteristics { get; set; }

        public List<ViewCharacteristic> SelectedValues { get; set; }

        [Display(Name = "Введіть значення характеристики!")]
        public int ValueCharacteristic { get; set; }


        [Required]
        public string CharacteristicsLevelModifier { get; set; }

        [Required(ErrorMessageResourceName = "RequiredList",
           ErrorMessageResourceType = typeof(ValidationConstellation.ValidationStrings))]
        [Display(Name = "Схильності")]
        public string Predisposition { get; set; }

        public List<ViewCharacteristic> AllPredispositions { get; set; }

        public List<ViewCharacteristic> SelectedPredispositions { get; set; }

        public List<ViewCharacteristic> SelectedValuesPredisposition { get; set; }

        [Display(Name = "Введіть значення схильності!")]
        public int ValuePredisposition { get; set; }

        [Required(ErrorMessageResourceName = "RequiredList",
           ErrorMessageResourceType = typeof(ValidationConstellation.ValidationStrings))]
        [Display(Name = "Властивості")]
        public string Properties { get; set; }
        public List<ViewCharacteristic> AllProperties { get; set; }

        public List<ViewCharacteristic> SelectedProperties { get; set; }

        public List<ViewCharacteristic> SelectedValuesProperties { get; set; }

        [Display(Name = "Введіть значення властивості!")]
        public int ValueProperty { get; set; }

        [Display(Name = "Іконка")]
        public string Icon { get; set; }

        public string NewIcon { get; set; }
    }
}