using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GymGenius.DataAccess.Models
{
    public class CoachModel: ModelBase
    {
        [JsonPropertyName(name: "Coach_ID")]
        public long CoachId { get; set; }

        [JsonPropertyName(name: "Coach_Name")]
        public string CoachName { get; set; }

        // TODO: Fix with Alex!
        [JsonPropertyName(name: "People_ID")]
        public object People { get; set; }
    }
}
