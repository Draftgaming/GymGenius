using Microsoft.VisualBasic;
using System.Data;
using System.Reflection.PortableExecutable;
using ViewModels.Models;

namespace GymGeniusWebService.Factory_Methods
{
    //create a muscle model
    public class MusclesCreator : ModelCreator<Muscles_Model>
    {
        public Muscles_Model CreateModel(IDataReader src)
        {
            Muscles_Model muscle = new Muscles_Model()
            {
                Id = Convert.ToString(src["Muscles_ID"]),
                MusclesName = Convert.ToString(src["Muscles_Name"]),
                MusclesDescription = Convert.ToString(src["Muscles_Description"]),
                Machines = null,

            };
            return muscle;
                 
        }
    }



}



        

