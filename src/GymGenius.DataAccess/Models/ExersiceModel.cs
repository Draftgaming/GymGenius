using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymGenius.DataAccess.Models
{
    public class ExersiceModel: ModelBase
    {
        public string ExersiceName { get; set; }
        public MachineModel Machines { get; set; }
        public List<PeopleModel> People { get; set; }
        public List<PlanModel> Plans { get; set; }
    }
}
