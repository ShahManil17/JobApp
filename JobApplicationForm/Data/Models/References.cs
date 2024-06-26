using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JobApplicationForm.Data.Models
{
    public class References
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        [Display(Name = "Contact Number")]
        [StringLength(10, ErrorMessage = "Invalid Number Entered", MinimumLength = 10)]
        public string PhoneNo { get; set; }

        public string Relation { get; set; }

        public int BasicDetailsId { get; set; }
        public virtual BasicDetails BasicDetails { get; set; }
    }
}
