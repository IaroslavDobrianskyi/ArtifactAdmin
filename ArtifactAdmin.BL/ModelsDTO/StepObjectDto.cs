// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StepObjectDto.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the StepObjectDto type.
// </summary>
// -------------------------------------------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;
using ValidationConstellation;

namespace ArtifactAdmin.BL.ModelsDTO
{
    public class StepObjectDto
    {
        public int Id { get; set; }
        
        public int StepObjectType { get; set; }

        [Required(ErrorMessageResourceName = "RequiredName",
            ErrorMessageResourceType = typeof(ValidationStrings))]
        [Display(Name = "Назва")]
        [StringLength(50, ErrorMessageResourceName = "StringLength",
            ErrorMessageResourceType = typeof(ValidationStrings))]
        public string Name { get; set; }

        [Required(ErrorMessageResourceName = "RequiredDescription",
            ErrorMessageResourceType = typeof(ValidationStrings))]
        [Display(Name = "Опис")]
        [StringLength(100, ErrorMessageResourceName = "StringLength",
            ErrorMessageResourceType = typeof(ValidationStrings))]
        public string Description { get; set; }

        [Required(ErrorMessageResourceName = "RequiredIcon",
            ErrorMessageResourceType = typeof(ValidationStrings))]
        [Display(Name = "Іконка")]
        public string Icon { get; set; }

        [Display(Name = "Тип")]
        public virtual StepObjectTypeDto StepObjectType1 { get; set; }
        
        public string NewIcon { get; set; }
    }
}