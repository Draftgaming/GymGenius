using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Models
{
    public class Coach_Model:Model
    {
        public string? CoachName { get; set; }
        public List<People_Model> People { get; set; }
    }
}
