using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymGenius.DataAccess.Models
{
    public class PeopleModel: ModelBase
    {
        [Required]
        public string PeopleName { get; set; }

        [Required]
        [Phone]
        public string PeopleNumber { get; set; }

        [Required]
        public string PeopleWeight { get; set; }

        [Required]
        public string PeopleAge { get; set; }

        [Required]
        [MinLength(6)]
        public string PeoplePassword { get; set; }

        [Required]
        [EmailAddress]
        public string PeopleEmail { get; set; }

        public List<ExersiceModel> Exersice { get; set; }
    }
}
