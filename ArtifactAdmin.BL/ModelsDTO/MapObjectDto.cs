// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapObjectDTO.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the  MapObjectDTO type.
// </summary>
// -------------------------------------------------------------------------------------------------------------------
namespace ArtifactAdmin.BL.ModelsDTO
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class MapObjectDto
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceName = "RequiredName",
   ErrorMessageResourceType = typeof(ValidationConstellation.ValidationStrings))]
        [Display(Name = "Назва")]
        [StringLength(50, ErrorMessageResourceName = "StringLength",
  ErrorMessageResourceType = typeof(ValidationConstellation.ValidationStrings))]
        public string Name { get; set; }
    }
}