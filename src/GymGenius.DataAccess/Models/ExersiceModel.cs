using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GymGenius.DataAccess.Models
{
    public class ExersiceModel: ModelBase
    {
        [JsonPropertyName(name: "Exersice_Name")]
        public string ExersiceName { get; set; }
        
        
        [JsonPropertyName(name: "Machine_ID")]
        public MachineModel Machines { get; set; }
        
        
        [JsonPropertyName(name: "People_ID")]
        public List<PeopleModel> People { get; set; }
        
       
        [JsonPropertyName(name: "Plan_ID")]
        public List<PlanModel> Plans { get; set; }
    }
}
