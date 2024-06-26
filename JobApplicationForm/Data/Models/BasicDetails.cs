using System.ComponentModel.DataAnnotations;

namespace JobApplicationForm.Data.Models
{
    public class BasicDetails
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "This Field Must Be Filled Out")]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "This Field Must Be Filled Out")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "This Field Must Be Filled Out")]
        public string Designation { get; set; }

        [Required(ErrorMessage = "This Field Must Be Filled Out")]
        [RegularExpression(@"^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$", ErrorMessage = "Invalid Mail Entered")]
        public string Email { get; set; }

        [Required(ErrorMessage = "This Field Must Be Filled Out")]
        public string Address1 { get; set; }

        [Required(ErrorMessage = "This Field Must Be Filled Out")]
        public string Address2 { get; set; }

        [Required(ErrorMessage = "This Field Must Be Filled Out")]
        [StringLength(10, ErrorMessage = "Invalid Number Entered", MinimumLength = 10)]
        [Display(Name = "Contact Number")]
        public string PhoneNo { get; set; }

        [Required(ErrorMessage = "This Field Must Be Filled Out")]
        public string City { get; set; }

        [Required(ErrorMessage = "This Field Must Be Filled Out")]
        public string State { get; set; }

        [Required(ErrorMessage = "This Field Must Be Filled Out")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "This Field Must Be Filled Out")]
        public int ZipCode { get; set; }

        [Required(ErrorMessage = "This Field Must Be Filled Out")]
        [Display(Name = "Relationship Status")]
        public string RelationshipStatus { get; set; }

        [Required(ErrorMessage = "This Field Must Be Filled Out")]
        [RegularExpression(@"^\d{4}\-(0?[1-9]|1[012])\-(0?[1-9]|[12][0-9]|3[01])$", ErrorMessage = "Invalid date or Format")]
        public DateOnly DateOfBirth { get; set; }

    }
}
