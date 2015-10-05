// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActionDescriptionDto.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the ActionDescriptionDto type.
// </summary>
// -------------------------------------------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;
using ValidationConstellation;

namespace ArtifactAdmin.BL.ModelsDTO
{
    public class ActionDescriptionDto
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceName = "RequiredActionTemplate",
    ErrorMessageResourceType = typeof(ValidationStrings))]
       public int ActionTemplate { get; set; }

        public int? MapZone { get; set; }

        [Display(Name = "Опис дії")]
        [StringLength(500, ErrorMessageResourceName = "StringLength",
  ErrorMessageResourceType = typeof(ValidationStrings))]
        public string ActionText { get; set; }

        public int? Race { get; set; }

        public int? Class { get; set; }

         [Display(Name = "Клас")]
        public virtual ClassDto Class1 { get; set; }
        
        [Display(Name = "Назва зони")]
        public virtual MapZoneDto MapZone1 { get; set; }

         [Display(Name = "Раса")]
        public virtual RaceDto Race1 { get; set; }

        [Display(Name = "Назва дії")]
        public virtual ActionTemplateDto ActionTemplate1 { get; set; }
    }
}