using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GymGenius.DataAccess.Models
{
    public class PlanModel: ModelBase
    {
        [JsonPropertyName(name: "Plan_Exersice")]

        public string PlanExercise { get; set; }

        [JsonPropertyName(name: "Plan_Name")]

        public string PlanName { get; set; }
        [JsonPropertyName(name: "People_ID")]
        public List<PeopleModel> People { get; set; }

        [JsonPropertyName(name: "Exrsice_ID")]
        public List<ExersiceModel> Exersice { get; set; }
    }
}
