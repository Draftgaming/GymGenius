using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymGenius.DataAccess.Models
{
    public class MusclesModel : ModelBase
    {
        public string MusclesName { get; set; }
        public string MusclesDescription { get; set; }
        public List<MachineModel> Machines { get; set; }
    }
}
