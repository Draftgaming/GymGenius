using System.Data;
using ViewModels.Models;

namespace GymGeniusWebService.Factory_Methods
{
    //create a machine model
    public class MachinesCreator :ModelCreator<Machines_Model>
    {
        public Machines_Model CreateModel(IDataReader src)
        {

            Machines_Model machine = new Machines_Model()
            {
                Id = Convert.ToString(src["Machines_ID"]),
                MachineName = Convert.ToString(src["Machines_Name"]),
                MachineDescription = Convert.ToString(src["Mahines_Description"]),
                MachineImage = Convert.ToString(src["Machines_Image"]),
                Exersice = null,
                Muscles = null
            };
            return machine;
        }

      
    }
    

    
}
