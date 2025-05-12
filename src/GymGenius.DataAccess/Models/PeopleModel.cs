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
        [JsonPropertyName(name: "People_ID")]
        public long PeopleId{ get; set; }

        [JsonPropertyName(name: "People_Name")]
        public string PeopleName { get; set; }

        [JsonPropertyName(name: "People_Number")]
        public string PeopleNumber { get; set; }

        [JsonPropertyName(name: "People_Weight")]
        public string PeopleWeight { get; set; }

        [JsonPropertyName(name: "People_Age")]
        public string PeopleAge { get; set; }

        [JsonPropertyName(name: "People_Password")]
        public string PeoplePassword { get; set; }

        [JsonPropertyName(name: "People_Email")]
        public string PeopleEmail { get; set; }

        [JsonPropertyName(name: "Coach_ID")]
        public int? CoachId { get; set; }

        [JsonPropertyName(name: "Plan_ID")]
        public int? PlanId { get; set; }
    }
}
