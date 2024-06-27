using System.ComponentModel.DataAnnotations.Schema;

namespace JobApplicationForm.Models.UpdateView
{
    [NotMapped]
    public class UpdateDataModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? PhoneNo { get; set; }
        public string? Gender { get; set; }
        public string? RelationshipStatus { get; set; }
        public List<EducationUpModel>? education { get; set; }
        public List<WorkUpModel>? work { get; set; }
        public List<LanguageUpModel>? languages { get; set; }
        public List<TechnologiesUpModel>? technologies { get; set; }
        public List<PreferencesUpModel>? preferences { get; set; }

    }
}
