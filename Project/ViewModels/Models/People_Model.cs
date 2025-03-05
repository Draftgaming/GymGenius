using System.ComponentModel.DataAnnotations;

namespace ViewModels.Models
{
    public class People_Model
    {
        [Required]
        public string? PeopleName { get; set; }

        [Required]
        [Phone]
        public string? PeopleNumber { get; set; }

        [Required]
        public string? PeopleWeight { get; set; }

        [Required]
        public string? PeopleAge { get; set; }

        [Required]
        [MinLength(6)]
        public string? PeoplePassword { get; set; }

        [Required]
        [EmailAddress]
        public string? PeopleEmail { get; set; }

        public List<Exersice_Model>? Exersice { get; set; }
        public Coach_Model? Coach { get; set; }
        public Plan_Model? Plans { get; set; }
    }
}
