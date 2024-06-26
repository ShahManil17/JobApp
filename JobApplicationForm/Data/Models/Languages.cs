using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JobApplicationForm.Data.Models
{
    public class Languages
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Level { get; set; }

        public int BasicDetailsId { get; set; }
        public virtual BasicDetails BasicDetails { get; set; }
    }
}
