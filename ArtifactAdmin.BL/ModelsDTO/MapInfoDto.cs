using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArtifactAdmin.BL.ModelsDTO
{
    public class MapInfoDto
    {
        public int Id { get; set; }
        [Required(ErrorMessageResourceName = "RequiredName",
   ErrorMessageResourceType = typeof(ValidationConstellation.ValidationStrings))]
        [Display(Name = "Назва карти")]
        [StringLength(500, ErrorMessageResourceName = "StringLength",
  ErrorMessageResourceType = typeof(ValidationConstellation.ValidationStrings))]
        public string MapName { get; set; }
        [Required(ErrorMessageResourceName = "RequiredName",
   ErrorMessageResourceType = typeof(ValidationConstellation.ValidationStrings))]
        [Display(Name = "Шлях до файла карти")]
        [StringLength(500, ErrorMessageResourceName = "StringLength",
  ErrorMessageResourceType = typeof(ValidationConstellation.ValidationStrings))]
        public string ImagePath { get; set; }
        [Display(Name = "Ширина")]
        public int Width { get; set; }
        [Display(Name = "Висона")]
        public int Height { get; set; }
    }
}