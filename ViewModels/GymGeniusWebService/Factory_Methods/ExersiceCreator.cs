using System.Data;
using ViewModels.Models;

namespace GymGeniusWebService.Factory_Methods
{
    public class ExersiceCreator : ModelCreator<Exersice_Model>
    {
        //create a Exersice model
        public Exersice_Model CreateModel(IDataReader src)
        {
            Exersice_Model exersice = new Exersice_Model()
            {
                Id = Convert.ToString(src["Exersice_ID"]),
                ExersiceName = Convert.ToString(src["Exersice_Name"]),
                Machines = null,
                People = null,
                Plans = null

            };
            return exersice;

        }
    }



}

