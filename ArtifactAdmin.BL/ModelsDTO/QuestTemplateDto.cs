// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QuestTemplateDto.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the QuestTemplateDto type.
// </summary>
// -------------------------------------------------------------------------------------------------------------------
namespace ArtifactAdmin.BL.ModelsDTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    using ValidationConstellation;

    public class QuestTemplateDto
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceName = "RequiredName",
  ErrorMessageResourceType = typeof(ValidationStrings))]
        [Display(Name = "Назва")]
        [StringLength(500, ErrorMessageResourceName = "StringLength",
    ErrorMessageResourceType = typeof(ValidationStrings))]
        public string Name { get; set; }

        [Required(ErrorMessageResourceName = "RequiredDescription",
      ErrorMessageResourceType = typeof(ValidationStrings))]
        [Display(Name = "Опис")]
        [StringLength(10, ErrorMessageResourceName = "StringLength",
    ErrorMessageResourceType = typeof(ValidationStrings))]
        public string Description { get; set; }
    }
}