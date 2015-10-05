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
    using System.ComponentModel.DataAnnotations;
    using ValidationConstellation;

    public class MapObjectDto
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceName = "RequiredName",
   ErrorMessageResourceType = typeof(ValidationStrings))]
        [Display(Name = "Назва")]
        [StringLength(50, ErrorMessageResourceName = "StringLength",
  ErrorMessageResourceType = typeof(ValidationStrings))]
        public string Name { get; set; }
    }
}