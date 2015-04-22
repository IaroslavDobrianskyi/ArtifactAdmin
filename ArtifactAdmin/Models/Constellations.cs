using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace ArtifactAdmin.Models
{
    [MetadataType(typeof(ConstellationMetaData))]
    public partial class Constellation
    {
        public Constellation()
        {
            this.ConstellationBonus = new HashSet<ConstellationBonu>();
            this.UserArtifacts = new HashSet<UserArtifact>();
        }

        public int id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ConstellationBonu> ConstellationBonus { get; set; }
        public virtual ICollection<UserArtifact> UserArtifacts { get; set; }
    }
    public class ConstellationMetaData 
    {
        public int id { get; set; }

        [Required(ErrorMessageResourceName = "RequiredName",
   ErrorMessageResourceType = typeof(ValidationConstellation.ValidationStrings))]
        [Display(Name = "Назва")]
        [StringLength(50, ErrorMessageResourceName = "StringLength",
   ErrorMessageResourceType = typeof(ValidationConstellation.ValidationStrings))]
        public string Name { get; set; }
        [Required(ErrorMessageResourceName = "RequiredIcon",
        ErrorMessageResourceType = typeof(ValidationConstellation.ValidationStrings))]
        [Display(Name = "Іконка")]
        public string Icon { get; set; }
        [Required(ErrorMessageResourceName = "RequiredDescription",
         ErrorMessageResourceType = typeof(ValidationConstellation.ValidationStrings))]
        [Display(Name = "Опис")]
        [StringLength(50, ErrorMessageResourceName = "StringLength",
   ErrorMessageResourceType = typeof(ValidationConstellation.ValidationStrings))]
        public string Description { get; set; }
    }
}