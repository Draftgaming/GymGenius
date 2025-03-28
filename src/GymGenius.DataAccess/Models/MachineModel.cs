using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GymGenius.DataAccess.Models
{
    public class MachineModel : ModelBase
    {
        [JsonPropertyName(name: "Machine_Name")]
        public string MachineName { get; set; }

        
        [JsonPropertyName(name: "Machine_Description")]
        public string MachineDescription { get; set; }

        
        [JsonPropertyName(name: "Machine_Image")]
        public string MachineImage { get; set; }

        [JsonPropertyName(name: "Exersice_ID")]
        public List<ExersiceModel> Exersice { get; set; }
        
        
        [JsonPropertyName(name: "Muscles_ID")]
        public List<MusclesModel> Muscles { get; set; }
    }
}
