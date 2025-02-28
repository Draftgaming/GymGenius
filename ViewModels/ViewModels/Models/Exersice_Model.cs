using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Models
{
    public class Exersice_Model : Model
    {
        public string? ExersiceName { get; set; }
        public Machines_Model Machines { get; set; }
        public List<People_Model> People { get; set; }
        public List<Plan_Model> Plans { get; set; }
    }
}
