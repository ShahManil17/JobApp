using System.ComponentModel.DataAnnotations;

namespace JobApplicationForm.Areas.Identity.Data.DataModel
{
    public class EducationDetails
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int EduLevel { get; set; }

        [Required]
        [Display(Name = "Board/University Name")]
        public string? BoardName { get; set; }

        [Required]
        [StringLength(4, ErrorMessage = "Invalid Year Entered", MinimumLength = 4)]
        [Display(Name = "Passing Year")]
        public string? PassingYear { get; set; }

        [Required]
        [Range(0, 100, ErrorMessage = "Invalid Percentage Entered")]
        public Decimal Percentage { get; set; }

        [Required]
        public int BasicDetailsId { get; set; }
        public virtual BasicDetails? BasicDetails { get; set; }
    }
}
