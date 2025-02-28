using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Models;

namespace ViewModels.ViewModels
{
    public class MachinesCatalogViewModel
    {
        public List<Machines_Model> Machines { get; set; }
        public List<Muscles_Model> Muscles { get; set; }
        public int PageNumber { get; set; }
        public string? MusclesID { get; set; }
        public string? MachinesID { get; set; }
    }
}
