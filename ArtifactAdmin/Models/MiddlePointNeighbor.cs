//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ArtifactAdmin.DAL.Models
{
    public partial class MiddlePointNeighbor
    {
        public int Id { get; set; }
        public int DimensionRadius { get; set; }
        public string NeighborCoordinates { get; set; }
        public int MiddlePoint { get; set; }
    
        public virtual MiddlePoint MiddlePoint1 { get; set; }
        public virtual DimentionRadiu DimentionRadiu { get; set; }
    }
}
