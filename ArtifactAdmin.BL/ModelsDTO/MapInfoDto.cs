using System.ComponentModel.DataAnnotations;
using ValidationConstellation;

namespace ArtifactAdmin.BL.ModelsDTO
{
    public class MapInfoDto
    {
        public int Id { get; set; }
        [Required(ErrorMessageResourceName = "RequiredName",
   ErrorMessageResourceType = typeof(ValidationStrings))]
        [Display(Name = "Назва карти")]
        [StringLength(500, ErrorMessageResourceName = "StringLength",
  ErrorMessageResourceType = typeof(ValidationStrings))]
        public string MapName { get; set; }
        [Required(ErrorMessageResourceName = "RequiredName",
   ErrorMessageResourceType = typeof(ValidationStrings))]
        [Display(Name = "Шлях до файла карти")]
        [StringLength(500, ErrorMessageResourceName = "StringLength",
  ErrorMessageResourceType = typeof(ValidationStrings))]
        public string ImagePath { get; set; }
        [Display(Name = "Ширина")]
        public int Width { get; set; }
        [Display(Name = "Висона")]
        public int Height { get; set; }
    }
}