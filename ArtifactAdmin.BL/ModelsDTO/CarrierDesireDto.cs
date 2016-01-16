using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtifactAdmin.BL.ModelsDTO
{
    public class CarrierDesireDto
    {
        public int Id { get; set; }
        public int CarrierId { get; set; }
        public int DesireId { get; set; }
        public string DesireMask { get; set; }
        public int AddictionRequirement { get; set; }
        public bool IsSecret { get; set; }
        public int DefaultValue { get; set; }
        public double Value { get; set; }
    }
}