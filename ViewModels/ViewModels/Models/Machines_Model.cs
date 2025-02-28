using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Models
{
    public class Machines_Model : Model
    {
        public string? MachineName { get; set; }
        public string? MachineDescription { get; set; }
        public string? MachineImage { get; set; }
        public List<Exersice_Model> Exersice { get; set; }
        public List<Muscles_Model> Muscles { get; set; }
    }
}
