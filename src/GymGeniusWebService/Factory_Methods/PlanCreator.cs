using System.Data;
using ViewModels.Models;

namespace GymGeniusWebService.Factory_Methods
{
        public class PlanCreator : ModelCreator<Plan_Model>
        {
        //create a plan model
            public Plan_Model CreateModel(IDataReader src)
            {
                Plan_Model plan = new Plan_Model()
                {
                    Id = Convert.ToString(src["Plans_ID"]),
                    PlanExercise = Convert.ToString(src["Plans_Exersice"]),
                    PlanName = Convert.ToString(src["Plans_Name"]),
                    Exersice = null,
                    People = null,

                };
                return plan ;

            }
        }
    }

