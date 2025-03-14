using System.Data;
using ViewModels.Models;

namespace GymGeniusWebService.Factory_Methods
{
    //create a coach model
    public class CoachCreator : ModelCreator<Coach_Model>
    {
        public Coach_Model CreateModel(IDataReader src)
        {
            Coach_Model coach = new Coach_Model()
            {
                Id = Convert.ToString(src["Coach_ID"]),
                CoachName = Convert.ToString(src["Coach_Name"]),
                People = null,

            };
            return coach;
        }
    }



}




