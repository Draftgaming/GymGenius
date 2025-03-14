using System.Data;
using ViewModels.Models;

namespace GymGeniusWebService.Factory_Methods
{
    public class PeopleCreator:ModelCreator<People_Model>
    {
        //create a people model
        public People_Model CreateModel(IDataReader src)
        {
            People_Model people = new People_Model()
            {
                Id = Convert.ToString(src["People_ID"]),
                PeopleName = Convert.ToString(src["People_Name"]),
                PeopleNumber = Convert.ToString(src["People_Number"]),
                PeopleWeight = Convert.ToString(src["People_Weight"]),
                PeopleAge = Convert.ToString(src["People_Age"]),
                PeoplePassword = Convert.ToString(src["People_Password"]),
                PeopleEmail = Convert.ToString(src["People_Email"]),
                Exersice = null,
                Coach = null,
                Plans = null,

            };
            return people;
        }
    }
}

