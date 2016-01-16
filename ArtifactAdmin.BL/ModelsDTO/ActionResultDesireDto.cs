using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtifactAdmin.BL.ModelsDTO
{
    public class ActionResultDesireDto
    {
        public int Id { get; set; }
        public int ActionResult { get; set; }
        public int Desire { get; set; }
        public double Modifier { get; set; }
    }
}