// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapObjectDTO.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the  MapObjectDTO type.
// </summary>
// -------------------------------------------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;
using ValidationConstellation;

namespace ArtifactAdmin.BL.ModelsDTO
{
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