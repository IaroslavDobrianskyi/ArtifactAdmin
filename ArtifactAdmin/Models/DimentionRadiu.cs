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
    using System.Collections.Generic;

    public partial class DimentionRadiu
    {
        public DimentionRadiu()
        {
            this.MiddlePointNeighbors = new HashSet<MiddlePointNeighbor>();
            this.PathFinderConfigs = new HashSet<PathFinderConfig>();
        }
    
        public int Id { get; set; }
        public int MapInfoDimension { get; set; }
        public int Radius { get; set; }
    
        public virtual MapInfoDimension MapInfoDimension1 { get; set; }
        public virtual ICollection<MiddlePointNeighbor> MiddlePointNeighbors { get; set; }
        public virtual ICollection<PathFinderConfig> PathFinderConfigs { get; set; }
    }
}
