using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymGenius.DataAccess.Models
{
    public class MachineModel : ModelBase
    {
        public string MachineName { get; set; }
        public string MachineDescription { get; set; }
        public string MachineImage { get; set; }
        public List<ExersiceModel> Exersice { get; set; }
        public List<MusclesModel> Muscles { get; set; }
    }
}
