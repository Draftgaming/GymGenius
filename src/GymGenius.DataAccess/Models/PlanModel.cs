using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymGenius.DataAccess.Models
{
    public class PlanModel: ModelBase
    {
        public string PlanExercise { get; set; }
        public string PlanName { get; set; }
        public List<PeopleModel> People { get; set; }
        public List<ExersiceModel> Exersice { get; set; }
    }
}
