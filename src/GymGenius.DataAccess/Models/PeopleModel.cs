using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GymGenius.DataAccess.Models
{
    public class PeopleModel: ModelBase
    {
        [JsonPropertyName(name: "People_Name")]

        [Required]
        public string PeopleName { get; set; }


        [JsonPropertyName(name: "People_Number")]

        [Required]
        [Phone]
        public string PeopleNumber { get; set; }


        [JsonPropertyName(name: "People_Weight")]

        [Required]
        public string PeopleWeight { get; set; }

        [JsonPropertyName(name: "People_Age")]

        [Required]
        public string PeopleAge { get; set; }


        [JsonPropertyName(name: "People_Password")]

        [Required]
        [MinLength(6)]
        public string PeoplePassword { get; set; }

        [JsonPropertyName(name: "People_Email")]

        [Required]
        [EmailAddress]
        public string PeopleEmail { get; set; }

        
        [JsonPropertyName(name: "Exersice_ID")]

        public List<ExersiceModel> Exersice { get; set; }
    }
}
