using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ArtifactAdmin.Models
{
    [MetadataType(typeof(TalentMetaData))]
    public partial class Talent
    {
    }
    public class TalentMetaData
    {
        public int id { get; set; }
        [Required(ErrorMessageResourceName = "RequiredDescription",
        ErrorMessageResourceType = typeof(ValidationConstellation.ValidationStrings))]
        [Display(Name = "Опис")]
        public string Description { get; set; }
        [Required(ErrorMessageResourceName = "RequiredName",
    ErrorMessageResourceType = typeof(ValidationConstellation.ValidationStrings))]
        [Display(Name = "Назва")]
        public string Name { get; set; }
        public int MaxLevel { get; set; }
        public double Modifier { get; set; }
        public double BaseValue { get; set; }
        public double BaseModifier { get; set; }
    }
}