﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ArtifactAdmin.Models
{
    [MetadataType(typeof(BonuseMetaData))]
    public partial class Bonu
    {
    }
    public class BonuseMetaData 
    {

        public int Id { get; set; }

        [Required(ErrorMessageResourceName = "RequiredName",
    ErrorMessageResourceType = typeof(ValidationConstellation.ValidationStrings))]
        [Display(Name = "Назва")]
        public string Name { get; set; }
        [Required(ErrorMessageResourceName = "RequiredDescription",
        ErrorMessageResourceType = typeof(ValidationConstellation.ValidationStrings))]
        [Display(Name = "Опис")]
        public string Description { get; set; }
    }
}