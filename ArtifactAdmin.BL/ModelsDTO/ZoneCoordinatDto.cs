using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtifactAdmin.BL.ModelsDTO
{
    public class ZoneCoordinatDto
    {    
        public int Id { get; set; }
        public MapZoneDto MapZone1 { get; set; }
        public string Coordinates { get; set; }
        public MapInfoDto MapInfo1 { get; set; }
    
    }
}