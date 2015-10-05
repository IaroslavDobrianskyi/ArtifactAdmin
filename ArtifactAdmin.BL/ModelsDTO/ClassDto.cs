// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClassDto.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the ClassDto type.
// </summary>
// -------------------------------------------------------------------------------------------------------------------

namespace ArtifactAdmin.BL.ModelsDTO
{
    using System.ComponentModel.DataAnnotations;
    using ValidationConstellation;

    public class ClassDto
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceName = "RequiredDescription",
            ErrorMessageResourceType = typeof(ValidationStrings))]
        [Display(Name = "Опис")]
        [StringLength(500, ErrorMessageResourceName = "StringLength",
            ErrorMessageResourceType = typeof(ValidationStrings))]
        public string Description { get; set; }

        [Required(ErrorMessageResourceName = "RequiredIcon",
            ErrorMessageResourceType = typeof(ValidationStrings))]
        [Display(Name = "Іконка")]
        public string Icon { get; set; }

        [Required]
        public int FibonacciSeed { get; set; }

        public string NewIcon { get; set; }
    }
}