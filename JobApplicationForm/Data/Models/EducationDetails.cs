using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobApplicationForm.Data.Models
{
    public class EducationDetails
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Board/University Name")]
        public string BoardName { get; set; }

        [StringLength(4, ErrorMessage = "Invalid Year Entered", MinimumLength = 4)]
        [Display(Name = "Passing Year")]
        public string PassingYear { get; set; }

        [Range(0, 100, ErrorMessage = "Invalid Percentage Entered")]
        public Decimal Percentage { get; set; }

        public int BasicDetailsId { get; set; }
        public virtual BasicDetails BasicDetails { get; set; }
    }
}