using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GymGenius.DataAccess.Models
{
    public class MusclesModel : ModelBase
    {
        [JsonPropertyName(name: "Machine_ID")]
        public string MusclesName { get; set; }

        [JsonPropertyName(name: "Muscles_Description")]
        public string MusclesDescription { get; set; }

       
       // [JsonPropertyName(name: "Machine_ID")]
        //public List<MachineModel> Machines { get; set; }
    }
}
