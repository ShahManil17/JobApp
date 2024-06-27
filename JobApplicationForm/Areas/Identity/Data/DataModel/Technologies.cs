namespace JobApplicationForm.Areas.Identity.Data.DataModel
{
    public class Technologies
    {
        public int Id { get; set; }
        public string? TechName { get; set; }
        public string? TechLevel { get; set; }

        public int BasicDetailsId { get; set; }
        public virtual BasicDetails? BasicDetails { get; set; }
    }
}
