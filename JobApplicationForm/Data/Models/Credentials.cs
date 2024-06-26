using System.ComponentModel.DataAnnotations;

namespace JobApplicationForm.Data.Models
{
    public class Credentials
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "User Name")]
        [Required(ErrorMessage = "This Field Must be filled")]
        public string Username { get; set; }

        [Required(ErrorMessage = "This Field Must be filled")]
        public string Password { get; set; }
    }
}
