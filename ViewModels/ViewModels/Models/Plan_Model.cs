using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Models
{
    public class Plan_Model : Model
    {
        public string? PlanExercise { get; set; }
        public string? PlanName { get; set; }
        public List<People_Model> People { get; set; }
        public List<Exersice_Model> Exersice { get; set; }

    }
}
