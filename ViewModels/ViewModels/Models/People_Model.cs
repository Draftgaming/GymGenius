using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Models
{
    public class People_Model : Model
    {
        public string? PeopleName { get; set; }
        public string? PeopleNumber { get; set; }
        public string? PeopleWeight { get; set; }
        public string? PeopleAge { get; set; }
        public string? PeoplePassword { get; set; }
        public string? PeopleEmail { get; set; }
        public List<Exersice_Model> Exersice { get; set; }
        public Coach_Model Coach { get; set; }
        public Plan_Model Plans { get; set; }

    }
}
