using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Models
{
    public class Muscles_Model : Model
    {
        public string? MusclesName { get; set; }
        public string? MusclesDescription { get; set; }
        public List<Machines_Model> Machines { get; set; }
    }
}
