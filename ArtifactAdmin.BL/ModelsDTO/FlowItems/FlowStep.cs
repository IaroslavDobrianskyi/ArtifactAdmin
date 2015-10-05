namespace ArtifactAdmin.BL.ModelsDTO.FlowItems
{
    using System.Collections.Generic;

    public class FlowStep
    {
        public int Id { get; set; }
        public int UserArtifact { get; set; }
        public string Text { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public int? Desire { get; set; }
        public bool? IsKey { get; set; }
        public int Duration { get; set; }

        public int ActiveAction { get; set; }
        public IEnumerable<FlowAction> ActionsList { get; set; }
    }
}