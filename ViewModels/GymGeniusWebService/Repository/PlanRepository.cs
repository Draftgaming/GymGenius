using GymGeniusWebService.DB;
using GymGeniusWebService.Factory_Methods;
using System.Data;
using ViewModels.Models;

namespace GymGeniusWebService.Repository
{
    public class PlanRepository : Repository, IRepository<Plan_Model>
    {
        public PlanRepository(DBContext dbContext) : base(dbContext)
        {
        }

        // Create a Person
        public bool Create(Plan_Model entity)
        {
            string sql = $@"Insert into Plan_Model(Plan_Name, PlanExercise)
                            values(@Plan_Name, @PlanExercise)";
            base.dbContext.AddParameters("@Plan_Name", entity.PlanName);
            base.dbContext.AddParameters("@PlanExercise", entity.PlanExercise);
            return dbContext.Insert(sql);
        }

        // Update a Person
        public bool Update(Plan_Model model)
        {
            string sql = $@"Update Plan_Model 
                            set Plan_Name = @Plan_Name, 
                                PlanExercise = @PlanExercise, 
                            where Plan_ID = @Plan_ID";
            base.dbContext.AddParameters("@Plan_Name", model.PlanName);
            base.dbContext.AddParameters("@PlanExercise", model.PlanExercise);
            base.dbContext.AddParameters("@Plan_ID", model.Id.ToString());
            return dbContext.Update(sql);
        }

        // Delete a Person by entity
        public bool Delete(Plan_Model entity)
        {
            string sql = $@"Delete from Plan_Model where Plan_ID = @Plan_ID";
            base.dbContext.AddParameters("@Plan_ID", entity.Id.ToString());
            return dbContext.Delete(sql);
        }

        // Delete a Person by ID
        public bool Delete(string id)
        {
            string sql = $@"Delete from Plan_Model where Plan_ID = @Plan_ID";
            base.dbContext.AddParameters("@Plan_ID", id);
            return dbContext.Delete(sql);
        }

        // Get a Person by ID using a Creator
        public Plan_Model GetPlanID(string id, PlanCreator PlanCreator)
        {
            string sql = $@"select * from Plan_Model where Plan_ID = @Plan_ID";
            base.dbContext.AddParameters("@Plan_ID", id);
            using (IDataReader dataReader = base.dbContext.Read(sql))
            {
                return modelfactory.PlanCreator.CreateModel(dataReader);
            }
        }

        // Get all Plan
        public IEnumerable<Plan_Model> GetAll()
        {
            List<Plan_Model> Plan = new List<Plan_Model>();
            string sql = $@"select * from Plan_Model";
            using (IDataReader dataReader = this.dbContext.Read(sql))
            {
                while (dataReader.Read())
                {
                    Plan.Add(this.modelfactory.PlanCreator.CreateModel(dataReader));
                }
            }
            return Plan;
        }

        // Get a Person by ID
        public Plan_Model GetById(string id)
        {
            string sql = $@"select * from Plan_Model where Plan_ID = @Plan_ID";
            base.dbContext.AddParameters("@Plan_ID", id);
            using (IDataReader dataReader = this.dbContext.Read(sql))
            {
                if (dataReader.Read())
                {
                    return this.modelfactory.PlanCreator.CreateModel(dataReader);
                }
                return null;
            }
        }
    }
}
