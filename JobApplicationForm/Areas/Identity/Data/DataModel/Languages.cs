using System.ComponentModel.DataAnnotations;

namespace JobApplicationForm.Areas.Identity.Data.DataModel
{
    public class Languages
    {
        [Key]
        public int Id { get; set; }
        public string? LangName { get; set; }
        public string? LangLevel { get; set; }

        public int BasicDetailsId { get; set; }
        public virtual BasicDetails? BasicDetails { get; set; }
    }
}
