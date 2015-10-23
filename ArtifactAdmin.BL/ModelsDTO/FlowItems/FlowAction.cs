namespace ArtifactAdmin.BL.ModelsDTO.FlowItems
{
    public class FlowAction
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public string PredispositionResult { get; set; }

        public double ExperienceModifier { get; set; }

        public int Duration { get; set; }

        public int ActionChangeCost { get; set; }

        public int ActionImprovementCost { get; set; }

        public string Icon { get; set; }

        public FlowStep NextStep { get; set; }
    }
}