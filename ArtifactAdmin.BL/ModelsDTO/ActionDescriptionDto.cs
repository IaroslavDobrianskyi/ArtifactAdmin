// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActionDescriptionDto.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the ActionDescriptionDto type.
// </summary>
// -------------------------------------------------------------------------------------------------------------------
namespace ArtifactAdmin.BL.ModelsDTO
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ActionDescriptionDto
    {
        public int id { get; set; }

        [Required(ErrorMessageResourceName = "RequiredActionTemplate",
    ErrorMessageResourceType = typeof(ValidationConstellation.ValidationStrings))]
       public int ActionTemplate { get; set; }

        public Nullable<int> MapZone { get; set; }

        [Display(Name = "Опис")]
        [StringLength(500, ErrorMessageResourceName = "StringLength",
  ErrorMessageResourceType = typeof(ValidationConstellation.ValidationStrings))]
        public string ActionText { get; set; }
        
        [Display(Name = "Назва зони")]
        public virtual MapZoneDto MapZone1 { get; set; }

        [Display(Name = "Назва дії")]
        public virtual ActionTemplateDto ActionTemplate1 { get; set; }
    }
}